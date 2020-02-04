using BasketService.Enums;
using BasketService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasketService.Factories
{
    public class VoucherFactory
    {
        public VoucherFactory()
        {

        }

        public Voucher GenerateVoucher(VouchersEnum voucher)
        {
            switch (voucher)
            {
                case VouchersEnum.Gift_5PoundOff:
                    return new GiftVoucher() { Name = "£5 Off", Value = 5.00m };

                case VouchersEnum.Offer_5PoundOffHeadgear_Threshold50:
                    return new OfferVoucher() { Name = "£5 Off Headgear (Threshold £50)", Value = 5.00m, Threshold = 50.00m, ApplicableProductTypes = new List<ProductType>() { ProductType.HeadGear } };

                case VouchersEnum.Offer_5PoundOff_Threshold50:
                    return new OfferVoucher() { Name = "£5 off Basket (Threshold £50)", Value = 5.00m, Threshold = 50.00m, ApplicableProductTypes = new List<ProductType>() { ProductType.Hat, ProductType.Jumper, ProductType.HeadGear } };
            }

            return null;
        }
    }
}
