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
    public class AgencyController : Controller
    {
        private adtransferContext db = new adtransferContext();

        //
        // GET: /Agency/

        public ActionResult Index()
        {
            return View(db.Agencies.ToList());
        }

        //
        // GET: /Agency/Details/5

        public ActionResult Details(int id = 0)
        {
            Agency agency = db.Agencies.Find(id);

            var brandManagers = (from b in db.Set<BrandManager>()
                                 where b.ClientID == id && b.type == 2
                                 select new PseudoBrandManager
                                 {
                                     BrandManagerID = b.BrandManagerID,
                                     ClientID = b.ClientID,
                                     Name = b.Name,
                                     Address = b.Address,
                                     City = b.City,
                                     Country = b.Country,
                                     PINCode = b.PINCode,
                                     Email = b.Email,
                                     Phone = b.Phone,
                                     State = b.State
                                 }).AsNoTracking().ToList();

            if (agency == null)
            {
                return HttpNotFound();
            }
            ViewBag.brandManagers = brandManagers;
            return View(agency);
        }

        //
        // GET: /Agency/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Agency/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Agency agency)
        {
            if (ModelState.IsValid)
            {
                db.Agencies.Add(agency);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agency);
        }

        //
        // GET: /Agency/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Agency agency = db.Agencies.Find(id);
            if (agency == null)
            {
                return HttpNotFound();
            }
            return View(agency);
        }

        //
        // POST: /Agency/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Agency agency)
        {
            var restButton = Request.Params.AllKeys.FirstOrDefault(key => key.StartsWith("Reset"));
            if (!String.IsNullOrEmpty(restButton))
            {
                //client = db.Clients.Find(client.ClientID);
                //RedirectToAction("Edit", "Client");
                return Redirect(Request.UrlReferrer.ToString());
            }
            else if (ModelState.IsValid)
            {
                db.Entry(agency).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agency);
        }

        //
        // GET: /Agency/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Agency agency = db.Agencies.Find(id);
            if (agency == null)
            {
                return HttpNotFound();
            }
            return View(agency);
        }

        //
        // POST: /Agency/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agency agency = db.Agencies.Find(id);
            db.Agencies.Remove(agency);
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