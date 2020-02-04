using BasketService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasketService.Services.Interfaces
{
    public interface IDiscountService
    {
        List<GiftVoucher> GetAllAvailableGiftVouchers();
        List<OfferVoucher> GetAllAvailableOfferVouchers();
    }
}
