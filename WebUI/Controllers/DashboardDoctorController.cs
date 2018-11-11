using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class DashboardDoctorController : Controller
    {
        // GET: DashboardDoctor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StatDoctor()
        {
            return View();
        }
    }
}