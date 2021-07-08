using System;
using Domain.OrdersDto;
using Domain.Products;
using Newtonsoft.Json;
using NodaMoney;

namespace Domain.Orders
{
    public class Item
    {
      
        public Product product { get; set; }    
        public int quantity { get; set; } 

        public Money unitPrice { get; set; }
        public Money total { get; set; }
        
        
        public Item()
        {
            
        }
        
    }
    
    
}