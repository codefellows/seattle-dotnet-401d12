using CookiesDemo.Auth.Models.Dto;
using CookiesDemo.Auth.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookiesDemo.Controllers
{
  public class LoginController : Controller
  {
    private IUserService userService;

    // IUserService is "given to us" by DI
    public LoginController(IUserService service)
    {
      userService = service;
    }

    // This should be the login screen
    public IActionResult Index()
    {
      return View();
    }

    // Register Screen
    public IActionResult Signup()
    {
      return View();
    }

    // Error Screen
    public IActionResult Error()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> Authenticate(LoginData data)
    {
      var user = await userService.Authenticate(data.Username, data.Password);
      if (user == null)
      {
        return Redirect("/login");
      }
      return Redirect("/login/welcome");
    }


    [HttpPost]
    public async Task<ActionResult<UserDto>> Register(RegisterUser data)
    {
      // Hardcode the role (yes, this is bad)
      data.Roles = new List<string>() { "guest" };

      var user = await userService.Register(data, this.ModelState);
      if (ModelState.IsValid)
      {
        return Redirect("/login");
      }
      return Redirect("/login/error");
    }

    public IActionResult Welcome()
    {
      return View();
    }

    //[Authorize]
    //[Authorize(Roles="Guest")]
    [Authorize(Policy = "read")]
    public async Task<ActionResult<UserDto>> Profile()
    {
      UserDto user = await userService.GetUser(this.User);
      return View(user);
    }
  }
}
