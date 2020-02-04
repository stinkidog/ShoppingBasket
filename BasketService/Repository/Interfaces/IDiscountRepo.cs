using BasketService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasketService.Repository.Interfaces
{
    public interface IDiscountRepo
    {
        List<GiftVoucher> GetAllAvailableGiftVouchers();
        List<OfferVoucher> GetAllAvailableOfferVouchers();
    }
}
