using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.Entities.Models;

namespace Web.Entities.Controllers
{
    public class InvoiceDetailsController : Controller
    {
        private Context db = new Context();

        // GET: InvoiceDetails
        public ActionResult Index()
        {
            var invoiceDetails = db.InvoiceDetails.Include(i => i.Charge).Include(i => i.Invoice);
            return View(invoiceDetails.ToList());
        }

        // GET: InvoiceDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceDetails invoiceDetails = db.InvoiceDetails.Find(id);
            if (invoiceDetails == null)
            {
                return HttpNotFound();
            }
            return View(invoiceDetails);
        }

        // GET: InvoiceDetails/Create
        public ActionResult Create()
        {
            ViewBag.ChargeId = new SelectList(db.SifCharges, "Id", "ChargeName");
            ViewBag.InvoiceId = new SelectList(db.Invoices, "Id", "InvoiceNumber");
            return View();
        }

        // POST: InvoiceDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,InvoiceId,ChargeId,Rate,Units,Tax")] InvoiceDetails invoiceDetails)
        {
            if (ModelState.IsValid)
            {
                db.InvoiceDetails.Add(invoiceDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChargeId = new SelectList(db.SifCharges, "Id", "ChargeName", invoiceDetails.ChargeId);
            ViewBag.InvoiceId = new SelectList(db.Invoices, "Id", "InvoiceNumber", invoiceDetails.InvoiceId);
            return View(invoiceDetails);
        }

        // GET: InvoiceDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceDetails invoiceDetails = db.InvoiceDetails.Find(id);
            if (invoiceDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChargeId = new SelectList(db.SifCharges, "Id", "ChargeName", invoiceDetails.ChargeId);
            ViewBag.InvoiceId = new SelectList(db.Invoices, "Id", "InvoiceNumber", invoiceDetails.InvoiceId);
            return View(invoiceDetails);
        }

        // POST: InvoiceDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,InvoiceId,ChargeId,Rate,Units,Tax")] InvoiceDetails invoiceDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoiceDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChargeId = new SelectList(db.SifCharges, "Id", "ChargeName", invoiceDetails.ChargeId);
            ViewBag.InvoiceId = new SelectList(db.Invoices, "Id", "InvoiceNumber", invoiceDetails.InvoiceId);
            return View(invoiceDetails);
        }

        // GET: InvoiceDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceDetails invoiceDetails = db.InvoiceDetails.Find(id);
            if (invoiceDetails == null)
            {
                return HttpNotFound();
            }
            return View(invoiceDetails);
        }

        // POST: InvoiceDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvoiceDetails invoiceDetails = db.InvoiceDetails.Find(id);
            db.InvoiceDetails.Remove(invoiceDetails);
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
