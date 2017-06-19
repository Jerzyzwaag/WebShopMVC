using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebshopMVC.Models;

namespace WebshopMVC.Controllers
{
    public class HomeController : Controller
    {
        private WebshopEntities db = new WebshopEntities();
        public ActionResult Index(string sortOrder, string searchTerm)
        {
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewBag.PriceSortParm = String.IsNullOrEmpty(sortOrder) ? "price_desc" : "";
            var articles = db.Articles.Include(a => a.Category).Include(a => a.Supplier).OrderBy(a => a.Name);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            //if (!String.IsNullOrEmpty(searchTerm))
            //{
            //    articles = articles.Where(s => s.Name.Contains(searchTerm));

            //}

            //switch (sortOrder)
            //{
            //    case "name_desc":
            //        articles = articles.OrderByDescending(a => a.Name);
            //        break;
            //    case "price_desc":
            //        articles = articles.OrderByDescending(a => a.Price);
            //        break;
            //    default:
            //        articles = articles.OrderBy(a => a.Name);
            //        break;
            //}

            return View(articles);
        }
        protected void Page_Load(object sender, EventArgs e)

        {
            //show();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}