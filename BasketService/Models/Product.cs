using BasketService.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasketService.Models
{
    public class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public ProductType ProductType { get; set; }

        public Product()
        {

        }
    }
}
