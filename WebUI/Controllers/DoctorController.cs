using Data;
using Domain;
using Service.docteur;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class DoctorController : Controller
    {
        DocteurService ds=new DocteurService();
    //    SpecialityService sp = new SpecialityService();
        PiContext db = new PiContext();
        
        // GET: Doctor
        public ActionResult Index()
        {
            //var doctorsAll = ds.GetMany();
            //return View(doctorsAll);
            var doctorsAll = ds.GetDoctorsByEmail(AccountController.UserConnecte);
            return View(doctorsAll);
            //var req=db.
        }
        [HttpPost]
        public ActionResult Index(String searchString)
        {
            var doctorSearched = ds.GetMany(p => p.FirstName.Contains(searchString));
            return View(doctorSearched);
        }

        // GET: Doctor/Details/5
        public ActionResult Details(String id)
        {
            if (id == null)
           {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
            Doctor d = ds.GetDOctorByid(id);
            if (d == null)
           {
                return HttpNotFound();
           }

            return View(d);
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            //DoctorModel d = new DoctorModel();
            //d.Specialities = sp.GetMany().Select(s => new SelectListItem
            //{
            //   Text=s.nomSpeciality,
            //    Value = s.SpecialityId.ToString()

            //});
            return View();
        }

        // POST: Doctor/Create
        [HttpPost]
        public ActionResult Create(DoctorModel dm, HttpPostedFileBase image)
        {
            dm.ImageName = image.FileName;
            try
            {

                Doctor d = new Doctor
                {



                
                    FirstName = dm.FirstName,
                    lastName = dm.lastName,
                    adress=dm.adress,
                    birthDate=dm.birthDate,
                    ImageName=dm.ImageName,
                //    SpecialityId=dm.SpecialityId,
                    UserName = dm.UserName,
                    Email = dm.Email,
                    EmailConfirmed = true,
                    PasswordHash = dm.PasswordHash,
                    SecurityStamp = dm.SecurityStamp,
                    PhoneNumber = dm.PhoneNumber,
                    PhoneNumberConfirmed = true,
                   TwoFactorEnabled = true,
                    LockoutEnabled = true,
                    LockoutEndDateUtc = dm.LockoutEndDateUtc,
                    AccessFailedCount = dm.AccessFailedCount,
                 




                };
              
                ds.Add(d);
                ds.Commit();
                var path = Path.Combine(Server.MapPath("~/Content/Upload/"), image.FileName);
                image.SaveAs(path);
             
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctor/Edit/5
        public ActionResult Edit(String id)
        {
            // Doctor d = new Doctor();

            // d.Id.Equals(ds.GetById(id));
            // pclm.Status = "Treated";
            //d.Id == id;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor d = ds.GetById(id);
            if (d == null)
            {
                return HttpNotFound();
            }
            return View(d);
            
          
        }

        // POST: Doctor/Edit/5

        [HttpPost]
 
        public ActionResult Edit([Bind(Include = "Id,Email,PasswordHash,SecurityStamp,PhoneNumber, LockoutEndDateUtc,AccessFailedCount,UserName, FirstName,LastName,birthDate,adress,imageName,Speciality ")] Doctor d, HttpPostedFileBase Image)
        {
           
            //Doctor do= new Doctor();

                // TODO: Add update logic here
              
                if (ModelState.IsValid)
                {
                String fileName = Path.GetFileName(Image.FileName);
                d.ImageName = fileName;
                var doctor = ds.GetMany().Single(em => em.Id == d.Id);
                d.PasswordHash = doctor.PasswordHash;
                d.SecurityStamp = doctor.SecurityStamp;
                db.Entry(d).State = EntityState.Modified;
                  db.SaveChanges();
              

                //  ds.Update(d);
                //  ds.Commit();
                return RedirectToAction("Index");
                }
              //  return RedirectToAction("Index");
            
           
                return View(d);
            
        }

        // GET: Doctor/Delete/5
        public ActionResult Delete(String id)
        {
            //Doctor d = new Doctor();
            //d.Id.Equals(ds.GetById(id));
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor d = ds.GetById(id);
            if (d == null)
            {
                return HttpNotFound();
            }
            return View(d);

            
          
        }

        // POST: Doctor/Delete/5
        [HttpPost]
     
        public ActionResult Delete(String id, Doctor d)
        {
            try
            {
                // TODO: Add delete logic here

                //d.Id.Equals(ds.GetById(id));
                //ds.Delete(d);
                //ds.Commit();
                var req = ds.GetMany().Where(a => a.Id .Equals(id)).FirstOrDefault();
                ds.Delete(req);
                ds.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
