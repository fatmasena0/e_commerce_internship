using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_commerce_internship.Entity
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Product> productList { get; set; }

    }
}