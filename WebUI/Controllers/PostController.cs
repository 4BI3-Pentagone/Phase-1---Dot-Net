using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Microsoft.AspNet.Identity;
using Service.PostService;
using ServicePattern;
using System.Net;

namespace WebUI.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        PostService ps = new PostService();
        ServiceUser su = new ServiceUser();
        public ActionResult Index(int? idcat, string recherch)
        {
            List<Post> Posts = new List<Post>();
            try
            {
                ViewBag.GetUserId = User.Identity.GetUserId();
                ViewBag.categoriepost = ps.GetCategoriePost();

                if (recherch != null)
                {
                    Posts = ps.GetPostsByrecherch(recherch);
                }
                else
                {
                    Posts = idcat == null ? ps.GetPosts() : ps.GetPostsBycat(idcat);
                }
                return View(Posts);
            }
            catch (Exception ex)
            {
                return View(Posts);
            }
        }
        [HttpPost]
        public ActionResult TermsAccept(string rechfilter)
        {
            try
            {
                return RedirectToAction("Index", "Post", new { recherch = rechfilter });
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }



        // GET: Post/Create
        public ActionResult Create()
        {
            ViewBag.categoriepost = ps.GetCategoriePost();
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(Post q)
        {
            try
            {
                // TODO: Add insert logic here
                string currentUserId = User.Identity.GetUserId();
                List<User> GetUsers = ps.GetUsers();
                var user = GetUsers.FirstOrDefault(u => u.Id == currentUserId);
                var cate = ps.GetCategoriePost().FirstOrDefault(u => u.Id == q.categoriePost.Id);
                //if (user != null)
                //{
                Post pos = new Post
                {
                    Message = q.Message,
                    Titre = q.Titre,
                    PostedDate = q.PostedDate,
                    UserId = currentUserId,
                    categoriePost = cate
                };
                if (user != null)
                {
                    user.Posts.Add(pos);
                    ps.Commit();
                    su.Commit();
                    ps.Commit();
                }



                return RedirectToAction("Index", "Post");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.categoriepost = ps.GetCategoriePost();
            var poste = ps.GetPosts().FirstOrDefault(u => u.PostID == id);
            if (poste == null)
            {
                return HttpNotFound();
            }
            return View(poste);
        } 
      

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Post q)
        {
            if (ModelState.IsValid)
            {
                var cate = ps.GetCategoriePost().FirstOrDefault(u => u.Id == q.categoriePost.Id);
                var poste = ps.GetPosts().FirstOrDefault(u => u.PostID == q.PostID);
                poste.Message = q.Message;
                poste.Titre = q.Titre;
                poste.PostedDate = q.PostedDate;
                poste.categoriePost = cate;
                ps.Commit();
                su.Commit(); 
            }

            return RedirectToAction("Index", "Post");
        }
        public ActionResult Delete(int? id)
        {
            var poste = ps.GetPosts().FirstOrDefault(u => u.PostID == id);
            if (poste == null)
            {
                return HttpNotFound();
            }
            string currentUserId = User.Identity.GetUserId();
            List<User> GetUsers = ps.GetUsers();
            var user = GetUsers.FirstOrDefault(u => u.Id == currentUserId);
            
                user.Posts.Remove(poste);
                ps. Delete(poste); 
            ps.Commit();
            su.Commit(); 
            return RedirectToAction("Index", "Post");
        }
    }
}
