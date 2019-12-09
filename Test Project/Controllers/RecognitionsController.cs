using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test_Project.DAL;
using Test_Project.Models;
using System.Net.Mail;
using Microsoft.AspNet.Identity;

namespace Test_Project.Controllers
{
    [Authorize]
    public class RecognitionsController : Controller
    {
        private MIS4200GroupContext db = new MIS4200GroupContext();

        // GET: Recognitions
        public ActionResult Index()
        {
            var recognition = db.Recognition.Include(r => r.Profile);
            return View(recognition.ToList());
        }

        // GET: Recognitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var recognition = db.Recognition.Find(id);
            if (recognition == null)
            {
                return HttpNotFound();
            }

            return View(recognition);
        }

        // GET: Recognitions/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.Profile, "id", "firstName");
            string employeeID = User.Identity.GetUserId();
            SelectList profile = new SelectList(db.Profile, "id", "firstName");
            profile = new SelectList(profile.Where(x => x.Value != employeeID).ToList(), "Value", "Text");
            ViewBag.recognitionID = profile;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "recognitionID,description,values,id")] Recognition recognition)
        {
            if (ModelState.IsValid)
            {
                db.Recognition.Add(recognition);
                db.SaveChanges();
                SmtpClient myClient = new SmtpClient();
                // the following line has to contain the email address and password of someone
                // authorized to use the email server (you will need a valid Ohio account/password
                // for this to work)
                myClient.Credentials = new NetworkCredential("AuthorizedUser", "UserPassword");
                MailMessage myMessage = new MailMessage();
                // the syntax here is email address, username (that will appear in the email)
                MailAddress from = new MailAddress("ds028414@ohio.edu", "SysAdmin");
                myMessage.From = from;
                // first, the customer found in the order is used to locate the customer record
                var profile = db.Profile.Find(recognition.id);
                // then extract the email address from the customer record
                var profileEmail = profile.email;
                // finally, add the email address to the “To” list
                myMessage.To.Add(profileEmail);
                // note: it is possible to add more than one email address to the To list
                // it is also possible to add CC addresses
                myMessage.To.Add("ds028414@ohio.edu"); // this should be replaced with model data
                                                       // as shown at the end of this document
                myMessage.Subject = "Centric Recognition";
                // the body of the email is hard coded here but could be dynamically created using data
                // from the model- see the note at the end of this document
                myMessage.Body = "You have received recognition points from a coworker! Congratulations, that's pretty cool!";
                try
                {
                    myClient.Send(myMessage);
                    TempData["mailError"] = "";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // this captures an Exception and allows you to display the message in the View
                    TempData["mailError"] = ex.Message;
                }

            }
            // return View();
            ViewBag.id = new SelectList(db.Profile, "id", "firstName", recognition.id);
            return View(recognition);
        }

        // GET: Recognitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognition recognition = db.Recognition.Find(id);
            if (recognition == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.Profile, "id", "firstName", recognition.id);
            return View(recognition);
        }

        // POST: Recognitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "recognitionID,description,values,id")] Recognition recognition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recognition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.Profile, "id", "firstName", recognition.id);
            return View(recognition);
        }

        // GET: Recognitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognition recognition = db.Recognition.Find(id);
            if (recognition == null)
            {
                return HttpNotFound();
            }
            return View(recognition);
        }

        // POST: Recognitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recognition recognition = db.Recognition.Find(id);
            db.Recognition.Remove(recognition);
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
