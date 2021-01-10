using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTravelBlogs.Models
{
    public class Comment
    {
        [Key]
        public int commentId { get; set; }
        public string userName { get; set; }
        public string mail { get; set; }
        public string commentContent { get; set; }
        public DateTime date { get; set; }
        public int BlogId { get; set; }
        public virtual Blog blog { get; set; }
    }
}
