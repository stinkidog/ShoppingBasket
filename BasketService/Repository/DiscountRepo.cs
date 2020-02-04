using BasketService.Enums;
using BasketService.Factories;
using BasketService.Models;
using BasketService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasketService.Repository
{
    public class DiscountRepo : IDiscountRepo
    {
        public DiscountRepo()
        {

        }

        //This would be some ORM (likely dapper) to access gift vouchers stored in a DB
        //For the purposes of this task, I have just stubbed what I would expect
        public List<GiftVoucher> GetAllAvailableGiftVouchers()
        {
            VoucherFactory voucherFactory = new VoucherFactory();

            return new List<GiftVoucher>()
            {
                (GiftVoucher)voucherFactory.GenerateVoucher(VouchersEnum.Gift_5PoundOff)
            };
        }

        //This would be some ORM (likely dapper) to access gift vouchers stored in a DB
        //For the purposes of this task, I have just stubbed what I would expect
        public List<OfferVoucher> GetAllAvailableOfferVouchers()
        {
            VoucherFactory voucherFactory = new VoucherFactory();

            return new List<OfferVoucher>()
            {
                (OfferVoucher)voucherFactory.GenerateVoucher(VouchersEnum.Offer_5PoundOffHeadgear_Threshold50),
                (OfferVoucher)voucherFactory.GenerateVoucher(VouchersEnum.Offer_5PoundOff_Threshold50)
            };
        }
    }
}
