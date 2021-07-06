using System;
using System.Collections.Generic;
using Domain.Clients;
using Domain.ClientsDto;
using Domain.Orders;
using Domain.OrdersDto;
using Domain.ProductsDto;
using NodaMoney;
using Xunit;

namespace DiscountCalculator.Tests.DomainTests
{
    public class ModelDtoTests
    {
        [Fact]
        public void ClientDtoSettersAndGettersTest()
        {

            ClientDto client = new ClientDto();
            client.id = 1;
            client.name = "Jimi Hendrix";
            client.revenue = 12.0m;
            client.since = new DateTime(2021,01,01);

            
            Assert.Equal(1,client.id); 
            Assert.Equal("Jimi Hendrix",client.name); 
            Assert.Equal(12.0m,client.revenue); 
            Assert.Equal(new DateTime(2021,01,01),client.since); 

        }
        
        [Fact]
        public void OrderLineDtoSettersAndGettersTest()
        {

            ItemDto item = new ItemDto()
            {
                productId = "123A", quantity = 1, total = 12.0m, unitPrice = 12.0m
            };
            
            Assert.Equal("123A",item.productId); 
            Assert.Equal(1,item.quantity); 
            Assert.Equal(12.0m,item.total); 
            Assert.Equal(12.0m,item.unitPrice); 
            
        }
        
        
        [Fact]
        public void OrderDtoSettersAndGettersTest()
        {
            
            ItemDto itemDto = new ItemDto()
            {
                productId = "123A", quantity = 1, total = 12.0m, unitPrice = 12.0m
            };

            OrderDto orderDto = new OrderDto()
            {
                customerId = 1, id = 1, items = new List<ItemDto>() {itemDto}, total = 12.0m
            };
            
            
            Assert.Equal(1,orderDto.customerId); 
            Assert.Equal(1,orderDto.id); 
            Assert.Equal(itemDto,orderDto.items[0]); 
            Assert.Equal(12.0m,orderDto.total); 
            
        }
        
        [Fact]
        public void ProductSettersAndGettersTest()
        {
            
            ProductDto productDto = new ProductDto()
            {
                id = "1", description = "a", category = 1, price = 12.0m
            };


            
            
            Assert.Equal("1",productDto.id); 
            Assert.Equal("a",productDto.description); 
            Assert.Equal(1,productDto.category); 
            Assert.Equal(12.0m,productDto.price); 
            
        }

        
        
        


    }
}