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
            var blogs = _myContext.blogs.OrderByDescending(x => x.blogId).ToList();
            return View(blogs);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Blog blog)
        {
            blog.blogDate = DateTime.Now;
            _myContext.blogs.Add(blog);
            _myContext.SaveChanges();
            return RedirectToAction("Blogs","Admin");
        }

        public IActionResult Update(int id)
        {
            return View();
        }
        
        public IActionResult Delete(int blogId)
        {
            var blog = _myContext.blogs.Find(blogId); //silme işleminden sonra "blog silindi !! gibi bir alert?"
            _myContext.blogs.Remove(blog);
            _myContext.SaveChanges();
            return RedirectToAction("Blogs", "Admin");
        }
    }
}