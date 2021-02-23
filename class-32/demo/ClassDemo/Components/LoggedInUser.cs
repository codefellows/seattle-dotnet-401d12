using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassDemo.Components
{
    [ViewComponent]
    public class LoggedInUserViewComponent : ViewComponent
    {
        //fetch username from cookies
        //We will need D.I.
        //have one of these to grab shopping cart info
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string username = HttpContext.Request.Cookies["Username"];

            //new instance of viewmodel
            ViewModel user = new ViewModel()
            {
                username = username
            };
            return View(user);
        }
        public class ViewModel
        {
            public string username { get; set; }
        }
    }
}
