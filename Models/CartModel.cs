﻿using buiduckiem_aps.net.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace buiduckiem_aps.net.Models
{
    public class CartModel
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}