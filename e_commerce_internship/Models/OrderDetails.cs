using e_commerce_internship.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_commerce_internship.Models
{
    public class OrderDetails
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderState OrderState { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string Sehir { get; set; }
        public string Semt { get; set; }
        public string PostaKodu { get; set; }
        public virtual List<OrderLineModel> OrderLines { get; set; }

    }
    public class OrderLineModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

    }
}