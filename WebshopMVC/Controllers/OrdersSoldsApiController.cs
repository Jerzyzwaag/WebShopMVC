using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebshopMVC.Models;

namespace WebshopMVC.Controllers
{
    public class OrdersSoldsApiController : ApiController
    {
        private WebshopEntities db = new WebshopEntities();

        [HttpPost]
        [Route("OrderSoldsApi/addToCart/")]
        public int addToCart(string articleId)
        {
            OrdersSold order = new OrdersSold();
            order.ArticleID = int.Parse(articleId);
            order.CustomerID = db.Customers.First().ID;
            order.InBasket = 1;
            order.Amount = 1;
            db.OrdersSolds.Add(order);
            db.SaveChanges();
            return db.OrdersSolds.Where(o => o.InBasket == 1).Count();
        }
        // DELETE: api/OrdersSoldsApi/5
        [ResponseType(typeof(OrdersSold))]
        public IHttpActionResult DeleteOrdersSold(int id)
        {
            OrdersSold ordersSold = db.OrdersSolds.Find(id);
            if (ordersSold == null)
            {
                return NotFound();
            }

            db.OrdersSolds.Remove(ordersSold);
            db.SaveChanges();

            return Ok(ordersSold);
        }
    }
}

        