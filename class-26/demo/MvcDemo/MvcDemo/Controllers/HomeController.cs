using Microsoft.AspNetCore.Mvc;
using MvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcDemo.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index(string fullName, string jobTitle)
    {
      return View();
    }

    public IActionResult Person(string fullName, string jobTitle)
    {
      // A string (hopefully html) that is the result of the View() process
      // Turning data+templates into markup

      // Perhaps a service that gets a person and renders it?

      Person person = new Person()
      {
        name = fullName,
        job = jobTitle
      };

      return View(person);
    }


    public IActionResult People()
    {
      // Imagine a world where you run some Linnq magic and get actual data ...
      List<Person> people = new List<Person>()
      {
        new Person() {name="John", job = "Instructor" },
        new Person() {name="Cathy", job = "Consultant" },
        new Person() {name="Zach", job = "Student" },
        new Person() {name="Char", job = "Office Manager" }
      };
      return View(people);
    }

    public IActionResult Article()
    {
      // Again, imagine some linq and sql stuff here to get actual data
      Person author = new Person()
      {
        name = "John",
        job = "Editor at Large"
      };

      Blog story = new Blog()
      {
        title = "The world according to john",
        text = "Everyone should listen to what I have to say, cuz I have the wisdom and stuff"
      };

      PostVm post = new PostVm()
      {
        blog = story,
        author = author
      };

      return View(post);
    }
  }
}
