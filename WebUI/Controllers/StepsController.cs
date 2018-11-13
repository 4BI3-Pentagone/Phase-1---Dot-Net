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

namespace WebUI.Controllers
{
    public class StepsController : Controller
    {
        private PiContext db = new PiContext();

        // GET: Steps
        public ActionResult Index()
        {
            return View(db.Steps.ToList());
        }

        // GET: Steps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Step step = db.Steps.Find(id);
            if (step == null)
            {
                return HttpNotFound();
            }
            return View(step);
        }

        // GET: Steps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Steps/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StepId,treatment,state")] Step step)
        {
            if (ModelState.IsValid)
            {
                db.Steps.Add(step);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(step);
        }

        // GET: Steps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Step step = db.Steps.Find(id);
            if (step == null)
            {
                return HttpNotFound();
            }
            return View(step);
        }

        // POST: Steps/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StepId,treatment,state")] Step step)
        {
            if (ModelState.IsValid)
            {
                db.Entry(step).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(step);
        }

        // GET: Steps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Step step = db.Steps.Find(id);
            if (step == null)
            {
                return HttpNotFound();
            }
            return View(step);
        }

        // POST: Steps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Step step = db.Steps.Find(id);
            db.Steps.Remove(step);
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
