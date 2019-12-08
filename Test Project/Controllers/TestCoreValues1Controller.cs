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
    public class TestCoreValues1Controller : Controller
    {
        private MIS4200GroupContext db = new MIS4200GroupContext();

        // GET: TestCoreValues1
        public ActionResult Index()
        {
            var coreValues = db.TestCoreValues.Include(r => r.Employee);
            return View(db.TestCoreValues.ToList());
        }

        // GET: TestCoreValues1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var coreValues = db.TestCoreValues.Find(id);
            if (coreValues == null)
            {
                return HttpNotFound();
            }
            return View(coreValues);
        }

        // GET: TestCoreValues1/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.employees, "id", "fullName");
            string employeeId = User.Identity.GetUserId();
            SelectList employeeProfile = new SelectList(db.employees, "id", "fullName");
            employeeProfile = new SelectList(employeeProfile.Where(x => x.Value != employeeId).ToList(), "Value", "Text");
            ViewBag.coreId = employeeProfile;
            return View();
        }

        // POST: TestCoreValues1/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "valueId, description, valuesRecognized, id")] TestCoreValues testCoreValues)
        {
            if (ModelState.IsValid)
            {
                db.TestCoreValues.Add(testCoreValues);
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
                var employee = db.employees.Find(testCoreValues.ID);
                // then extract the email address from the customer record
                var employeeEmail = employee.email;
                // finally, add the email address to the “To” list
                myMessage.To.Add(employeeEmail);
                // note: it is possible to add more than one email address to the To list
                // it is also possible to add CC addresses
                myMessage.To.Add("ds028414@ohio.edu"); // this should be replaced with model data
                                                       // as shown at the end of this document
                myMessage.Subject = "Centric Recognition";
                // the body of the email is hard coded here but could be dynamically created using data
                // from the model- see the note at the end of this document
                myMessage.Body = "Congratulations! You have been recognized for embodying the core values established by Centric.";
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



           // return RedirectToAction("Index");
            

            ViewBag.id = new SelectList(db.employees, "id", "firstName", testCoreValues.ID);
            return View(testCoreValues);
        }

        // GET: TestCoreValues1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestCoreValues testCoreValues = db.TestCoreValues.Find(id);
            if (testCoreValues == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.employees, "id", "firstName", testCoreValues.ID);
            return View(testCoreValues);
        }

        // POST: TestCoreValues1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "valueId, description, valuesRecognized, id")] TestCoreValues testCoreValues)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testCoreValues).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.employees, "id", "firstName", testCoreValues.ID);
            return View(testCoreValues);
        }

        // GET: TestCoreValues1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestCoreValues testCoreValues = db.TestCoreValues.Find(id);
            if (testCoreValues == null)
            {
                return HttpNotFound();
            }
            return View(testCoreValues);
        }

        // POST: TestCoreValues1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestCoreValues testCoreValues = db.TestCoreValues.Find(id);
            db.TestCoreValues.Remove(testCoreValues);
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
