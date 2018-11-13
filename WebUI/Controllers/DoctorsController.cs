using Data;
using Data.Infrastructure;
using DHTMLX.Common;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;
using Domain;
using Service.appointmentService;
using Service.DoctorServices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class DoctorsController : Controller
    {
        ServicesDoctor cs = new ServicesDoctor();
        static DatabaseFactory DBF = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(DBF);
        PiContext pc;
        // GET: Doctors
        ServiceAppointment APP = new ServiceAppointment();
        public ActionResult Index()
        {
            List<DocterModels> Doctors = new List<DocterModels>();
            foreach (var cm in cs.GetMany())
            {
                DocterModels c = new DocterModels();
                c.Id = cm.Id;
                c.FirstName = cm.FirstName;
                c.lastName = cm.lastName;
                c.birthDate = cm.birthDate;
                c.adress = cm.adress;
                c.ImageName = cm.ImageName;
                

                Doctors.Add(c);
            }
          
            return View( Doctors);
        }

        public JsonResult GetCountries()
        {
            List<DocterModels> Doctors = new List<DocterModels>();
            
            var countries = Doctors.Select(x => new { Id = x.speciality, Text = x.speciality }).Distinct();
            return Json(countries, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEmployees(string speciality)
        {
            
            List<DocterModels> Doctors = (from cm in cs.GetMany()
                                     where cm.speciality.ToString() == speciality
                                          select new DocterModels
                                          { Id = cm.Id,
            FirstName = cm.FirstName,
            lastName = cm.lastName,
            birthDate = cm.birthDate,
           adress = cm.adress,
           ImageName = cm.ImageName,
        }).ToList();
            return Json(Doctors, JsonRequestBehavior.AllowGet);
        }
        // GET: Doctors/Details/5


        private DHXScheduler ConfigureScheduler()
        {
           
            

            

            
            var scheduler = new DHXScheduler(this); //initializes dhtmlxScheduler
            scheduler.PreventCache();
            scheduler.LoadData = true;// allows loading data
            scheduler.EnableDataprocessor = true;// enables DataProcessor in order to enable implementation CRUD operations
            scheduler.Codebase = Url.Content("~/Scripts/dhtmlxScheduler"); //"dhtmlxScheduler";
            scheduler.Config.show_loading = true;
            scheduler.Height = 500;
            scheduler.Skin = DHXScheduler.Skins.Flat;
            scheduler.Config.first_hour = 9;
            scheduler.Config.last_hour = 17;
            var cal = scheduler.Calendars.AttachMiniCalendar();
            cal.Navigation = true;
            scheduler.EnableDynamicLoading(SchedulerDataLoader.DynamicalLoadingMode.Month);
            return scheduler;
        }
        public ContentResult Data(string id)
        {
           IEnumerable<Appointment> t= APP.GetMany();
            // var apps = t.Where(e =>e.IdAppointment.ToString().Equals(id).ToList();
            return new SchedulerAjaxData(t);

            



        }

        public ActionResult Save(int? id, FormCollection actionValues)
        {
            var action = new DataAction(actionValues);

            try
            {
                var changedEvent = DHXEventsHelper.Bind<Appointment>(actionValues);
                switch (action.Type)
                {
                    case DataActionTypes.Insert:
                        pc.Appointments.Add(changedEvent);
                        break;
                    case DataActionTypes.Delete:
                        pc.Entry(changedEvent).State = EntityState.Deleted;
                        break;
                    default:// "update"  
                        pc.Entry(changedEvent).State = EntityState.Modified;
                        break;
                }
                pc.SaveChanges();
                action.TargetId = changedEvent.AppointmentId;
            }
            catch (Exception a)
            {
                action.Type = DataActionTypes.Error;
            }

            return (new AjaxSaveResponse(action));
        }
   



    public ActionResult Details(string id)
        {
            var c = cs.GetMany();
            List<DocterModels> Doctors = new List<DocterModels>();
            foreach (var item in c)
            {
                // User.Identity.GetUserId()
                if (item.Id == id)
                {
                    Doctors.Add(
                     new DocterModels
                     {
                         Id = item.Id,
                         FirstName = item.FirstName,
                         lastName = item.lastName,
                         birthDate = item.birthDate,
                         adress = item.adress,
                         ImageName = item.ImageName


                     });
                }
            }

            
           
         
            return View(Doctors);
            
        }
       

        // GET: Doctors/Create
        public ActionResult Calendar_doc(string id)
        {
         
            var scheduler = ConfigureScheduler();

            scheduler.InitialDate = DateTime.Today;
            scheduler.Data.Loader.AddParameter("iddocter", id);
            return View(scheduler);
        }

        // POST: Doctors/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctors/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Doctors/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctors/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Doctors/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
