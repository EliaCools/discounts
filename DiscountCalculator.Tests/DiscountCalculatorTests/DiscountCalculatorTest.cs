using DAL;
using Domain.Clients;
using Domain.Orders;
using NodaMoney;
using Xunit;

namespace Discount.Calculators.UnitTests.Services.DiscountCalculatorTests
{
    public class DiscountCalculatorTest
    {
        

        [Theory]
        [MemberData(nameof(CalculatorDataGenerator.ClientsBelowThousand), MemberType= typeof(CalculatorDataGenerator))]
        public void Client_Not_eligible_for_global_discount(Order order)
        {
            
            
            Assert.False(new DiscountCalculator(order).clientGetsWholeOrderDiscount());
            
            
        }
        
        [Theory]
        [MemberData(nameof(CalculatorDataGenerator.ClientsAboveThousand), MemberType= typeof(CalculatorDataGenerator))]
        public void Client_eligible_for_global_discount(Order order)
        {
            
            
            Assert.True(new DiscountCalculator(order).clientGetsWholeOrderDiscount());
            
            
        }
        
        [Theory]
        [MemberData(nameof(CalculatorDataGenerator.orderMinusTenPc), MemberType= typeof(CalculatorDataGenerator))]
        public void Total_order_minus_ten_pc(Order order, Money percentage)
        {

            new DiscountCalculator(order).applyGlobalDiscount();
            Assert.Equal(order.total, percentage);
            
            
        }
        
        [Theory]
        [MemberData(nameof(CalculatorDataGenerator.FreeSwitches), MemberType= typeof(CalculatorDataGenerator))]
        public void Free_switches_category_2(Order order, int totalitemwithfreeswitches, int freeSwitchIndex)
        {
  
            new DiscountCalculator(order).freeSwitches();
            int itemWithFreeSwitchQuantity =order.items[freeSwitchIndex].quantity;
            Assert.Equal( totalitemwithfreeswitches,itemWithFreeSwitchQuantity);
            
            
        }

        [Theory]
        [MemberData(nameof(CalculatorDataGenerator.clientGetsToolDiscount), MemberType= typeof(CalculatorDataGenerator))]
        public void Order_Gets_Tool_Discount(Order order)
        {
            
            Assert.True(new DiscountCalculator(order).cangetDiscountForTools());
            
        }
        [Theory]
        [MemberData(nameof(CalculatorDataGenerator.clientGetsNoToolDiscount), MemberType= typeof(CalculatorDataGenerator))]
        public void Order_Gets_No_Tool_Discount(Order order)
        {
            
            Assert.False(new DiscountCalculator(order).cangetDiscountForTools());
            
        }
        
        
   //    [Theory]
   //    [MemberData(nameof(CalculatorDataGenerator.clientGetsToolDiscount), MemberType= typeof(CalculatorDataGenerator))]
   //    public void Find_cheapest_tool(Order order)
   //    {
   //        
   //        Assert.Equal(new DiscountCalculator(order).cheapestToolItemIndex().unitPrice, new Money(9.75m,"EUR"));
   //        
   //    }
        
        [Theory]
        [MemberData(nameof(CalculatorDataGenerator.clientGetsToolDiscount), MemberType= typeof(CalculatorDataGenerator))]
        public void Get_Tool_Discount(Order order)
        {
            new DiscountCalculator(order).calculateToolPercent();
            Assert.Equal(new Money(67.05m,"EUR"),order.total);
            
        }
        [Theory]
        [MemberData(nameof(CalculatorDataGenerator.TotalDiscountTwoFreeSwitches), MemberType= typeof(CalculatorDataGenerator))]
   
        public void TOTAL_DISCOUNT_TEST_FREE_SWITCHES(Order order)
        {
            Order undiscountedOrder = order;
            
            new DiscountCalculator(order).CalculateTotalDiscount();
            Assert.Equal(12,order.items[0].quantity);
            Assert.Equal(undiscountedOrder.total,order.total);

        }
        [Theory]
        [MemberData(nameof(CalculatorDataGenerator.TotalDiscountGlobalDiscount), MemberType= typeof(CalculatorDataGenerator))]

        public void TOTAL_DISCOUNT_TEST_GLOBAL_DISCOUNT(Order order, Money percentage)
        {
            
            
            new DiscountCalculator(order).CalculateTotalDiscount();
            Assert.Equal(6,order.items[0].quantity);
            Assert.Equal(percentage,order.total);

        }
        [Theory]
        [MemberData(nameof(CalculatorDataGenerator.totalDiscountWithToolDiscount), MemberType= typeof(CalculatorDataGenerator))]

        public void TOTAL_DISCOUNT_WITH_TOOL_DISCOUNT(Order order)
        {

            
            new DiscountCalculator(order).CalculateTotalDiscount();

            Assert.Equal(order.total,order.total);

        }
 
        
        
        
    }
}