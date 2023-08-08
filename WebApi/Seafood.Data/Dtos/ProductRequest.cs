﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.Data.Dtos
{
    public class ProductRequest
    {
        public string CategoryCode { get; set; }
        public string ShopCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? ReviewProd { get; set; }
        public int Price { get; set; }
        public int PriceSale { get; set; }
        public double? Amount { get; set; }
        public string Note { get; set; }
    }
}
