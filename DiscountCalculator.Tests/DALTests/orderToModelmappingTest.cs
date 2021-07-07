using System.Collections.Generic;
using System.Linq;
using DAL;
using Domain.Orders;
using Domain.OrdersDto;
using Xunit;

namespace DiscountCalculator.Tests.DALTests
{
    public class orderToModelmappingTest
    {
        [Theory]
        [MemberData(nameof(GetData))]
        public void orderToOrderDtoMapperTest(Order order)
        {
            DataMapper mapper = new DataMapper();
            OrderDto orderDto =  mapper.convertOrderToOrderDto(order);
            
            Assert.True(orderDto is not null);
        }

        public static IEnumerable<object[]> GetData()
        {
            JsonFileToObject jsonFileToObject = new JsonFileToObject();
            Order order = jsonFileToObject.convertJsonToOrder("Resources/orders/order1.json", new DataMapper());
            Discount.Calculators.DiscountCalculator discountCalculator = new Discount.Calculators.DiscountCalculator(order);
            Order discountedOrder = discountCalculator.CalculateTotalDiscount();
            
            var allData = new List<object[]>
            {

                new object[] {discountedOrder}
                
            };


            return allData;
        }
    }
}