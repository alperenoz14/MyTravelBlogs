using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTravelBlogs.Models
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions<MyContext> options):base(options)
        {

        }

        public DbSet<Aboutme> Aboutme { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Blog> blogs { get; set; }
        public DbSet<Comment> comments { get; set; }
        
    }
}
