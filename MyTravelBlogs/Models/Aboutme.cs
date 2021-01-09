using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTravelBlogs.Models
{
    public class Aboutme
    {
        [Key]
        public int Id { get; set; }
        public string photoUrl { get; set; }
        public int description { get; set; }
    }
}
