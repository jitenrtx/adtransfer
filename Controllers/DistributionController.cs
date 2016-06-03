using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using adtransfer.Models;

namespace adtransfer.Controllers
{
    public class DistributionController : Controller
    {
        private adtransferContext db = new adtransferContext();

        //
        // GET: /Distribution/

        public ActionResult Index()
        {
            return View(db.Distributions.ToList());
        }

        //
        // GET: /Distribution/Details/5

        public ActionResult Details(int id = 0)
        {
            Distribution distribution = db.Distributions.Find(id);
            if (distribution == null)
            {
                return HttpNotFound();
            }
            return View(distribution);
        }

        //
        // GET: /Distribution/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Distribution/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Distribution distribution)
        {
            if (ModelState.IsValid)
            {
                db.Distributions.Add(distribution);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(distribution);
        }

        //
        // GET: /Distribution/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Distribution distribution = db.Distributions.Find(id);
            if (distribution == null)
            {
                return HttpNotFound();
            }
            return View(distribution);
        }

        //
        // POST: /Distribution/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Distribution distribution)
        {
            if (ModelState.IsValid)
            {
                db.Entry(distribution).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(distribution);
        }

        //
        // GET: /Distribution/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Distribution distribution = db.Distributions.Find(id);
            if (distribution == null)
            {
                return HttpNotFound();
            }
            return View(distribution);
        }

        //
        // POST: /Distribution/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Distribution distribution = db.Distributions.Find(id);
            db.Distributions.Remove(distribution);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}