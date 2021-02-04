using SchoolDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace SchoolDemo.Data
{
  public class SchoolDbContext : IdentityDbContext<ApplicationUser>
  {
    public SchoolDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // We need Identity to do it's pre-loads/stuff/work/etc before we do.
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Technology>().HasData(
        new Technology { Id = 1, Name = ".NET " },
        new Technology { Id = 2, Name = "Node.js" }
      );

      SeedRole(modelBuilder, "Administrator", "create", "update", "delete");
      SeedRole(modelBuilder, "Guest", "create");

      // This creates the composite primary key for the enrollments table
      modelBuilder.Entity<Enrollment>().HasKey(
        // Create a new "anonymous" type (like a JS object)
        enrollment => new { enrollment.CourseId, enrollment.StudentId }
      );
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Technology> Technologies { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Transcript> Transcripts { get; set; }

    // This will fail the first time when you try to make a migration because there's no primary key (id)
    // Do a modelbuilder override, and then add it
    public DbSet<Enrollment> Enrollments { get; set; }

    private int id = 1;
    private void SeedRole(ModelBuilder modelBuilder, string roleName, params string[] permissions)
    {
      var role = new IdentityRole
      {
        Id = roleName.ToLower(),
        Name = roleName,
        NormalizedName = roleName.ToUpper(),
        ConcurrencyStamp = Guid.Empty.ToString()
      };
      modelBuilder.Entity<IdentityRole>().HasData(role);

      // Go through the permissions list and seed a new entry for each
      var roleClaims = permissions.Select(permission =>
       new IdentityRoleClaim<string>
       {
         Id = id++,
         RoleId = role.Id,
         ClaimType = "permissions",
         ClaimValue = permission
       }
      );
      modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);
    }
  }
}
