using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolDemo.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDemo.Models.Interfaces
{
  public interface IUserService
  {
    public Task<UserDto> Register(RegisterUser data, ModelStateDictionary modelState);

    public Task<UserDto> Authenticate(string username, string password);

  }
}
