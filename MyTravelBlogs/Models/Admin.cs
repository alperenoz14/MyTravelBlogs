using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTravelBlogs.Models
{
    public class Admin
    {
        [Key]
        public int adminId { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
