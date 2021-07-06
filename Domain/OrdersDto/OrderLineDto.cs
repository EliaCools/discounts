using Newtonsoft.Json;

namespace Domain.OrdersDto
{
    public class ItemDto
    {
         [JsonProperty(PropertyName="product-id")]
        public string productId { get; set; }    
        public int quantity { get; set; } 
        
        [JsonProperty(PropertyName="unit-price")]
        public decimal unitPrice { get; set; }
        public decimal total { get; set; }
    }
}