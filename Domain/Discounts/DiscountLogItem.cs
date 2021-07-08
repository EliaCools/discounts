using Domain.Orders;

namespace Domain.Discounts
{
    public class DiscountLogItem
    {
        public string discountId { get; set; }
        
        public Item item { get; set; }
      
        public string calculationLogMessage { get; set; }
    }
}