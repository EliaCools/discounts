using System;
using System.Collections.Generic;
using Domain.Clients;
using Domain.Orders;
using Domain.OrdersDto;
using Domain.Products;
using NodaMoney;

namespace DAL
{
    public class DataMapper
    {


        public  Order convertOrderDtoToOrder(OrderDto orderDto, List<Client> allClients, List<Product> allProducts)
        {
            Client correctClient = null;

            foreach (var client in allClients)
            {

                if (client.id == orderDto.customerId)
                {
                    correctClient = client;

                }
                
            }

            if (correctClient == null)
            {
                throw new ArgumentException("The Client of this order does not exist");
            }
            
            if (correctClient.id != orderDto.customerId)
            {
                throw new ArgumentException("This client does not belong to this order");
            }

            return new Order(){id = orderDto.id, client = correctClient, items = convertItemDtosToItems(orderDto, allProducts), total = new Money(orderDto.total,"EUR")};

        }

          private List<Item> convertItemDtosToItems(OrderDto orderDto, List<Product> allProducts)
          {
              List<Item> items = new List<Item>();
              
              foreach (var itemDto in orderDto.items)
              {

                  foreach (var product in allProducts)
                  {
                      if (itemDto.productId == product.id)
                      {
                          items.Add(new Item()
                              {product = product, quantity = itemDto.quantity, total = new Money(itemDto.total, "EUR"), unitPrice = new Money(itemDto.unitPrice,"EUR")}
                          );
                      }



                  }
                  
              }

              if (items.Count == 0)
              {
                  throw new ArgumentException("The product in this shopping line could not be found");
              }

              return items;
          }



          public OrderDto convertOrderToOrderDto(Order order)
          {

            OrderDto orderDto =  new OrderDto() {id = order.id ,customerId = order.client.id, items = convertItemsToItemsDtos(order), total = order.total.Amount};

            return orderDto;

          }


          private List<ItemDto> convertItemsToItemsDtos(Order order)
          {

              List<ItemDto> itemDtos = new List<ItemDto>();
            

              foreach (var item in order.items)
              {
                  
                  itemDtos.Add(new ItemDto(){productId = item.product.id, quantity = item.quantity, total = item.total.Amount, unitPrice = item.unitPrice.Amount});
                  
                  
              }

              return itemDtos;


          }
      
        
        
        
    }
}