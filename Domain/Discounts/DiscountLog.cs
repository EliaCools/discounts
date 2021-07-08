using System.Collections.Generic;
using Domain.Orders;

namespace Domain.Discounts
{
    public class DiscountLog
    {
        public Order order { get; set; }
      
        public List<DiscountLogItem> DiscountLogItems { get; set; }
    }
}