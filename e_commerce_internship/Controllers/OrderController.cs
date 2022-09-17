using e_commerce_internship.Entity;
using e_commerce_internship.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_commerce_internship.Controllers
{
    //Bu controllera sadece admin olanlar erişebilecektir.
    public class OrderController : Controller
    {
        DataContext db = new DataContext();
        // GET: Order
        public ActionResult Index()
        {
            var orders = db.Orders.Select(i=>new AdminOrder() {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderTime = i.OrderTime,
                OrderState = i.OrderState,
                TotalPrice = i.TotalPrice,
                Count = i.OrderLine.Count
            }).OrderByDescending(i=>i.OrderTime).ToList();
            return View(orders);
        }

        public ActionResult Details(int id)
        {
            var model = db.Orders.Where(i=>i.Id == id).Select(i => new OrderDetails()
            {
                OrderId = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderTime,
                OrderState = i.OrderState,
                TotalPrice = i.TotalPrice,
                UserName = i.Username,
                Address = i.Address,
                Sehir = i.Sehir,
                Semt = i.Semt,
                PostaKodu = i.PostaKodu,
                OrderLines = i.OrderLine.Select(x => new OrderLineModel()
                {
                    ProductId = x.ProductId,
                    Image = x.Product.image,
                    ProductName = x.Product.name,
                    Quantity = x.Quantity,
                    Price = x.Price
                }).ToList()
            }).FirstOrDefault();
            return View(model);
        }

        public ActionResult UpdateOrderState(int orderid, OrderState orderstate)
        {
            var order = db.Orders.FirstOrDefault(i => i.Id == orderid);
            if (order != null)
            {
                order.OrderState = orderstate;
                db.SaveChanges();
                TempData["mesaj"] = "Sipariş durumu güncellendi.";
                return RedirectToAction("Details", new { id = orderid});
            }
            return RedirectToAction("Index");
        }

        public ActionResult PendingOrder()
        {
            var model = db.Orders.Where(i => i.OrderState == OrderState.Bekleniyor).ToList();
            return View(model);
        }
        public ActionResult ConfirmedOrder()
        {
            var model = db.Orders.Where(i => i.OrderState == OrderState.Onaylandı).ToList();
            return View(model);
        }
        public ActionResult PackedOrder()
        {
            var model = db.Orders.Where(i => i.OrderState == OrderState.Paketlendi).ToList();
            return View(model);
        }
        public ActionResult ShippedOrder()
        {
            var model = db.Orders.Where(i => i.OrderState == OrderState.Kargolandı).ToList();
            return View(model);
        }


    }
}