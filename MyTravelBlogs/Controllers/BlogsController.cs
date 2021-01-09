using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTravelBlogs.Models;
using Microsoft.EntityFrameworkCore;

namespace MyTravelBlogs.Controllers
{
    public class BlogsController : Controller
    {
        private readonly MyContext _myContext;
        public BlogsController(MyContext myContext)
        {
            _myContext = myContext;
        }
        public IActionResult Blogs()
        {
            var blogs = _myContext.blogs.ToList();
            return View(blogs);
            
        }
    }
}