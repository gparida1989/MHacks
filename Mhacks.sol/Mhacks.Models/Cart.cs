﻿using System.Collections.Generic;

namespace Mhacks.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public double GetCartTotalAmount()
        {
            return 0d;
        }
    }
}
