using BasketService.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasketService.Models
{
    public class OfferVoucher : Voucher
    {
        public decimal Threshold { get; set; }

        public List<ProductType> ApplicableProductTypes { get; set; }

        public OfferVoucher()
        {

        }
    }
}
