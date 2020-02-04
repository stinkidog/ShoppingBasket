using BasketService.Models;
using BasketService.Repository;
using BasketService.Repository.Interfaces;
using BasketService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasketService.Services
{
    public class ProductService : IProductService
    {
        private IProductRepo _prodRepo;

        public ProductService()
        {
            _prodRepo = new ProductRepo();
        }

        public ProductService(IProductRepo productRepo)
        {
            _prodRepo = productRepo;
        }

        public List<Product> GetAllAvailableProducts()
        {
            return _prodRepo.GetAllAvailableProducts();
        }
    }
}
