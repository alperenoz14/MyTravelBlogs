﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTravelBlogs.Models;

namespace MyTravelBlogs.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly MyContext _myContext;
        public AdminController(MyContext myContext)
        {
            _myContext = myContext;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            var admn = _myContext.Admins.ToList();
            foreach (var a in admn)
            {
                if (admin.email == a.email && admin.password == a.password)
                {
                    HttpContext.Session.SetInt32("adminId", admin.adminId);
                    ClaimsIdentity identity = null;
                    identity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Role,"Admin")
                    }, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return RedirectToAction("Blogs", "Admin");
                }
                else
                {
                    return StatusCode(404, "ADMİN BULUNAMADI!");
                }
            }
            return StatusCode(404);
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
            HttpContext.Session.SetInt32("blogId", id);
            var blog = _myContext.blogs.Find(id);
            return View(blog);
        }
        
        [HttpPost]
        public IActionResult Update(Blog blog)
        {
            var id = HttpContext.Session.GetInt32("blogId");    //updated alert!!?...
            var UpdatedBlog = _myContext.blogs.Find(id);
            UpdatedBlog.title = blog.title;
            UpdatedBlog.blogContent = blog.blogContent;
            UpdatedBlog.blogImage = blog.blogImage;
            _myContext.SaveChanges();
            return RedirectToAction("Blogs", "Admin");
        }

        public IActionResult Delete(int blogId)
        {
            var blog = _myContext.blogs.Find(blogId); //silme işleminden sonra "blog silindi !! gibi bir alert?"...
            _myContext.blogs.Remove(blog);
            _myContext.SaveChanges();
            return RedirectToAction("Blogs", "Admin");
        }

        //comments will be listed and user can be delete...
        public IActionResult Comments()
        {
            var comments = _myContext.comments.OrderByDescending(x => x.commentId).ToList();
            return View(comments);
        }

        public IActionResult DeleteComment(int commentId)
        {
            var comment =_myContext.comments.Find(commentId);  //yorum silindi!! gibi bir alert...
            _myContext.comments.Remove(comment);
            _myContext.SaveChanges();
            return RedirectToAction("Comments", "Admin");
        }

        public IActionResult Detail(int id)
        {
            var blog = _myContext.blogs.Find(id);
            return View(blog);
        }

        [HttpPost]
        public IActionResult Signout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Admin");
        }
    }
}