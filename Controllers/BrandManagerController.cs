using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using adtransfer.Models;
using System.Web.Routing;
using System.Text;
using Component;
using System.IO;

namespace adtransfer.Controllers
{
    public class BrandManagerController : Controller
    {
        private adtransferContext db = new adtransferContext();

        //
        // GET: /BrandManager/

        public ActionResult Index(int id = 1, int type = 1)
        {
            var brandManagers = (from b in db.Set<BrandManager>()
                                 where (b.ClientID == id) && (b.type == type) && (b.Status == true)
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

            ViewBag.clientID = id;
            ViewBag.type = type;
            return View(brandManagers);
        }

        //
        // GET: /BrandManager/Details/5

        public ActionResult Details(int id = 0)
        {
            BrandManager brandmanager = db.BrandManagers.Find(id);
            if (brandmanager == null)
            {
                return HttpNotFound();
            }
            return View(brandmanager);
        }

        //
        // GET: /BrandManager/Create

        public ActionResult Create(int id = 0, int type = 0)
        {
            PseudoBrandManager brandManager = new PseudoBrandManager();
            brandManager.ClientID = id;
            brandManager.type = type;
            return View(brandManager);
        }

        //
        // POST: /BrandManager/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PseudoBrandManager brandmanager, string clientID)
        {
            if (ModelState.IsValid)
            {
                db.BrandManagers.Add(brandmanager.GetBrandManager());
                db.SaveChanges();
                SendMail(brandmanager);
                return RedirectToAction("Index", new { Id = brandmanager.ClientID, type = brandmanager.type });
            }

            return View(brandmanager);
        }

        //
        // GET: /BrandManager/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BrandManager brandmanager = db.BrandManagers.Find(id);
            if (brandmanager == null)
            {
                return HttpNotFound();
            }
            return View(brandmanager);
        }

        //
        // POST: /BrandManager/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PseudoBrandManager psbrandmanager)
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
                BrandManager brandmanager = psbrandmanager.GetBrandManager();
                brandmanager.Status = true;
                db.Entry(brandmanager).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index", new RouteValueDictionary(new { controller = "BrandManager", action = "Index", Id = brandmanager.ClientID }));
                return RedirectToAction("Index", new { Id = brandmanager.ClientID, type = brandmanager.type });
            }

            return View(psbrandmanager);
        }

        public ActionResult Inactivate(int id = 0)
        {
            BrandManager brandmanager = db.BrandManagers.Find(id);
            brandmanager.Status = false;
            db.Entry(brandmanager).State = EntityState.Modified;
            db.SaveChanges();
            //return RedirectToAction("Index", new RouteValueDictionary(new { controller = "BrandManager", action = "Index", Id = brandmanager.ClientID }));
            TempData["success"] = brandmanager.Name + " is Inactive Now!!";
            return RedirectToAction("Index", new { Id = brandmanager.ClientID, type = brandmanager.type });
        }

        //
        // GET: /BrandManager/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BrandManager brandmanager = db.BrandManagers.Find(id);
            if (brandmanager == null)
            {
                return HttpNotFound();
            }
            return View(brandmanager);
        }

        //
        // POST: /BrandManager/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BrandManager brandmanager = db.BrandManagers.Find(id);
            db.BrandManagers.Remove(brandmanager);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public JsonResult GetBrandManagerDetail(int id)
        {
            BrandManager brandmanager = db.BrandManagers.Find(id);
            if (brandmanager == null)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
            return Json(brandmanager, JsonRequestBehavior.AllowGet);
        }

        public void SendMail(BrandManager brandManager)
        {
            string strPath = string.Empty;
            string url = string.Empty;
            EmailHelper emailHelper = new EmailHelper();
            emailHelper.FromAddress = new System.Net.Mail.MailAddress("info@adtransfer.com");
            emailHelper.AddToAddress(brandManager.Email);
            emailHelper.AddCcAddress("ravi.bhandari123@gmail.com");
            emailHelper.AddBccAddress("jitentx@gmail.com");

            string msgBody = string.Empty;
            try
            {
                emailHelper.Subject = "New Account Created";
                msgBody = "An User with following Credentials Created:<br />";
                msgBody += "<b>URL:</b> adtransfer.deshratna.com<br />";
                msgBody += "<b>User Name :</b>" + brandManager.Email + "<br />";
                msgBody += "<b>Password :</b>" + brandManager.Password + "<br />";

                emailHelper.Body = msgBody;
                emailHelper.SendMail(); //After sending email you can clear the session "UploadedFileList"
            }
            catch (Exception ex)
            {
                //Handle your errors. May be a server log file? Its up to you!
            }


        }

    }
}
