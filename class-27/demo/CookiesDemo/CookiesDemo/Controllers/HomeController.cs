using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookiesDemo.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index(string zip)
    {
      // http://localhost/index?zip=12345
      if (zip != null)
      {
        CookieOptions cookieOptions = new CookieOptions();
        cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddDays(7));
        HttpContext.Response.Cookies.Append("zipCode", zip, cookieOptions);
      }
      return View();
    }

    public IActionResult Weather()
    {
      string zip = HttpContext.Request.Cookies["zipCode"];
      ViewData["zip"] = zip; // not best practice!
      return View();
    }
  }
}
