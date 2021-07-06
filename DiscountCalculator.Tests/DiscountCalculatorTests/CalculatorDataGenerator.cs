using System;
using System.Collections.Generic;
using DAL;
using Domain.Orders;

namespace Discount.Calculators.UnitTests.Services.DiscountCalculatorTests
{
    public class CalculatorDataGenerator
    {
        private static JsonFileToObject objectFetcher = new JsonFileToObject() ;
        private static DtoToModelConverter converter = new DtoToModelConverter();

        
        public static IEnumerable<object[]> ClientsBelowThousand()
        {
            Order clientbelowthousand = objectFetcher.convertJsonToOrder("Resources/orders/order1.json", converter);
            Order clientbelowthousand2 = objectFetcher.convertJsonToOrder("Resources/orders/order3.json", converter);
            
            
            var allData = new List<object[]>
            {
                new object[] {clientbelowthousand},
               new object[] {clientbelowthousand2},

            };

            return allData;
        }
        public static IEnumerable<object[]> ClientsAboveThousand()
        {
            Order clientAboveThousand = objectFetcher.convertJsonToOrder("Resources/orders/order2.json", converter);


            var allData = new List<object[]>
            {
                new object[] {clientAboveThousand},


            };

            return allData;
        }
        public static IEnumerable<object[]> orderMinusTenPc()
        {
            Order order1 = objectFetcher.convertJsonToOrder("Resources/orders/order1.json", converter);
            Order order2 = objectFetcher.convertJsonToOrder("Resources/orders/order2.json", converter);
            Order order3 = objectFetcher.convertJsonToOrder("Resources/orders/order3.json", converter);

            var allData = new List<object[]>
            {
                new object[] {order1, order1.total - (order1.total / 10)},
                new object[] {order2, order2.total - (order2.total / 10)},
                new object[] {order3, order3.total - (order3.total / 10)},


            };

            return allData;
        }
        public static IEnumerable<object[]> FreeSwitches()
        {
            Order orderFreeSwitch = objectFetcher.convertJsonToOrder("Resources/orders/order1.json", converter);
            Order orderFreeSwitch2 = objectFetcher.convertJsonToOrder("Resources/orders/order2.json", converter);


            var allData = new List<object[]>
            {
                new object[] {orderFreeSwitch, 12, 0},
                new object[] {orderFreeSwitch2, 6 , 0},
                
            };

            return allData;
        }
        public static IEnumerable<object[]> clientGetsToolDiscount()
        {
            Order toolDiscount = objectFetcher.convertJsonToOrder("Resources/orders/order3.json", converter);
       


            var allData = new List<object[]>
            {
                new object[] {toolDiscount},
                
            };

            return allData;
        }
        
        
        public static IEnumerable<object[]> clientGetsNoToolDiscount()
        {
            Order noToolDisc1 = objectFetcher.convertJsonToOrder("Resources/orders/order1.json", converter);
            Order noToolDisc2 = objectFetcher.convertJsonToOrder("Resources/orders/order2.json", converter);


            var allData = new List<object[]>
            {
                new object[] {noToolDisc1},
                new object[] {noToolDisc2},
                
            };

            return allData;
        }

    }
}