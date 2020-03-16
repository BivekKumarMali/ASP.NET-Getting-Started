using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assginment.Models
{
    public interface IPostRepository
    {
        IEnumerable<Post> AllPosts { get; }
        Post GetPostByUser(int id);
    }
}
