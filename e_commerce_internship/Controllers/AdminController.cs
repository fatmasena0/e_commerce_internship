using e_commerce_internship.Entity;
using e_commerce_internship.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_commerce_internship.Controllers
{
    public class AdminController : Controller
    {
        DataContext db = new DataContext();
        // GET: Admin
        public ActionResult Index()
        {
            StateModel model = new StateModel();
            model.PendingOrderNumber = db.Orders.Where(i => i.OrderState == OrderState.Bekleniyor).ToList().Count();
            model.ConfirmedOrderNumber = db.Orders.Where(i => i.OrderState == OrderState.Onaylandı).ToList().Count();
            model.PackedOrderNumber = db.Orders.Where(i => i.OrderState == OrderState.Paketlendi).ToList().Count();
            model.ShippedOrderNumber = db.Orders.Where(i => i.OrderState == OrderState.Kargolandı).ToList().Count();
            model.ProductNumber = db.Products.Count();
            model.OrderNumber = db.Orders.Count();
            return View(model);
        }

        public PartialViewResult Notification()
        {
            var notification = db.Orders.Where(i => i.OrderState == OrderState.Bekleniyor).ToList();
            return PartialView(notification);
        }
    }
}