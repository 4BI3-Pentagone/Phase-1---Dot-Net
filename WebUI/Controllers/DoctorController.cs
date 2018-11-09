using Domain;
using Service.docteur;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class DoctorController : Controller
    {
        DocteurService ds=new DocteurService();
        SpecialityService sp = new SpecialityService();
        // GET: Doctor
        public ActionResult Index()
        {
            var doctorsAll = ds.GetMany();
            return View(doctorsAll);
        }
        [HttpPost]
        public ActionResult Index(String searchString)
        {
            var doctorSearched = ds.GetMany(p => p.FirstName.Contains(searchString));
            return View(doctorSearched);
        }

        // GET: Doctor/Details/5
        public ActionResult Details(int id)
        {
          
            return View();
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
                    birthDate = dm.birthDate,
                    adress = dm.adress,
                  //  speciality=dm.speciality
                  //nomSpeciality=dm.nomSpeciality
                SpecialityId=dm.SpecialityId,
                ImageName=dm.ImageName
                  
                    
                };
                // prod.Add(p);
                // Session["Produits"] = prod;
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
        public ActionResult Edit(int id)
        {
             Doctor d = new Doctor();

            d.Id.Equals(ds.GetById(id));
            // pclm.Status = "Treated";
            //d.Id == id;
            return View();
            
          
        }

        // POST: Doctor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Doctor d)
        {
            try
            {

                // TODO: Add update logic here
               d.Id.Equals(ds.GetById(id));

               //d. FirstName = ds.FirstName,
               //   d. lastName = ds.lastName,
               //    d. birthDate = ds.birthDate,
               //    d. adress = ds.adress,
               //    d. speciality = ds.speciality
                ds.Update(d);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctor/Delete/5
        public ActionResult Delete(int id)
        {
            Doctor d = new Doctor();
            d.Id.Equals(ds.GetById(id));
            return View();

            
          
        }

        // POST: Doctor/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Doctor d)
        {
            try
            {
                // TODO: Add delete logic here
          
                d.Id.Equals(ds.GetById(id));
                ds.Delete(d);
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
