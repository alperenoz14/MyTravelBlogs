﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyTravelBlogs.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Blogs()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}