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
    public class BrandController : Controller
    {
        private adtransferContext db = new adtransferContext();

        //
        // GET: /Brand/

        public ActionResult Index()
        {
            return View(db.Brands.ToList());
        }

        //
        // GET: /Brand/Details/5

        public ActionResult Details(int id = 0)
        {
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        //
        // GET: /Brand/Create

        public ActionResult Create()
        {
            PseudoBrand pBrand = new PseudoBrand();
            pBrand.agency = db.Agencies.ToList().Select(x => new SelectListItem
                             {
                                 Text = x.Name,
                                 Value = x.AgencyID.ToString()
                             }).AsEnumerable().ToList();

            pBrand.client = db.Clients.ToList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.ClientID.ToString()
            }).AsEnumerable().ToList();


            //pBrand.client = (from a in db.Clients
            //                 select new SelectListItem
            //                 {
            //                     Text = a.Name,
            //                     Value = a.ClientID.ToString()
            //                 }).AsNoTracking().ToList();

            //pBrand.client = (from a in db.Set<Client>()
            //                 where a.ClientID > 0
            //                 select new SelectListItem
            //                 {
            //                     Text = a.Name,
            //                     Value = a.ClientID.ToString()
            //                 }).AsNoTracking().ToList();

            return View(pBrand);
        }

        //
        // POST: /Brand/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Brands.Add(brand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(brand);
        }

        //
        // GET: /Brand/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        //
        // POST: /Brand/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brand);
        }

        //
        // GET: /Brand/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        //
        // POST: /Brand/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Brand brand = db.Brands.Find(id);
            db.Brands.Remove(brand);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult GetClientDetail(int clientID, int type )
        {
            var brandManagers = (from b in db.Set<BrandManager>()
                                 where (b.ClientID == clientID) && (b.type == type) && (b.Status == true)
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

            return Json(brandManagers, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}