using BasketService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasketService.Repository.Interfaces
{
    public interface IProductRepo
    {
        List<Product> GetAllAvailableProducts();
    }
}
