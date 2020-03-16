using Assginment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assginment.Models
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _appDbContext;

        public CommentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Comment> AllComments
        {
            get
            {
                return _appDbContext.Comments;
            }
        }

        public IEnumerable<string> GetCommentByUserName(int id)
        {
            IEnumerable<string> comm = from u in _appDbContext.Comments
                                       where u.Postid == id
                                       select u.comment;
            return comm;
            
        }
    }
}
    