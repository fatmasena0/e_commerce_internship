using e_commerce_internship.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_commerce_internship.Models
{
    public class Cart
    {
        private List<CartLine> _cartLines = new List<CartLine>();
        public List<CartLine> CartLines
        {
            get { return _cartLines; }
        }
        //Sepete Ürün Ekleme
        public void AddProduct(Product product, int quantity)
        {
            var line = _cartLines.FirstOrDefault(i => i.Product.id == product.id);
            if (line == null)
            {
                _cartLines.Add(new CartLine() { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        //Sepetten Ürün Silme
        public void DeleteProduct(Product product)
        {
            _cartLines.RemoveAll(i => i.Product.id == product.id);
        }

        //Sepetteki ürünlerin toplam fiyatını hesaplama
        public double TotalPrice()
        {
            return _cartLines.Sum(i => i.Product.price * i.Quantity);
        }

        //Sepeti Temizleme
        public void Clear()
        {
            _cartLines.Clear();
        }

    }
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}