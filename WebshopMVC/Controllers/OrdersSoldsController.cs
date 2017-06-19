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
    public class OrdersSoldsController : Controller
    {
        private WebshopEntities db = new WebshopEntities();
        public ActionResult Cart()
        {
            var ordersSolds = db.OrdersSolds.Where(o=>o.InBasket==1).Include(o => o.Article).Include(o => o.Customer);
            return View(ordersSolds);
        }
        // GET: OrdersSolds
        public ActionResult Index()
        {
            var ordersSolds = db.OrdersSolds.Include(o => o.Article).Include(o => o.Customer);
            return View(ordersSolds.ToList());
        }

        // GET: OrdersSolds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdersSold ordersSold = db.OrdersSolds.Find(id);
            if (ordersSold == null)
            {
                return HttpNotFound();
            }
            return View(ordersSold);
        }

        // GET: OrdersSolds/Create
        public ActionResult Create()
        {
            ViewBag.ArticleID = new SelectList(db.Articles, "ID", "Name");
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name");
            return View();
        }

        // POST: OrdersSolds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ArticleID,CustomerID,InBasket,Amount")] OrdersSold ordersSold)
        {
            if (ModelState.IsValid)
            {
                db.OrdersSolds.Add(ordersSold);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArticleID = new SelectList(db.Articles, "ID", "Name", ordersSold.ArticleID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", ordersSold.CustomerID);
            return View(ordersSold);
        }

        // GET: OrdersSolds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdersSold ordersSold = db.OrdersSolds.Find(id);
            if (ordersSold == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleID = new SelectList(db.Articles, "ID", "Name", ordersSold.ArticleID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", ordersSold.CustomerID);
            return View(ordersSold);
        }

        // POST: OrdersSolds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ArticleID,CustomerID,InBasket,Amount")] OrdersSold ordersSold)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordersSold).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArticleID = new SelectList(db.Articles, "ID", "Name", ordersSold.ArticleID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", ordersSold.CustomerID);
            return View(ordersSold);
        }

        // GET: OrdersSolds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdersSold ordersSold = db.OrdersSolds.Find(id);
            if (ordersSold == null)
            {
                return HttpNotFound();
            }
            return View(ordersSold);
        }

        // POST: OrdersSolds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdersSold ordersSold = db.OrdersSolds.Find(id);
            db.OrdersSolds.Remove(ordersSold);
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
