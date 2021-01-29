using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTravelBlogs.Models;

namespace MyTravelBlogs.Controllers
{
    public class HomepageController : Controller
    {
        private readonly MyContext _myContext;
        public HomepageController(MyContext myContext)
        {
            _myContext = myContext;
        }
        public IActionResult Home()
        {
            //datalar viewa basılacak...
            //error var lastBlogda...
            var lastBlog = _myContext.blogs.OrderByDescending(x => x.blogId).Take(1).ToList();//last blog,hata alırsan list olarak al...
            //var places = _myContext.blogs.ToList(); //gittigim yerler,ayri migration olusuturup da eklenebilir,gidilen ama blogu olmayan ülkeler icin...
            var blogs = _myContext.blogs.ToList();
            var lastBlogs = _myContext.blogs.OrderByDescending(x => x.blogId).Take(3).ToList(); //blog sayisi artinca son 5 blog alinacak...
            var model = new Model();
            model.Blogs2 = lastBlog;
            model.Blogs = blogs;
            //model.Blogs = places;
            model.Blogs3 = lastBlogs;
            return View(model);
        }
    }
}