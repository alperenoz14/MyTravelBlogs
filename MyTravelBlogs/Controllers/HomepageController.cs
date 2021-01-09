using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyTravelBlogs.Controllers
{
    public class HomepageController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}