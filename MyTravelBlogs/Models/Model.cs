﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTravelBlogs.Models
{
    public class Model
    {
        public List<Blog> Blogs { get; set; }
        public List<Blog> Blogs2 { get; set; }
        public List<Blog> Blogs3 { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Blog> Blog { get; set; }
        public Comment Comment { get; set; }
    }
}
