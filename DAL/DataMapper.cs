using System;
using System.Collections.Generic;
using Domain.Clients;
using Domain.Orders;
using Domain.OrdersDto;
using Domain.Products;
using NodaMoney;

namespace DAL
{
    public class DtoToModelConverter
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
      
        
        
        
    }
}