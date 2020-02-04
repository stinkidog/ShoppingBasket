using BasketService.Enums;
using BasketService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasketService.Factories
{
    public class ProductFactory
    {
        public ProductFactory()
        {

        }

        public Product GenerateProduct(ProductEnum product)
        {
            switch (product)
            {
                case ProductEnum.CheapHat:
                    return new Product() { Name = "Cheap Hat", Price = 10.50m, ProductType = ProductType.Hat };

                case ProductEnum.ExpensiveHat:
                    return new Product() { Name = "Expensive Hat", Price = 25.00m, ProductType = ProductType.Hat };

                case ProductEnum.CheapJumper:
                    return new Product() { Name = "Cheap Jumper", Price = 26.00m, ProductType = ProductType.Jumper };

                case ProductEnum.ExpensiveJumper:
                    return new Product() { Name = "Expensive Jumper", Price = 54.65m, ProductType = ProductType.Jumper };

                case ProductEnum.HeadLight:
                    return new Product() { Name = "Head Light", Price = 3.50m, ProductType = ProductType.HeadGear };

                case ProductEnum.Voucher30Pounds:
                    return new Product() { Name = "£30 Voucher", Price = 30.00m, ProductType = ProductType.Voucher };
            }

            return null;
        }
    } 
}
