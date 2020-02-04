using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasketService.Models
{
    public class Basket
    {
        [JsonProperty("finalTotal")]
        public decimal FinalTotal { get; set; }

        [JsonProperty("productTotal")]
        public decimal ProductTotal { get; set; }

        [JsonProperty("voucherTotal")]
        public decimal VoucherTotal { get; set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }

        [JsonProperty("products")]
        public List<Product> Products { get; set; }

        [JsonProperty("offerVoucher")]
        public OfferVoucher OfferVoucher { get; set; }

        [JsonProperty("giftVouchers")]
        public List<GiftVoucher> GiftVouchers { get; set; }

        public Basket()
        {
            ProductTotal = 0.00m;
            VoucherTotal = 0.00m;
            Products = new List<Product>();
            GiftVouchers = new List<GiftVoucher>();
        }
    }
}
