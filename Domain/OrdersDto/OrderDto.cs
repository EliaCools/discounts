using System.Collections.Generic;
using Domain.Orders;
using Newtonsoft.Json;

namespace Domain.OrdersDto
{
    public class OrderDto
    {
        public int id { get; set; }
        
        [JsonProperty(PropertyName="customer-id")]
        public int customerId { get; set; }
        public List<ItemDto> items { get; set; }
        public decimal total { get; set; }

    }
}