using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using e_commerce_internship.Entity;

namespace e_commerce_internship.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View(db.Products.Where(i=>i.isFeatured).ToList());
        }
        public ActionResult Search(string value)
        {
            //var temp = db.Products;
            if (!string.IsNullOrEmpty(value))
            {
                var temp = db.Products.Where(i => i.name.Contains(value) || i.description.Contains(value));
                return View(temp.ToList());
            }
            else return View(db.Products.ToList());
        }
        public ActionResult ProductDetails(int id)
        {
            return View(db.Products.Where(i=>i.id == id).FirstOrDefault());
        }
        public ActionResult Products()
        {
            return View(db.Products.ToList());
        }
        public ActionResult ProductList(int id)
        {
            return View(db.Products.Where(i=>i.categoryId == id).ToList());
        }
        public ActionResult ProductKindList(int id, string type)
        {
            return View(db.Products.Where(i => i.categoryId == id && i.kind == type).ToList());
        }

    }
}