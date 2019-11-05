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

namespace Test_Project.Controllers
{
    public class TestCoreValues1Controller : Controller
    {
        private MIS4200GroupContext db = new MIS4200GroupContext();

        // GET: TestCoreValues1
        public ActionResult Index()
        {
            return View(db.TestCoreValues.ToList());
        }

        // GET: TestCoreValues1/Details/5
        public ActionResult Details(int? id)
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

        // GET: TestCoreValues1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestCoreValues1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,award,recognizor,recognized,recognizationDate")] TestCoreValues testCoreValues)
        {
            if (ModelState.IsValid)
            {
                db.TestCoreValues.Add(testCoreValues);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
            return View(testCoreValues);
        }

        // POST: TestCoreValues1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,award,recognizor,recognized,recognizationDate")] TestCoreValues testCoreValues)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testCoreValues).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
