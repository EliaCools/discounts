using System;
using System.Collections;
using System.Collections.Generic;
using NodaMoney;
using Domain.Clients;

namespace Discount.Calculators.UnitTests.Services
{
    public class WholeOrderDiscData : IEnumerable<Object[]>
    {

        public IEnumerator<object[]> GetEnumerator()
        {
           //Client client1 = new Client(1, "jef", new DateTime(2000, 10, 10), new Money(12.0m, "EUR"));
           //Client client2 = new Client(1, "jef", new DateTime(2000, 10, 10), new Money(12.0m, "EUR"));


            //Order order = new Order(1, 1, new List<Item>( {new Item(),new Item()})  );
            
         //  yield return new object[] {,new Money(12.0m, "EUR"),true};
           yield return new object[] {new Money(11.0m, "EUR"),new Money(12.0m, "EUR"),false};
        }
        
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

