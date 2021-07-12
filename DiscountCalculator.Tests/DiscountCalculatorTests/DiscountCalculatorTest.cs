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
        [MemberData(nameof(CalculatorDataGenerator.orderMinusTenPc), MemberType= typeof(CalculatorDataGenerator))]
        public void Total_order_minus_ten_pc(Order order, Money percentage)
        {

            new DiscountCalculator(order).GlobalDiscount(10,new Money(1000, "EUR"));
            Assert.Equal(percentage,order.total);
            
            
        }
        
        [Theory]
        [MemberData(nameof(CalculatorDataGenerator.FreeSwitches), MemberType= typeof(CalculatorDataGenerator))]
        public void Free_switches_category_2(Order order, int totalitemwithfreeswitches, int freeSwitchIndex)
        {
  
            new DiscountCalculator(order).freeItems(2);
            int itemWithFreeSwitchQuantity =order.items[freeSwitchIndex].quantity;
            Assert.Equal( totalitemwithfreeswitches,itemWithFreeSwitchQuantity);
            
            
        }

        [Theory]
        [MemberData(nameof(CalculatorDataGenerator.clientGetsToolDiscount), MemberType= typeof(CalculatorDataGenerator))]
        public void Order_Gets_Tool_Discount(Order order)
        {
            
            Assert.True(new DiscountCalculator(order).canGetDiscountForCategory(1,2));
            
        }
        [Theory]
        [MemberData(nameof(CalculatorDataGenerator.clientGetsNoToolDiscount), MemberType= typeof(CalculatorDataGenerator))]
        public void Order_Gets_No_Tool_Discount(Order order)
        {
            
            Assert.False(new DiscountCalculator(order).canGetDiscountForCategory(1,2));
            
        }
        
        
        [Theory]
        [MemberData(nameof(CalculatorDataGenerator.clientGetsToolDiscount), MemberType= typeof(CalculatorDataGenerator))]
        public void GET_CATEGORY_DISCOUNT(Order order)
        {
            new DiscountCalculator(order).giveDiscountByCategory(20,1,2);
            Assert.Equal(new Money(67.05m,"EUR"),order.total);
            
        }
        
        
         [Theory]
         [MemberData(nameof(CalculatorDataGenerator.TotalDiscountTwoFreeSwitches), MemberType= typeof(CalculatorDataGenerator))]
        
         public void TOTAL_DISCOUNT_TEST_FREE_SWITCHES(Order order)
         {
             Order undiscountedOrder = order;

             new DiscountCalculator(order)
                 .giveDiscountByCategory(20, 1, 2)
                 .freeItems(2)
                 .GlobalDiscount(10, new Money(1000, "EUR"));
                 
             Assert.Equal(12,order.items[0].quantity);
             Assert.Equal(undiscountedOrder.total,order.total);
        
         }
            [Theory]
            [MemberData(nameof(CalculatorDataGenerator.TotalDiscountGlobalDiscount), MemberType= typeof(CalculatorDataGenerator))]
        
            public void TOTAL_DISCOUNT_TEST_GLOBAL_DISCOUNT(Order order, Money percentage)
            {
                
                
                new DiscountCalculator(order)
                    .giveDiscountByCategory(20, 1, 2)
                    .freeItems(2)
                    .GlobalDiscount(10, new Money(1000, "EUR"));
                Assert.Equal(6,order.items[0].quantity);
                Assert.Equal(percentage,order.total);
        
            }
           [Theory]
           [MemberData(nameof(CalculatorDataGenerator.totalDiscountWithToolDiscount), MemberType= typeof(CalculatorDataGenerator))]
        
           public void TOTAL_DISCOUNT_WITH_TOOL_DISCOUNT(Order order)
           {
        
               
               new DiscountCalculator(order)
                   .giveDiscountByCategory(20, 1, 2)
                   .freeItems(2)
                   .GlobalDiscount(10, new Money(1000, "EUR"));
        
               Assert.Equal(order.total,order.total);
        
           }
 
        
        
        
    }
}