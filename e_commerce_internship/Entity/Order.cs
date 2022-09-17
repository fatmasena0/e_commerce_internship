using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_commerce_internship.Entity
{
    public class Order
    {
        public int Id { get; set; } 
        public string OrderNumber { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderTime { get; set; }
        public OrderState OrderState { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public string Sehir { get; set; }
        public string Semt { get; set; }
        public string PostaKodu { get; set; }
        public virtual List<OrderLine> OrderLine { get; set; }
    }
    public class OrderLine
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }


    }
}