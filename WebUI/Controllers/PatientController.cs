using Data;
using Domain;
using Microsoft.AspNet.Identity;
using Service.PatientService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class PatientController : Controller
    {
        IServicePatient IPS;
       PiContext A;
       
        // GET: Patient
        public ActionResult AccueilPatient()
        {
            return View();
        }

        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
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

        // GET: Doctor/Edit/5
        public ActionResult Edit()
        {
            string id = User.Identity.GetUserId();
            // Doctor d = new Doctor();

            // d.Id.Equals(ds.GetById(id));
            // pclm.Status = "Treated";
            //d.Id == id;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            Patient P = IPS.getUserByID(id);
            if (P == null)
            {
                return HttpNotFound();
            }
            return View(P);


        }

        // POST: Doctor/Edit/5

        [HttpPost]

        public ActionResult Edit([Bind(Include = "Id,Email,PasswordHash,SecurityStamp,PhoneNumber, LockoutEndDateUtc,AccessFailedCount,UserName, FirstName,LastName,birthDate,adress,imageprofil,apropos ")] Patient P)
        {

            //Doctor do= new Doctor();

            // TODO: Add update logic here

            if (ModelState.IsValid)
            {
                
                A.Entry(P).State = EntityState.Modified;
                A.SaveChanges();


                //  ds.Update(d);
                //  ds.Commit();
                return RedirectToAction("Index");
            }
            //  return RedirectToAction("Index");


            return View(P);

        }



        // GET: Patient/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Patient/Delete/5
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
