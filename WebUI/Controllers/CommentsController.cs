using Domain;
using Service.CommentService;
using Service.PostService;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.ViewModels;
using Microsoft.AspNet.Identity;


namespace WebUI.Controllers
{
    public class CommentsController : Controller
    {
         PostService sp = new PostService();
        CommentService sc = new CommentService();
        ServiceUser su = new ServiceUser();
        // GET: Response
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetResponse(int id)
        {
            Post pos = sp.GetPostsByid(id);
            List<Post> Postsf = new List<Post> { pos };

            IEnumerable<PostsVM> Postsvm = Postsf
                .Select(p => new PostsVM
                {
                    PostID = p.PostID,
                    Titre = p.Titre,
                    Message = p.Message,
                    PostedDate = p.PostedDate.Value,
                    Username = p.User.FirstName + " " + p.User.lastName,
                    Categorie = p.categoriePost.Libelle
                }).ToList();

            return View(Postsvm);
        }

        public PartialViewResult GetComments(int postId)
        {
            List<Comment> Comments = sp.GetComments();
            IEnumerable<CommentsVM> comments = Comments.Where(c => c.Post.PostID == postId)
                                                       .Select(c => new CommentsVM
                                                       {
                                                           ComID = c.ComID,
                                                           CommentedDate = c.CommentedDate.Value,
                                                           CommentMsg = c.CommentMsg,
                                                           Users = new UserVM
                                                           {
                                                               UserID = c.User.Id,
                                                               Username = c.User.FirstName,
                                                               imageProfile = c.User.ImageName
                                                           }
                                                       }).ToList();
            ViewBag.GetUserId = User.Identity.GetUserId();
            return PartialView("~/Views/Shared/_MyComments.cshtml", comments);
        }

        [HttpPost]
        public ActionResult AddComment(CommentsVM comment, int postId)
        {
            //bool result = false;
            Comment commentEntity = null;

            string currentUserId = User.Identity.GetUserId();
          //  int userId = 1;
            //int.Parse(currentUserId);
            //(int)Session["UserID"]; 
            List<User> GetUsers = sp.GetUsers();

            var user = GetUsers.FirstOrDefault(u => u.Id == currentUserId);
            var post = sp.GetPosts().FirstOrDefault(p => p.PostID == postId);

            if (comment != null)
            {

                commentEntity = new Comment
                {
                    CommentMsg = comment.CommentMsg,
                    CommentedDate = DateTime.Now
                    //comment.CommentedDate,
                };


                if (user != null && post != null)
                {
                    post.Comments.Add(commentEntity);
                    user.Comments.Add(commentEntity);
                    //sq.SaveChanges( );
                    //dbContext.SaveChanges();
                    //result = true;

                    sp.Commit();
                    su.Commit();
                }
            }

            return RedirectToAction("GetComments", "Comments", new { postId = postId });
        }
        [HttpPost]
        public ActionResult DelComment( int ComID)
        {
            //bool result = false;
            Comment commentEntity = null;  
            string currentUserId = User.Identity.GetUserId(); 
            List<User> GetUsers = sp.GetUsers();

            var comments = sp.GetComments().FirstOrDefault(u => u.ComID == ComID);
            var user = GetUsers.FirstOrDefault(u => u.Id == currentUserId);
            var post = sp.GetPosts().FirstOrDefault(p => p.PostID == comments .PostID  );
            if (comments != null)
            {
 
                if (user != null && post != null)
                {
                    sp.DelComments(comments); 
                }
            }

            return RedirectToAction("GetComments", "Comments", new { postId = comments.PostID });
        }
        [HttpGet]
        public PartialViewResult GetSubComments(int ComID)
        {
            IEnumerable<SubCommentsVM> subComments = new List<SubCommentsVM>();
              var lstSubComments = sp.GetSubComments();
           // if (lstSubComments.Count() != 0)
           // {
           //subComments = lstSubComments.Where(sc => sc.Comment.ComID == ComID)
           //                                                   .Select(sc => new SubCommentsVM
           //                                                   {
           //                                                       SubComID = sc.SubComID,
           //                                                       CommentMsg = sc.CommentMsg,
           //                                                       CommentedDate = sc.CommentedDate.Value,
           //                                                       User = new UserVM
           //                                                       {
           //                                                           UserID = 1,
           //                                                           Username = sc.User.FirstName,
           //                                                           imageProfile = sc.User.ImageName
           //                                                       }
           //                                                   }).ToList();


           // }
            IQueryable<SubCommentsVM> subCommentss = lstSubComments.Where(sc => sc.Comment.ComID == ComID)
                                     .Select(sc => new SubCommentsVM
                                     {
                                         SubComID = sc.SubComID,
                                         CommentMsg = sc.CommentMsg,
                                         CommentedDate = sc.CommentedDate.Value,
                                         User = new UserVM
                                         {
                                             UserID = sc.User.Id,
                                             Username = sc.User.FirstName,
                                             imageProfile = sc.User.ImageName
                                         }
                                     }).AsQueryable();
             
            return PartialView("~/Views/Shared/_MySubComments.cshtml", subCommentss);
        }

        [HttpPost]
        public ActionResult AddSubComment(SubCommentsVM subComment, int ComID)
        {
            SubComment subCommentEntity = null;
            // int userId = (int)Session["UserID"];
            string currentUserId = User.Identity.GetUserId();
            int userId = 1;
            List<User> GetUsers = sp.GetUsers();

            var user = GetUsers.FirstOrDefault(u => u.Id == currentUserId);
            var comment = sp.GetComments().FirstOrDefault(p => p.ComID == ComID);

            if (subComment != null)
            {

                subCommentEntity = new SubComment
                {
                    CommentMsg = subComment.CommentMsg,
                    CommentedDate = DateTime.Now
                    //subComment.CommentedDate,
                };


                if (user != null && comment != null)
                {
                    comment.SubComments.Add(subCommentEntity);
                    user.SubComments.Add(subCommentEntity);
                    sc.Commit();
                    su.Commit();
                    sp.Commit();
                    //  dbContext.SaveChanges();
                    //result = true;
                }
            }

            return RedirectToAction("GetSubComments", "Comments", new { ComID = ComID });

        }
    }

}
