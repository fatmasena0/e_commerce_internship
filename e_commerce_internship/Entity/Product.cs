using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_commerce_internship.Entity
{
    public class Product
    {
        public int id { get; set; }
        public int categoryId { get; set; }
        public int price { get; set; }
        public int stock { get; set; }
        public bool isFeatured { get; set; }
        public string name { get; set; }
        public string kind { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string color { get; set; }
        public Category category { get; set; }
    }
}