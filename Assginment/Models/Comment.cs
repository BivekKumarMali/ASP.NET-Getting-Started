using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assginment.Models
{
    public class Comment
    {
        [Key]
        public int id { get; set; }
        public string User { get; set; }
        public string comment { get; set; }
        public int Postid { get; set; }
    }
}
