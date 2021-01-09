using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyTravelBlogs.Controllers
{
    public class BlogDetailController : Controller
    {
        public IActionResult BlogDetail()
        {
            return View();
        }
    }
}