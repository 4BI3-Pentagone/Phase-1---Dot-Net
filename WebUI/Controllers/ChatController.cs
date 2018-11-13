using Domain;
using Microsoft.AspNet.Identity;
using Service.PostService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ChatController : Controller
    {// GET: Post 
        PostService sp = new PostService();
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            List<User> GetUsers = sp.GetUsers();

            var user = GetUsers.FirstOrDefault(u => u.Id == currentUserId);
            var us = new Users { ConnectionId = user.Id, UserName = user.FirstName + " " + user.lastName };

            Session["UserName"] = us.UserName;
            Session["Email"] = user.Email;
            return View(us);

        }
        public ActionResult PrivateChat()
        {
            string currentUserId = User.Identity.GetUserId();
            List<User> GetUsers = sp.GetUsers();
            var us = new Users { ConnectionId = "", UserName = "" };

            var user = GetUsers.FirstOrDefault(u => u.Id == currentUserId);
            if (user != null)
            {
                  us = new Users { ConnectionId = user.Id, UserName = user.FirstName + " " + user.lastName };

                Session["UserName"] = us.UserName;
                Session["Email"] = user.Email;
               
            }
            return View(us);

        }
    }
}
