<<<<<<< HEAD
﻿using System;
=======
﻿using Newtonsoft.Json;
using Service.appointmentService;
using System;
using System.Collections;
>>>>>>> e60248d0369e76ffa555ab9475d66b8e7d31a3f3
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class DashboardDoctorController : Controller
    {
<<<<<<< HEAD
        // GET: DashboardAdmin
=======

        public DashboardDoctorController()
        {
            ServiceAppointment S = new ServiceAppointment();

        }
        // GET: DashboardDoctor
>>>>>>> e60248d0369e76ffa555ab9475d66b8e7d31a3f3
        public ActionResult Index()
        {
            return View();
        }

<<<<<<< HEAD
        public ActionResult DoctorStat()
        {
            return View();
        }
=======
      
        public ActionResult StatDoctor()
        {
            return View();
        }

        public ActionResult StatDoctor2()
        {
            return View();
        }


>>>>>>> e60248d0369e76ffa555ab9475d66b8e7d31a3f3
    }
}