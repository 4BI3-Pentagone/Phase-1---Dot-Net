using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {

        public string AddUser()
        {
            // s = new AppService();
           // s.TestContext();


            //UserService us = new UserService();
            //var user = new ApplicationUser
            //{
            //    UserName = "TestUser",
            //    Email = "TestUser@test.com"
            //};


            //var result = await us.UserManager.CreateAsync(user);
            //if (!result.Succeeded)
            //{
            //    return result.Errors.First();
            //}
            return "User Added";
        }
    }
}