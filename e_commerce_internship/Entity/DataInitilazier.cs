using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace e_commerce_internship.Entity
{
    public class DataInitilazier : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var categories = new List<Category>()
            {
                new Category() {id=1, name = "Tespih" },
                new Category() {id=2, name = "Takı" },
            };
            foreach (var item in categories)
            {
                context.Categories.Add(item);  //Listedeki tüm elemanları contexte ekledi
            }
            context.SaveChanges();

            var products = new List<Product>()
            {
                new Product()
                {
                    name = "33lük Beyaz Tespih",
                    description = "El emeği 33lük beyaz tespih.",
                    price = 55,
                    stock = 12,
                    categoryId = 1,
                    isFeatured = true,
                    image = "beyaz33.jpg",
                    kind = "otuzuc",
                    color = "beyaz"
                },
                new Product()
                {
                    name = "99luk Beyaz Tespih",
                    description = "El emeği 99luk beyaz tespih.",
                    price = 120,
                    stock = 5,
                    categoryId = 1,
                    isFeatured = false,
                    image = "beyaz99.jpg",
                    kind = "doksandokuz",
                    color = "beyaz"
                },
                new Product()
                {
                    name = "33lük Mavi Tespih",
                    description = "El emeği 33lük mavi tespih.",
                    price = 50,
                    stock = 7,
                    categoryId = 1,
                    isFeatured = true,
                    image = "mavi33.jpg",
                    kind = "otuzuc",
                    color = "mavi"
                },
                new Product()
                {
                    name = "Beyaz taşlı kolye",
                    description = "Bronz zincirli, damla lülataşı ile tasarlanmış kolye.",
                    price = 75,
                    stock = 2,
                    categoryId = 2,
                    isFeatured = true,
                    image = "beyazkolye.jpg",
                    kind = "kolye",
                    color = "beyaz"
                }
            };
            foreach (var item in products)
            {
                context.Products.Add(item);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}