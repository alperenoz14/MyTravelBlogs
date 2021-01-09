using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTravelBlogs.Models;

namespace MyTravelBlogs.Controllers
{
    public class BlogDetailController : Controller
    {
        private readonly MyContext _myContext;
        public BlogDetailController(MyContext myContext)
        {
            _myContext = myContext;
        }
        [HttpGet]
        public IActionResult BlogDetail(int id)
        {
            var blogDetail = _myContext.blogs.Where(x => x.blogId == id).ToList();
            return View(blogDetail);
        }
    }
}