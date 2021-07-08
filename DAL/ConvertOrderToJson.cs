using System.IO;
using Domain.Orders;
using Domain.OrdersDto;
using Newtonsoft.Json;

namespace DAL
{
    public class ConvertOrderToJson
    {

        public void CreateJsonFromOrder(Order order, DataMapper dataMapper)
        {

           OrderDto orderDto = dataMapper.convertOrderToOrderDto(order);
            
            //string output = JsonConvert.SerializeObject(orderDto);
            
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            
            using (StreamWriter sw = new StreamWriter("../../../Resources/DiscountedOrders/orderdiscount.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, orderDto);
            }
        }
        
        
    }
}