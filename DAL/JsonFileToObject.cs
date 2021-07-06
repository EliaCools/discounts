

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Domain.Products;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NodaMoney;
using Domain.Clients;
using Domain.ClientsDto;
using Domain.Orders;
using Domain.OrdersDto;
using Domain.ProductsDto;


namespace DAL
{
    public class JsonFileToObject
    {

        
          public Order convertJsonToOrder(String path , DtoToModelConverter dtoToModelConverter)
          {
              using (StreamReader r = new StreamReader(path))
              {
                  string json = r.ReadToEnd();
                  OrderDto orderDto = JsonConvert.DeserializeObject<OrderDto>(json);

                  

                  Order order = dtoToModelConverter.convertOrderDtoToOrder(orderDto, convertJsonToClients(), convertJsonToProducts());

                  return order;
                  
              }
              
          }
          


      public List<Client> convertJsonToClients()
       {


           using (StreamReader r = new StreamReader("Resources/customers.json"))
           {
               string jsonText = r.ReadToEnd();
               List<ClientDto> clientsDto = JsonConvert.DeserializeObject<List<ClientDto>>(jsonText);
               
               
              var clients = new List<Client>();

              foreach (var clientDto  in clientsDto)
              {
                  clients.Add(new Client(clientDto));
              }
              
              return clients;

           }
       }

      public List<Product> convertJsonToProducts()
       {

           using (StreamReader r = new StreamReader("Resources/products.json"))
           {
               string jsonText = r.ReadToEnd();
               List<ProductDto> productDtos= JsonConvert.DeserializeObject<List<ProductDto>>(jsonText);

              var products = new List<Product>();
              
              foreach (var productDto in productDtos)
              {
                
                products.Add(new Product(productDto));
                  
              }
              
              return products;

           }
       }
      
    }
}