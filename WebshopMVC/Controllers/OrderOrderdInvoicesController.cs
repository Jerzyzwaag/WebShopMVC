using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebshopMVC.Models;

namespace WebshopMVC.Controllers
{
    public class OrderOrderdInvoicesController : Controller
    {
        private WebshopEntities db = new WebshopEntities();

        // GET: OrderOrderdInvoices
        public ActionResult Index()
        {
            var orderOrderdInvoices = db.OrderOrderdInvoices.Include(o => o.Supplier);
            return View(orderOrderdInvoices.ToList());
        }

        // GET: OrderOrderdInvoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderOrderdInvoice orderOrderdInvoice = db.OrderOrderdInvoices.Find(id);
            if (orderOrderdInvoice == null)
            {
                return HttpNotFound();
            }
            return View(orderOrderdInvoice);
        }

        // GET: OrderOrderdInvoices/Create
        public ActionResult Create()
        {
            ViewBag.SupplierID = new SelectList(db.Suppliers, "ID", "Name");
            return View();
        }

        // POST: OrderOrderdInvoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SupplierID")] OrderOrderdInvoice orderOrderdInvoice)
        {
            if (ModelState.IsValid)
            {
                db.OrderOrderdInvoices.Add(orderOrderdInvoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SupplierID = new SelectList(db.Suppliers, "ID", "Name", orderOrderdInvoice.SupplierID);
            return View(orderOrderdInvoice);
        }

        // GET: OrderOrderdInvoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderOrderdInvoice orderOrderdInvoice = db.OrderOrderdInvoices.Find(id);
            if (orderOrderdInvoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupplierID = new SelectList(db.Suppliers, "ID", "Name", orderOrderdInvoice.SupplierID);
            return View(orderOrderdInvoice);
        }

        // POST: OrderOrderdInvoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SupplierID")] OrderOrderdInvoice orderOrderdInvoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderOrderdInvoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SupplierID = new SelectList(db.Suppliers, "ID", "Name", orderOrderdInvoice.SupplierID);
            return View(orderOrderdInvoice);
        }

        // GET: OrderOrderdInvoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderOrderdInvoice orderOrderdInvoice = db.OrderOrderdInvoices.Find(id);
            if (orderOrderdInvoice == null)
            {
                return HttpNotFound();
            }
            return View(orderOrderdInvoice);
        }

        // POST: OrderOrderdInvoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderOrderdInvoice orderOrderdInvoice = db.OrderOrderdInvoices.Find(id);
            db.OrderOrderdInvoices.Remove(orderOrderdInvoice);
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
