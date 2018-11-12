using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class DashboardDoctorController : Controller
    {
        // GET: DashboardAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DoctorStat()
        {
            return View();
        }
    }
}