using Assginment.Models;
using Assginment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assginment.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly AppDbContext _appDbContext;

        public PostController(IPostRepository postRepository, ICommentRepository commentRepository, AppDbContext appDbContext)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            PostListViewModel postListViewModel = new PostListViewModel();

            postListViewModel.Posts = _postRepository.AllPosts;
            ViewBag.Title = "List of Post";

            return View(postListViewModel);
        }
        public ActionResult CommentList(int id)
        {
            if(_appDbContext.Posts.Any(ag => ag.id == id))
            {
                var post = _postRepository.GetPostByUser(id);
                ViewBag.Title = "Comments";
                ViewBag.Message = post.Message;
                ViewBag.Like = post.Like;
                ViewBag.User = post.Users;
                ViewBag.id = post.id;
                IEnumerable<string> comm = _commentRepository.GetCommentByUserName(post.id);
                if (comm == null)
                    return View();
                return View(comm);
                
            }
            return Redirect("/Post");

        }
        public ActionResult AddPost()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult AddPost(Post post)
        {
            
            if (post.Users == null || post.Message == null)
            {

                return Redirect("/Post ");
            }
            _appDbContext.Posts.Add(post);
            _appDbContext.SaveChanges();

            return Redirect("/Post ");

        }
        public ActionResult Likes(int id)
        {
            Post pst = _appDbContext.Posts.FirstOrDefault(p => p.id == id);

            pst.Like += 1;
            _appDbContext.Posts.Update(pst);
            _appDbContext.SaveChanges();
            return Redirect("/Post ");
        }

        public ActionResult AddComment(int id)
        {
            Comment c = new Comment();
            c.Postid = id;
            Post pst = _appDbContext.Posts.FirstOrDefault(p => p.id == id);
            if (pst != null)
            {
                c.User = pst.Users;
                ViewBag.message = pst.Message;
            }
            return View(c);
        }
        [HttpPost]
        public ActionResult AddComment()
        {
            Comment comm = new Comment();

            comm.comment = Request.Form["commm"];
            comm.Postid = Int32.Parse(Request.Form["postid"]);
            comm.User = Request.Form["user"];

            if(comm.comment == null || comm.User == null || comm.comment == "")
            {

                return Redirect($"/Post/CommentList/{comm.Postid}");
            }
            _appDbContext.Comments.Add(comm);
            _appDbContext.SaveChanges();
            return Redirect($"/Post/CommentList/{comm.Postid}");
        }

        public ActionResult Share(int id)
        {
          
            Post pst = _appDbContext.Posts.FirstOrDefault(p => p.id == id);
            return View(pst);
        }
        [HttpPost]
        public ActionResult Share()
        {
            Post post = new Post();
            post.Message = Request.Form["message"];
            string data = Request.Form["second"];
            string[] names = data.Split(':');
            string name = Request.Form["first"]+" Orginal Post: "+names.Last();
            post.Users = name;
            if (post.Message == null || post.Users == null || Request.Form["first"] == "")
            {
                ViewBag.TempData = "No User Name";
                return Redirect("/Post");
            }
            _appDbContext.Posts.Add(post);
            _appDbContext.SaveChanges();
            return Redirect("/Post");
        }
        

    }
}

