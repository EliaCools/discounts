using System;
using System.Collections.Generic;
using Xunit;
using Discount.Calculators;
using Domain.Clients;
using Domain.ClientsDto;
using Domain.Orders;
using Domain.OrdersDto;
using Domain.Products;
using Domain.ProductsDto;
using NodaMoney;

namespace DiscountCalculator.Tests.DomainTests
{
    public class ModelTests
    {

        [Fact]
        public void ClientSettersAndGettersTest()
        {

            Client client = new Client();
            client.id = 1;
            client.name = "Jimi Hendrix";
            client.revenue = new Money(12.0m, "EUR");
            client.since = new DateTime(2021,01,01);

            
            Assert.Equal(1,client.id); 
            Assert.Equal("Jimi Hendrix",client.name); 
            Assert.Equal(new Money(12.0m, "EUR"),client.revenue); 
            Assert.Equal(new DateTime(2021,01,01),client.since); 

        }
        [Fact]
        public void OrderLineSettersAndGettersTest()
        {
            
            Product product = new Product()
            {
                id = "1", description = "a", category = 1, price = new Money(12.0m,"EUR")
            };

            Item item = new Item()
            {
                product = product, quantity = 1, total = new Money(12.0m, "EUR"), unitPrice = new Money(12.0m, "EUR")
            };
            
            Assert.Equal(product,product); 
            Assert.Equal(1,item.quantity); 
            Assert.Equal(new Money(12.0m,"EUR"),item.total); 
            Assert.Equal(new Money(12.0m,"EUR"),item.unitPrice); 
            
        }
        [Fact]
        public void OrderSettersAndGettersTest()
        {
            
            Client client = new Client();
            client.id = 1;
            client.name = "Jimi Hendrix";
            client.revenue = new Money(12.0m, "EUR");
            client.since = new DateTime(2021,01,01);
            
            Product product = new Product()
            {
                id = "1", description = "a", category = 1, price = new Money(12.0m,"EUR")
            };

            
            Item item = new Item()
            {
                product = product, quantity = 1, total = new Money(12.0m, "EUR"), unitPrice = new Money(12.0m, "EUR")
            };

            Order order = new Order()
            {
                client = client, id = 1, items = new List<Item>() {item}, total = new Money(12.0m, "EUR")
            };
            
            
            Assert.Equal(client,order.client); 
            Assert.Equal(1,order.id); 
            Assert.Equal(item,order.items[0]); 
            Assert.Equal(new Money(12.0m,"EUR"),order.total); 
            
        }
        [Fact]
        public void ProductSettersAndGettersTest()
        {
            
            Product product = new Product()
            {
                id = "1", description = "a", category = 1, price = new Money(12.0m,"EUR")
            };

            
            Assert.Equal("1",product.id); 
            Assert.Equal("a",product.description); 
            Assert.Equal(1,product.category); 
            Assert.Equal(new Money(12.0m,"EUR"),product.price); 
            
        }

        [Fact]
        public void ProductConstructorTest()
        {
            
            ProductDto productDto = new ProductDto()
            {
                id = "1", description = "a", category = 1, price = 12.0m
            };


            Product product = new Product(productDto);

            Assert.Equal("1",product.id); 
            Assert.Equal("a",product.description); 
            Assert.Equal(1,product.category); 
            Assert.Equal(new Money(12.0m,"EUR"),product.price); 


        }

        [Fact]
        public void ClientConstructorTest()
        {
            ClientDto clientDto = new ClientDto();
            clientDto.id = 1;
            clientDto.name = "Jimi Hendrix";
            clientDto.revenue = 12.0m;
            clientDto.since = new DateTime(2021,01,01);


            Client client = new Client(clientDto);
            
            Assert.Equal(1,client.id); 
            Assert.Equal("Jimi Hendrix",client.name); 
            Assert.Equal(new Money(12.0m, "EUR"),client.revenue); 
            Assert.Equal(new DateTime(2021,01,01),client.since); 

        }


        
        
        
        
    }
}