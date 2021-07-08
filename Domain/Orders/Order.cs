using System;
using System.Collections.Generic;
using System.Reflection;
using Domain.Clients;
using Domain.OrdersDto;
using Newtonsoft.Json;
using NodaMoney;

namespace Domain.Orders
{
    public class Order
    {
        public int id { get; set; }
        public Client client { get; set; }
        public List<Item> items { get; set; }
        public Money total { get; set; }
        
    }
}