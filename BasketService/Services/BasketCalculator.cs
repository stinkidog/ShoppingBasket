using BasketService.Models;
using BasketService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasketService.Services
{
    public class BasketCalculator : IBasketCalculator
    {
        public BasketCalculator()
        {

        }

        public Basket CalculateTotal(Basket basket)
        {
            basket.ProductTotal = SumProducts(basket);
            basket.VoucherTotal = SumVouchers(basket);
            basket.FinalTotal = basket.ProductTotal + basket.VoucherTotal;

            if(basket.GiftVouchers.Count > 0)
            {
                basket = ApplyGiftVouchers(basket);
            }

            if(basket.OfferVoucher != null)
            {
                basket = ApplyOfferVoucher(basket);
            }

            return basket;
        }

        private decimal SumProducts(Basket basket)
        {
            decimal total = 0.0m;

            foreach (var product in basket.Products)
            {
                if(product.ProductType != Enums.ProductType.Voucher)
                {
                    total += product.Price;
                }
            }

            return total;
        }

        private decimal SumVouchers(Basket basket)
        {
            decimal total = 0.0m;

            foreach (var product in basket.Products)
            {
                if (product.ProductType == Enums.ProductType.Voucher)
                {
                    total += product.Price;
                }
            }

            return total;
        }

        private Basket ApplyGiftVouchers(Basket basket)
        {
            foreach(var giftVoucher in basket.GiftVouchers)
            {
                if((basket.FinalTotal - giftVoucher.Value) >= 0.00m)
                {
                    basket.FinalTotal -= giftVoucher.Value;
                }
            }

            return basket;
        }

        private Basket ApplyOfferVoucher(Basket basket)
        {
            if(OfferIsApplicable(basket.Products, basket.OfferVoucher))
            {
                if(basket.ProductTotal >= basket.OfferVoucher.Threshold)
                {
                    basket.FinalTotal -= basket.OfferVoucher.Value;
                    basket.ErrorMessage = "";
                }
                else
                {
                    decimal requiredValue = basket.OfferVoucher.Threshold - basket.ProductTotal;
                    basket.ErrorMessage = String.Format("You have not reached the spend threshold for voucher YYY-YYY. Spend another £{0} to recieve £{1} discount from your basket total.", requiredValue, basket.OfferVoucher.Value);
                }
            }
            else if(basket.OfferVoucher.Name == null)
            {
                basket.ErrorMessage = "";
            }
            else
            {
                basket.ErrorMessage = "There are no products in your basket applicable to voucher Voucher YYY-YYY";
            }

            return basket;
        }

        private bool OfferIsApplicable(List<Product> products, OfferVoucher offer)
        {
            if(offer.ApplicableProductTypes != null)
            {
                var allBasketProductTypes = products.Select(type => type.ProductType);
                var productTypesMatchingOffer = allBasketProductTypes.Intersect(offer.ApplicableProductTypes);

                if (productTypesMatchingOffer.Count() > 0)
                {
                    decimal sum = 0.00m;

                    foreach (var product in products)
                    {
                        if (productTypesMatchingOffer.Contains(product.ProductType))
                        {
                            sum += product.Price;
                        }
                    }

                    if (sum < offer.Value)
                    {
                        offer.Value = sum;
                    }

                    return true;
                }
            }
                 
            return false;
        }
    }
}
