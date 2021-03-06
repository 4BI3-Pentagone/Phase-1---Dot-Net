﻿using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {

            public ActionResult Index()
            {
            try
            {

                return View();
            }
            catch (Exception e)
            {
                return RedirectToAction("Error500", "Home", new { msg = e.InnerException.Message });
            }
        }

            public ActionResult About()
            {
                ViewBag.Message = "Your application description page.";

                return View();
            }

            public ActionResult Contact()
            {
                ViewBag.Message = "Your contact page.";

                return View();
            }
        }
    }