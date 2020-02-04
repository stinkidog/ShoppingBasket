using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketService.Models;
using BasketService.Repository.Interfaces;
using BasketService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace shopping_basket.Controllers
{
    [Route("api/[controller]")]
    public class BasketController : Controller
    {

        private IProductService _productService;
        private IDiscountService _discountService;
        private IBasketCalculator _basketCalculator;

        public BasketController(IProductService productService, IDiscountService discountService, IBasketCalculator basketCalculator)
        {
            _productService = productService;
            _discountService = discountService;
            _basketCalculator = basketCalculator;
        }

        [HttpGet("[action]")]
        public IEnumerable<Product> GetAllAvailableProducts()
        {
            return _productService.GetAllAvailableProducts();
        }

        [HttpGet("[action]")]
        public IEnumerable<GiftVoucher> GetAllAvailableGiftVouchers()
        {
            return _discountService.GetAllAvailableGiftVouchers();
        }

        [HttpGet("[action]")]
        public IEnumerable<OfferVoucher> GetAllAvailableOfferVouchers()
        {
            return _discountService.GetAllAvailableOfferVouchers();
        }
     
        [HttpPost("[action]")]
        public Basket ProcessBasket([FromBody] Basket basket)
        {
            return _basketCalculator.CalculateTotal(basket);
        }
    }
}
