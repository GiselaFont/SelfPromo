using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Selfie4.Data;
using WebApplication2.Data;

namespace Selfie4.Controllers
{
    public class JobhighlightsController : Controller
    {
        private DataModel db = new DataModel();

        // GET: Jobhighlights
        public ActionResult Index()
        {
            var jobhighlight = db.Jobhighlight.Include(j => j.Job);
            return View(jobhighlight.ToList());
        }

        // GET: Jobhighlights/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jobhighlight jobhighlight = db.Jobhighlight.Find(id);
            if (jobhighlight == null)
            {
                return HttpNotFound();
            }
            return View(jobhighlight);
        }

        // GET: Jobhighlights/Create
        public ActionResult Create()
        {
            ViewBag.JobId = new SelectList(db.Job, "Id", "Name");
            return View();
        }

        // POST: Jobhighlights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,JobId")] Jobhighlight jobhighlight)
        {
            if (ModelState.IsValid)
            {
                db.Jobhighlight.Add(jobhighlight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JobId = new SelectList(db.Job, "Id", "Name", jobhighlight.JobId);
            return View(jobhighlight);
        }

        // GET: Jobhighlights/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jobhighlight jobhighlight = db.Jobhighlight.Find(id);
            if (jobhighlight == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobId = new SelectList(db.Job, "Id", "Name", jobhighlight.JobId);
            return View(jobhighlight);
        }

        // POST: Jobhighlights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,JobId")] Jobhighlight jobhighlight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobhighlight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JobId = new SelectList(db.Job, "Id", "Name", jobhighlight.JobId);
            return View(jobhighlight);
        }

        // GET: Jobhighlights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jobhighlight jobhighlight = db.Jobhighlight.Find(id);
            if (jobhighlight == null)
            {
                return HttpNotFound();
            }
            return View(jobhighlight);
        }

        // POST: Jobhighlights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jobhighlight jobhighlight = db.Jobhighlight.Find(id);
            db.Jobhighlight.Remove(jobhighlight);
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
