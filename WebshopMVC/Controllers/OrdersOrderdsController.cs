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
    public class OrdersOrderdsController : Controller
    {
        private WebshopEntities db = new WebshopEntities();

        // GET: OrdersOrderds
        public ActionResult Index()
        {
            var ordersOrderds = db.OrdersOrderds.Include(o => o.Article).Include(o => o.OrderOrderdInvoice);
            return View(ordersOrderds.ToList());
        }

        // GET: OrdersOrderds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdersOrderd ordersOrderd = db.OrdersOrderds.Find(id);
            if (ordersOrderd == null)
            {
                return HttpNotFound();
            }
            return View(ordersOrderd);
        }

        // GET: OrdersOrderds/Create
        public ActionResult Create()
        {
            ViewBag.ArticleID = new SelectList(db.Articles, "ID", "Name");
            ViewBag.OrderID = new SelectList(db.OrderOrderdInvoices, "ID", "ID");
            return View();
        }

        // POST: OrdersOrderds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,ArticleID,Amount")] OrdersOrderd ordersOrderd)
        {
            if (ModelState.IsValid)
            {
                db.OrdersOrderds.Add(ordersOrderd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArticleID = new SelectList(db.Articles, "ID", "Name", ordersOrderd.ArticleID);
            ViewBag.OrderID = new SelectList(db.OrderOrderdInvoices, "ID", "ID", ordersOrderd.OrderID);
            return View(ordersOrderd);
        }

        // GET: OrdersOrderds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdersOrderd ordersOrderd = db.OrdersOrderds.Find(id);
            if (ordersOrderd == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleID = new SelectList(db.Articles, "ID", "Name", ordersOrderd.ArticleID);
            ViewBag.OrderID = new SelectList(db.OrderOrderdInvoices, "ID", "ID", ordersOrderd.OrderID);
            return View(ordersOrderd);
        }

        // POST: OrdersOrderds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,ArticleID,Amount")] OrdersOrderd ordersOrderd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordersOrderd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArticleID = new SelectList(db.Articles, "ID", "Name", ordersOrderd.ArticleID);
            ViewBag.OrderID = new SelectList(db.OrderOrderdInvoices, "ID", "ID", ordersOrderd.OrderID);
            return View(ordersOrderd);
        }

        // GET: OrdersOrderds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdersOrderd ordersOrderd = db.OrdersOrderds.Find(id);
            if (ordersOrderd == null)
            {
                return HttpNotFound();
            }
            return View(ordersOrderd);
        }

        // POST: OrdersOrderds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdersOrderd ordersOrderd = db.OrdersOrderds.Find(id);
            db.OrdersOrderds.Remove(ordersOrderd);
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
