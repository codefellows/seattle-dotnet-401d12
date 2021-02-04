using SchoolDemo.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolDemo.Models.Interfaces;
using SchoolDemo.Services;
using Microsoft.OpenApi.Models;
using SchoolDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace SchoolDemo
{
  public class Startup
  {
    // 1. Add a property to hold our configuration
    public IConfiguration Configuration { get; }

    // 2. Add a constructor to receive our condfiguration (through some magic)
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    // This is very similar to what dotenv did for us in NodeJS
    public void ConfigureServices(IServiceCollection services)
    {
      // 3. Register our DbContext with the app
      services.AddDbContext<SchoolDbContext>(options =>
      {
        // Equivalent to DATABASE_URI
        string connectionString = Configuration.GetConnectionString("DefaultConnection");
        options.UseSqlServer(connectionString);
      });

      services.AddIdentity<ApplicationUser, IdentityRole>(options =>
       {
         options.User.RequireUniqueEmail = true;
       })
      .AddEntityFrameworkStores<SchoolDbContext>();

      services.AddScoped<JwtTokenService>();

      // This will eventually allow us to "Decorate" (Annotate) our routes
      services.AddAuthentication(options =>
        {
          options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
          options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
          options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
         {
           options.TokenValidationParameters = JwtTokenService.GetValidationParameters(Configuration);
         });

      services.AddAuthorization(options =>
      {
        // Add "Name of Policy", and the Lambda returns a definition
        options.AddPolicy("create", policy => policy.RequireClaim("permissions", "create"));
        options.AddPolicy("update", policy => policy.RequireClaim("permissions", "update"));
        options.AddPolicy("delete", policy => policy.RequireClaim("permissions", "delete"));
        options.AddPolicy("deposit", policy => policy.RequireClaim("permissions", "deposit"));
      });

      // Register my Dependency Injection services
      // This mapps the Dependency (IStudent) to the correct Service (StudentRepository)
      // "Whenever I see IStudent, use StudentRepository
      // This makes StudentRepository swappapble with any alternate implementation
      services.AddTransient<ICourse, CourseRepository>();
      services.AddTransient<IStudent, StudentRepository>();
      services.AddTransient<ITechnology, TechnologyRepository>();
      services.AddTransient<IUserService, IdentityUserService>();


      // Bring in our controllers
      services.AddMvc();
      services.AddControllers();


      services.AddControllers().AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
      );

      services.AddSwaggerGen(options =>
      {
        // Make sure get the "using Statement"
        options.SwaggerDoc("v1", new OpenApiInfo()
        {
          Title = "School Demo",
          Version = "v1",
        });
      });

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseSwagger(options =>
      {
        options.RouteTemplate = "/api/{documentName}/swagger.json";
      });

      app.UseSwaggerUI(options =>
      {
        options.SwaggerEndpoint("/api/v1/swagger.json", "Student Demo");
        options.RoutePrefix = "";
      });

      app.UseEndpoints(endpoints =>
       {
         endpoints.MapControllers();
       });
    }
  }
}
