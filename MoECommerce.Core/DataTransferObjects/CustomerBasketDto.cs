﻿using MoECommerce.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoECommerce.Core.DataTransferObjects
{
    public class CustomerBasketDto
    {
        public string Id { get; set; }

        public int? DeleviryMethod { get; set; }

        public decimal ShippingPrice { get; set; }

        public List<BasketItemDto> BasketItems { get; set; } = new List<BasketItemDto>();
    }
}
