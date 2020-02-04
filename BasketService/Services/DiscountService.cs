using BasketService.Models;
using BasketService.Repository;
using BasketService.Repository.Interfaces;
using BasketService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasketService.Services
{
    public class DiscountService : IDiscountService
    {
        private IDiscountRepo _discountRepo;

        public DiscountService()
        {
            _discountRepo = new DiscountRepo();
        }

        public DiscountService(IDiscountRepo discountRepo)
        {
            _discountRepo = discountRepo;
        }

        public List<GiftVoucher> GetAllAvailableGiftVouchers()
        {
            return _discountRepo.GetAllAvailableGiftVouchers();
        }

        public List<OfferVoucher> GetAllAvailableOfferVouchers()
        {
            return _discountRepo.GetAllAvailableOfferVouchers();
        }
    }
}
