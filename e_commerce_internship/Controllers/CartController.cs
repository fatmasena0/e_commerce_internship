using e_commerce_internship.Entity;
using e_commerce_internship.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_commerce_internship.Controllers
{
    public class CartController : Controller
    {
        DataContext db = new DataContext(); //Veri tabanına bağlantı
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }

        private void SaveOrder(Cart cart, ShippingDetails model)
        {
            var order = new Order();
            order.OrderNumber = "A" + (new Random()).Next(1111, 9999).ToString();
            order.TotalPrice = cart.TotalPrice();
            order.OrderTime = DateTime.Now;
            order.OrderState = OrderState.Bekleniyor;
            order.Username = User.Identity.Name;
            order.Address = model.Address;
            order.Sehir = model.Sehir;
            order.Semt = model.Semt;
            order.PostaKodu = model.PostaKodu;
            order.OrderLine = new List<OrderLine>();
            foreach (var item in cart.CartLines)
            {
                var orderline = new OrderLine();
                orderline.Quantity = item.Quantity;
                orderline.Price = item.Quantity * item.Product.price;
                orderline.ProductId = item.Product.id;
                order.OrderLine.Add(orderline);
            }
            db.Orders.Add(order);
            db.SaveChanges();
        }

        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetails model)
        {
            var cart = GetCart();
            
            if (ModelState.IsValid)
            {
                SaveOrder(cart, model);
                cart.Clear();
                return View("ShippingCompleted");
            }
            else
            {
                return View(model);
            }
        }

        public PartialViewResult CartPartial()
        {
            return PartialView(GetCart());
        }

        public ActionResult RemoveFromCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.id == Id);

            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }
            return RedirectToAction("Index");
        }
        public ActionResult AddToCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.id == Id);

            if (product != null)
            {
                GetCart().AddProduct(product, 1);
            }
            return RedirectToAction("Index");
        }

        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }


    }
}