using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyTravelBlogs.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Aboutme()
        {
            return View();
        }
    }
}