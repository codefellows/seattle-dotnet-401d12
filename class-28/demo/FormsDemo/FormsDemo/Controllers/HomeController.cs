using FormsDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsDemo.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Add()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Add(Dog dog)
    {
      // Call the service create method
      if (!ModelState.IsValid)
      {
        return View(dog);
      }
      return Content("You made a good dog.");
    }


    // Add and update are the same except ...
    // Update requires an ID and/or the thing itself

    public IActionResult Update()
    {
      // Pretend we looked it up in the database
      Dog doggo = new Dog()
      {
        Name = "Rocky",
        Breed = "Collie",
        Owner = "Me"
      };

      return View(doggo);
    }

    [HttpPost]
    public IActionResult Update(Dog dog)
    {
      // Call the service update method
      if (!ModelState.IsValid)
      {
        return View(dog);
      }
      return Content("You updated a good dog.");
    }


  }
}
