using System;
using System.Collections.Generic;
using DAL;
using Domain.Clients;
using Domain.OrdersDto;
using Domain.Products;
using NodaMoney;
using Xunit;

namespace DiscountCalculator.Tests.DALTests
{
    public class DtoToModelConverterTests
    {

        [Theory]
        [ClassData(typeof(OrderDtoToClientData))]
        public void Convert_ClientId_To_Client_Model_Test(Client rightClient, Client wrongClient)
        {
            ItemDto itemDto = new ItemDto()
            {
                productId = "123A", quantity = 1, total = 12.0m, unitPrice = 12.0m
            };
            OrderDto orderDto = new OrderDto()
            {
                customerId = 1, id = 1, items = new List<ItemDto>() {itemDto}, total = 12.0m
            };
            Product product = new Product()
            {
                id = "123A", description = "a", category = 1, price = new Money(12.0m,"EUR")
            };

            List <Product > products= new List<Product>();
            products.Add(product);
            
            List<Client> rightClientList = new List<Client>();
            rightClientList.Add(rightClient);
            
            List<Client> badClientList = new List<Client>();
            badClientList.Add(wrongClient);
            
            DtoToModelConverter converter = new DtoToModelConverter();
        
            Assert.Throws<ArgumentException>(() => converter.convertOrderDtoToOrder(orderDto, badClientList, products));
            Assert.Equal(orderDto.customerId, converter.convertOrderDtoToOrder(orderDto,rightClientList, products).client.id);
            
        }
        
        [Theory]
        [ClassData(typeof(OrderDtoProductIdToProductData))]
        public void ConvertProductIdToProductObjectTest(Product product1, Product product2 )
        {
            ItemDto itemDto = new ItemDto()
            {
                productId = "123A", quantity = 1, total = 12.0m, unitPrice = 12.0m
            };
            OrderDto orderDto = new OrderDto()
            {
                customerId = 1, id = 1, items = new List<ItemDto>() {itemDto}, total = 12.0m
            };
            Client client = new Client
            {
                id = 1, name = "jeff", revenue = new Money(12.0m, "EUR"), since = new DateTime(2000, 12, 12)
            };


            List <Product > products= new List<Product>();
            products.Add(product1);
           products.Add(product2);
            
            List<Client> clients = new List<Client>();
            clients.Add(client);
            

            
            DtoToModelConverter converter = new DtoToModelConverter();
        
        
            Assert.Equal(orderDto.customerId, converter.convertOrderDtoToOrder(orderDto,clients, products).client.id);
            Assert.Equal(orderDto.items.Count, converter.convertOrderDtoToOrder(orderDto,clients, products).items.Count);
            Assert.Equal(orderDto.items[0].productId, converter.convertOrderDtoToOrder(orderDto,clients, products).items[0].product.id);
            
        }
        
        
        
        
        

    }
}