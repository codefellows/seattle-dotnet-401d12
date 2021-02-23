using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClassDemo.Pages
{
    public class SettingsModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public bool Mode { get; set; } 
        
        public void OnGet()
        {
            //OnGet's job is to get all the data to render the page!
            Username = HttpContext.Request.Cookies["Username"];
            Mode = Convert.ToBoolean(HttpContext.Request.Cookies["Mode"]); 
        }
        public void OnPost() 
        {
            //Post changes it! (sets the cookies)
            CookieOptions cookieoption = new CookieOptions();
            cookieoption.Expires = new DateTimeOffset(DateTime.Now.AddDays(7));
            HttpContext.Response.Cookies.Append("Username", Username, cookieoption);
            HttpContext.Response.Cookies.Append("Mode", Mode.ToString(), cookieoption);

        }
    }
}
