using BasketService.Enums;
using BasketService.Factories;
using BasketService.Models;
using BasketService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasketService.Repository
{
    public class ProductRepo : IProductRepo
    {
        public ProductRepo()
        {

        }

        //This would be some ORM (likely dapper) to access products stored in a DB
        //For the purposes of this task, I have just stubbed what I would expect
        public List<Product> GetAllAvailableProducts()
        {
            ProductFactory prodFactory = new ProductFactory();

            return new List<Product>()
            {
                prodFactory.GenerateProduct(ProductEnum.CheapHat),
                prodFactory.GenerateProduct(ProductEnum.ExpensiveHat),
                prodFactory.GenerateProduct(ProductEnum.CheapJumper),
                prodFactory.GenerateProduct(ProductEnum.ExpensiveJumper),
                prodFactory.GenerateProduct(ProductEnum.HeadLight),
                prodFactory.GenerateProduct(ProductEnum.Voucher30Pounds)
            };
        }
    }
}
