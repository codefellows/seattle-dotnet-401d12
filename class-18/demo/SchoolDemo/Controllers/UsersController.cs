using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolDemo.Models.Api;
using SchoolDemo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDemo.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private IUserService userService;

    public UsersController(IUserService service)
    {
      userService = service;
    }

    [HttpPost("Register")]
    public async Task<ActionResult<UserDto>> Register(RegisterUser data)
    {
      var user = await userService.Register(data, this.ModelState);

      if (ModelState.IsValid)
      {
        return user;
      }

      return BadRequest(new ValidationProblemDetails(ModelState));
    }

    [HttpPost("Login")]
    public async Task<ActionResult<UserDto>> Login(LoginData data)
    {
      var user = await userService.Authenticate(data.Username, data.Password);
      if (user != null)
      {
        return user;
      }
      return Unauthorized();
    }

  }
}
