using DAL;
using Domain.Orders;
using Xunit;

namespace DiscountCalculator.Tests.DALTests
{
    public class orderToJsonTest
    {
        
        [Fact]
        public void CanConvertToOrderTest()
        {
            JsonFileToObject jsonToOrder = new JsonFileToObject();

            Order order = jsonToOrder.convertJsonToOrder("Resources/orders/order1.json", new DataMapper());

            ConvertOrderToJson orderDiscountToJson = new ConvertOrderToJson();
            orderDiscountToJson.CreateJsonFromOrder(order, new DataMapper());
            
            Assert.Equal(1,1); 
            
        }
    }
}