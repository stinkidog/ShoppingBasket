using BasketService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasketService.Services.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAllAvailableProducts();
    }
}
