using BasketService.Enums;
using BasketService.Factories;
using BasketService.Models;
using BasketService.Services;
using BasketService.Services.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {

        private IBasketCalculator _basketCalculator;
        private ProductFactory _prodFactory;
        private VoucherFactory _vouchFactory;

        [SetUp]
        public void Setup()
        {
            _basketCalculator = new BasketCalculator();
            _prodFactory = new ProductFactory();
            _vouchFactory = new VoucherFactory();
        }

        [Test]
        public void CheapHat_ExpensiveJumper_5PoundGiftVoucher()
        {
            //Given a basket with a cheap hat, an expensive jumper, and £5 off gift voucher
            Basket basket = new Basket()
            {
                Products = new List<Product>()
                {
                    _prodFactory.GenerateProduct(ProductEnum.CheapHat),
                    _prodFactory.GenerateProduct(ProductEnum.ExpensiveJumper)
                },
                GiftVouchers = new List<GiftVoucher>()
                {
                    (GiftVoucher)_vouchFactory.GenerateVoucher(VouchersEnum.Gift_5PoundOff)
                }               
            };

            //When the total is calculated
            var actual = _basketCalculator.CalculateTotal(basket);

            //Then the total should be £60.15, and no error message displayed
            Assert.AreEqual(60.15m, actual.FinalTotal);
            Assert.AreEqual(null, actual.ErrorMessage);
        }

        [Test]
        public void ExpensiveHat_CheapJumper_5PoundOfferVoucherHeadgear()
        {
            //Given a basket with an expensive hat, a cheap jumper, and £5 off offer voucher for headgear
            Basket basket = new Basket()
            {
                Products = new List<Product>()
                {
                    _prodFactory.GenerateProduct(ProductEnum.ExpensiveHat),
                    _prodFactory.GenerateProduct(ProductEnum.CheapJumper)
                },
                OfferVoucher = (OfferVoucher)_vouchFactory.GenerateVoucher(VouchersEnum.Offer_5PoundOffHeadgear_Threshold50)
            };

            //When the total is calculated
            var actual = _basketCalculator.CalculateTotal(basket);

            //Then the total should be £51.00, and an error message stating no products are applicable for the voucher
            Assert.AreEqual(51.00m, actual.FinalTotal);
            Assert.AreEqual("There are no products in your basket applicable to voucher Voucher YYY-YYY", actual.ErrorMessage);
        }

        [Test]
        public void ExpensiveHat_CheapJumper_HeadLight_5PoundOfferVoucherHeadgear()
        {
            //Given a basket with an expensive hat, a cheap jumper, a headlight, and £5 off offer voucher for headgear
            Basket basket = new Basket()
            {
                Products = new List<Product>()
                {
                    _prodFactory.GenerateProduct(ProductEnum.ExpensiveHat),
                    _prodFactory.GenerateProduct(ProductEnum.CheapJumper),
                    _prodFactory.GenerateProduct(ProductEnum.HeadLight)
                },
                OfferVoucher = (OfferVoucher)_vouchFactory.GenerateVoucher(VouchersEnum.Offer_5PoundOffHeadgear_Threshold50)     
            };

            //When the total is calculated
            var actual = _basketCalculator.CalculateTotal(basket);

            //Then the total should be £51.00, and no error message
            Assert.AreEqual(51.00m, actual.FinalTotal);
            Assert.AreEqual(null, actual.ErrorMessage);
        }

        [Test]
        public void ExpensiveHat_CheapJumper_5PoundGiftVoucher_5PoundOfferVoucherBasket()
        {
            //Given a basket with an expensive hat, a cheap jumper, £5 Gift Voucher, and £5 off baskets over £50 Offer Voucher
            Basket basket = new Basket()
            {
                Products = new List<Product>()
                {
                    _prodFactory.GenerateProduct(ProductEnum.ExpensiveHat),
                    _prodFactory.GenerateProduct(ProductEnum.CheapJumper)
                },
                GiftVouchers = new List<GiftVoucher>()
                {
                    (GiftVoucher)_vouchFactory.GenerateVoucher(VouchersEnum.Gift_5PoundOff)
                },
                OfferVoucher = (OfferVoucher)_vouchFactory.GenerateVoucher(VouchersEnum.Offer_5PoundOff_Threshold50)

            };

            //When the total is calculated
            var actual = _basketCalculator.CalculateTotal(basket);

            //Then the total should be £41.00, and no error message
            Assert.AreEqual(41.00m, actual.FinalTotal);
            Assert.AreEqual(null, actual.ErrorMessage);
        }

        [Test]
        public void ExpensiveHat_GiftVoucherProduct_5PoundOfferVoucherBasket()
        {
            //Given a basket with an expensive hat, £30 Gift Voucher Product, and £5 off baskets over £50 Offer Voucher
            Basket basket = new Basket()
            {
                Products = new List<Product>()
                {
                    _prodFactory.GenerateProduct(ProductEnum.ExpensiveHat),
                    _prodFactory.GenerateProduct(ProductEnum.Voucher30Pounds)
                },
                OfferVoucher = (OfferVoucher)_vouchFactory.GenerateVoucher(VouchersEnum.Offer_5PoundOff_Threshold50)
            };

            //When the total is calculated
            var actual = _basketCalculator.CalculateTotal(basket);

            //Then the total should be £55.00, and an error message displaying £25.01 more needs to be spent
            Assert.AreEqual(55.00m, actual.FinalTotal);
            Assert.AreEqual("You have not reached the spend threshold for voucher YYY-YYY. Spend another £25.00 to recieve £5.00 discount from your basket total.", actual.ErrorMessage);
        }
    }
}