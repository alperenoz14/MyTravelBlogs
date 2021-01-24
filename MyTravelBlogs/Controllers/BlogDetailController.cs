using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            HttpContext.Session.SetInt32("blogId",id);
            var blogDetail = _myContext.blogs.Where(x => x.blogId == id).ToList();
            var comments = _myContext.comments.Where(x => x.BlogId == id).ToList();
            var lastBlogs = _myContext.blogs.OrderByDescending(x => x.blogId).Take(3).ToList(); //blog sayisi artınca son 5 blog alınacak...
            var model = new Model();
            model.Blogs = blogDetail;
            model.Comments = comments;
            model.Blogs2 = lastBlogs;
            return View(model);
        }

        [HttpPost]
        public IActionResult BlogDetail(Comment comment)
        {
            var blogId = HttpContext.Session.GetInt32("blogId");
            comment.BlogId = Convert.ToInt32(blogId);
            comment.date = DateTime.Now;
            _myContext.comments.Add(comment);
            _myContext.SaveChanges();
            return RedirectToAction("Blogdetail","Blogdetail");
        }

    }
}