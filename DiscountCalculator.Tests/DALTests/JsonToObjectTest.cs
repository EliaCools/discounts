using System;
using System.Collections.Generic;
using Xunit;
using Discount.Calculators;
using Domain.Clients;
using NodaMoney;
using Domain.Orders;
using Domain.Products;
using DAL;
using Domain.OrdersDto;


namespace Discount.UnitTests.Services
{
    public class JsonToObjectTest
    {


        [Fact]
        public void CanConvertToOrderTest()
        {
            JsonFileToObject jsonToOrder = new JsonFileToObject();
            
            
            Assert.True(jsonToOrder.convertJsonToOrder("Resources/orders/order1.json", new DataMapper()) is Order );
            
        }
        
        [Fact]
        public void CanConvertToClientTest()
        {
            JsonFileToObject jsonToOrder = new JsonFileToObject();
            
            Assert.True(jsonToOrder.convertJsonToClients() is List<Client> );
            
        }
        
        [Fact]
        public void CanConvertToProductsTest()
        {
            JsonFileToObject jsonToOrder = new JsonFileToObject();
            
            Assert.True(jsonToOrder.convertJsonToProducts() is List<Product> );
            
        }
        
        
        
        
        
    }
}