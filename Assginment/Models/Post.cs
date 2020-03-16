using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assginment.Models
{
    public class Post
    {
        [Key]
        public int id { get; set; }
        public string Users { get; set; }
        public string Message { get; set; }
        public int Like { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
