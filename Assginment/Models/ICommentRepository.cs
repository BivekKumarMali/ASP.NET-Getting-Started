using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assginment.Models
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> AllComments { get; }
        public IEnumerable<string> GetCommentByUserName(int Postid);
    }
}
