using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Domain;
using Microsoft.AspNet.Identity;
using Service.CourseSer;
using Service.PatientService;

namespace WebUI.Controllers
{
    public class PatController : Controller
    {
        private PiContext db = new PiContext();
      ServiceCourse SC = new ServiceCourse();
     //   ServicePatient SP = new ServicePatient();
        // GET: Pat
        public ActionResult Index()
        {
            return View(
                SC.GetMyPatients(User.Identity.GetUserId())
                );
        }

        // GET: Pat/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = (Patient)db.Users.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Pat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pat/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,lastName,birthDate,adress,ImageName,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Insuranceid")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patient);
        }
        // GET: Steps/Create
        public ActionResult CreateStep(string id)
        {
        //    int n = SC.CourseNotDone(id);
            return View(
                //"steps number"+n
                );
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStep(string id,[Bind(Include = "StepId,treatment,state")] Step step)
        {
          //  int n = SC.CourseNotDone(id);
            if (ModelState.IsValid)
            {
                Patient p = (Patient)db.Users.Find(id);
                Course c = db.Courses.Find(p.course.CourseId);
               
                step.course = c;
                db.Steps.Add(step);
               // c.steps.Add(step);
              
                //     SC.Update(c);
                db.Entry(c).State = EntityState.Modified;
                 // SC.Commit();
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(step );
        }
        // GET: Pat/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            Patient patient = (Patient)db.Users.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
            /*
             if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course c = SC.GetById(SP.GetById(User.Identity.GetUserId()).course.CourseId);

       //     Patient patient = (Patient)db.Users.Find(id);
            Patient patient = SP.GetById(User.Identity.GetUserId());
            if (ModelState.IsValid)
            {
                db.Steps.Add(step);
                c.steps.Add(step);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(step);
            */
        }

        // POST: Pat/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,lastName,birthDate,adress,ImageName,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Insuranceid")] Patient patient)
        {
            if (ModelState.IsValid)
            {

                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: Pat/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = (Patient)db.Users.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Pat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Patient patient = (Patient)db.Users.Find(id);
            db.Users.Remove(patient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
