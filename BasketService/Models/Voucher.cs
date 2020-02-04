using System;
using System.Collections.Generic;
using System.Text;

namespace BasketService.Models
{
    public abstract class Voucher
    {
        public string Name { get; set; }

        public decimal Value { get; set; }
    }
}
