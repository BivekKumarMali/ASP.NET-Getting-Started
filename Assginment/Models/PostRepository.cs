using Assginment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assginment.Models
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _appDbContext;

        public PostRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Post> AllPosts
        {
            get
            {
                return _appDbContext.Posts;
            }
        }

        public Post GetPostByUser(int id)
        {
            return _appDbContext.Posts.FirstOrDefault(p => p.id == id);
        }
    }
}
