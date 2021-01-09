using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTravelBlogs.Models
{
    public class Blog
    {
        [Key]
        public int blogId { get; set; }
        public string title { get; set; }
        public DateTime blogDate { get; set; }
        public string blogContent { get; set; }
        public string blogImage { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
