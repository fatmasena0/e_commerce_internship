using e_commerce_internship.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_commerce_internship.Models
{
    public class AdminOrder
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderTime { get; set; }
        public OrderState OrderState { get; set; }
        public int Count { get; set; } //UserOrder modelinden farklı olarak siparişlerin sayısını getirir.
    }
}