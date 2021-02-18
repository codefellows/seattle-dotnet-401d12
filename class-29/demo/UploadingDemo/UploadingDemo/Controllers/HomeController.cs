using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UploadingDemo.Models;
using UploadingDemo.Services;

namespace UploadingDemo.Controllers
{


  public class HomeController : Controller
  {
    IUploadService UploadService { get; set; }

    public HomeController(IUploadService service)
    {
      UploadService = service;
    }

    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(IFormFile file)
    {
      Document document = await UploadService.Upload(file);
      return View(document);
    }

  }

}
