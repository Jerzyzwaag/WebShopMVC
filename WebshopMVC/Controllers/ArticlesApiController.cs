using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebshopMVC.Models;

namespace WebshopMVC.Controllers
{
    public class ArticlesApiController : ApiController
    {
        private WebshopEntities db = new WebshopEntities();

        [HttpGet]
        [Route("articleApi/sort/")]
        public IQueryable<Article> sortedArticles(string sortOrder, string sortOn)
        {
            var articles = db.Articles.Include(a => a.Category).Include(a => a.Supplier);
            //if the sortorder is asc & sorton is price: do orderby Price else do orderby Name
            //else if sortorder is desc sorton is price: do orderbydescending Price else do orderbydescending Name
            articles = (sortOrder.Equals("asc")) ?
                articles = (sortOn.Equals("Price")) ?
                    articles.OrderBy(a => a.Price) : articles.OrderBy(a => a.Name)
                    : articles = (sortOn.Equals("Price")) ?
                    articles.OrderByDescending(a => a.Price) : articles.OrderByDescending(a => a.Name);

            return articles;
        }


        [HttpPost]
        [Route("articleApi/category/")]
        public IQueryable<Article> categoryArticles(string categoryId)
        {
            Debug.WriteLine(categoryId);
            var articles = db.Articles.Where(a => a.CategoryID.ToString() == categoryId).Include(a => a.Category).Include(a => a.Supplier).OrderBy(a => a.Name);
            return articles;
        }

        [HttpPost]
        [Route("articleApi/search/")]
        public IQueryable<Article> searchedArticles(string searchTerm)
        {
            Debug.WriteLine(searchTerm);
            var articles = db.Articles.Where(a => a.Name.Contains(searchTerm)).Include(a => a.Category).Include(a => a.Supplier).OrderBy(a => a.Name);
            foreach (var article in articles)
            {
                Debug.WriteLine(article.Name);
            }
            return articles;
        }

    }
}