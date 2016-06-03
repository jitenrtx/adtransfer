using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using adtransfer.Models;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Text;

namespace adtransfer.Controllers
{
    public class ClientController : Controller
    {
        private adtransferContext db = new adtransferContext();

        //
        // GET: /Client/

        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        //
        // GET: /Client/Details/5

        public ActionResult Details(int id = 0)
        {
            Client client = db.Clients.Find(id);

            var brandManagers = (from b in db.Set<BrandManager>()
                                 where b.ClientID == id && b.type == 1
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

            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.brandManagers = brandManagers;
            return View(client);
        }

        //
        // GET: /Client/Create

        public ActionResult Create()
        {

            return View();
        }

        //
        // POST: /Client/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                client.Status = "True";
                client.DateCreated = DateTime.Now;
                db.Clients.Add(client);
                db.SaveChanges();
                SentClientCreateEmail(client);
                return RedirectToAction("Index");
            }

            return View(client);
        }

        private void SentClientCreateEmail(Client client)
        {
        //    Component.EmailHelper objEmail = new Component.EmailHelper();
        //    StringBuilder strBody = new StringBuilder();
        //    strBody.Append("New Client Created:");
        //    strBody.Append("Name: " + client.Name );
        //    strBody.Append("Address: " + client.Address);
        //    strBody.Append("City: " + client.City);
        //    strBody.Append("Country: " + client.Country);

        //    StringBuilder fileNames = new StringBuilder();
        //    string strPath = string.Empty;
        //    string coType = IPODMT.common.IQuestConst.MessageStatus.Sent;
        //    string url = string.Empty;
        //    Component.EmailHelper emailHelper = new Component.EmailHelper();
        //    emailHelper.FromAddress = new System.Net.Mail.MailAddress(client.Email.Value.Trim());
        //    emailHelper.AddToAddress(txtEmailTo.Text.Trim());
        //    emailHelper.AddCcAddress(txtEmailCc.Text.Trim());
        //    emailHelper.AddBccAddress(txtEmailBcc.Text.Trim());
        //    Dictionary<int, KeyValuePair<string, string>> fileList = null;
        //    //Attaching files. Here I keep the values in a session
        //    fileList = (Dictionary<int, KeyValuePair<string, string>>)Session["UploadedFileList"];
        //    foreach (var item in fileList)
        //    {
        //        emailHelper.AddAttachment(item.Value.Key + item.Value.Value, EmailHelper.GetFileMimeType(item.Value.Value));
        //        FileInfo file = new FileInfo(item.Value.Key + item.Value.Value);
        //        fileNames.Append(item.Value.Value + "|" + file.Length.ToString() + ";");
        //    }
        //    string strAttachment = hdnAttachmentTemplate.Value;
        //    string msgBody = string.Empty;
        //    try
        //    {
        //        emailHelper.Subject = txtEmailSubject.Text.Trim();
        //        if (!string.IsNullOrEmpty(strAttachment) && fileList != null && fileList.Count > 0)
        //        {
        //            strAttachment = strAttachment.Replace("[flAttachment]", fileList.Count.ToString());
        //            msgBody = txtEmailBody.InnerText.Trim() + "<br/>" + strAttachment;
        //        }
        //        else
        //            msgBody = txtEmailBody.InnerText.Trim();// +"<br/>" + txtCustomerInfo.Text.Trim(); 
        //        msgBody = msgBody.Replace("[lbCustomerInfo]", txtCustomerInfo.Text.Trim());
        //        emailHelper.Body = msgBody;
        //        emailHelper.SendMail(); //After sending email you can clear the session "UploadedFileList"
        //    }
        //    catch (Exception)
        //    {
        //        //Handle your errors. May be a server log file? Its up to you!
        //    }

        }
        //
        // GET: /Client/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        //
        // POST: /Client/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PseudoClient psclient)
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
                Client client = psclient.GetClient();
                db.Entry(client).State = EntityState.Modified;
                //db.SaveChanges();
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                    {
                        // Get entry

                        DbEntityEntry entry = item.Entry;
                        string entityTypeName = entry.Entity.GetType().Name;

                        // Display or log error messages

                        foreach (DbValidationError subItem in item.ValidationErrors)
                        {
                            string message = string.Format("Error '{0}' occurred in {1} at {2}",
                                     subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                            Console.WriteLine(message);
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }

                return RedirectToAction("Index");
            }
            return View(psclient);
        }

        //
        // GET: /Client/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        //
        // POST: /Client/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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