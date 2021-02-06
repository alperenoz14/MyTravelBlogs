using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTravelBlogs.Models;

namespace MyTravelBlogs.Controllers
{
    public class AdminController : Controller
    {
        private readonly MyContext _myContext;
        public AdminController(MyContext myContext)
        {
            _myContext = myContext;
        }

        public IActionResult Blogs()
        {
            var blogs = _myContext.blogs.ToList();
            return View(blogs);
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