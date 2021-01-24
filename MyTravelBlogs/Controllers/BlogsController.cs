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
            var blogs = _myContext.blogs.OrderByDescending(x => x.blogId).ToList();
            var lastBlog = _myContext.blogs.OrderByDescending(x => x.blogId).Take(1).ToList();
            var model = new Model();
            model.Blogs = blogs;
            model.Blog = lastBlog;
            return View(model);
        }
    }
}