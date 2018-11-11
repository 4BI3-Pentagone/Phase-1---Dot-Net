using Newtonsoft.Json;
using Service.appointmentService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class DashboardDoctorController : Controller
    {

        public DashboardDoctorController()
        {
            ServiceAppointment S = new ServiceAppointment();

        }
        // GET: DashboardDoctor
        public ActionResult Index()
        {
            return View();
        }

      
        public ActionResult StatDoctor()
        {
            return View();
        }

        public ActionResult StatDoctor2()
        {
            return View();
        }


    }
}