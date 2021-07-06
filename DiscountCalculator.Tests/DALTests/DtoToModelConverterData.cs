using System;
using System.Collections;
using System.Collections.Generic;
using Domain.Clients;
using Domain.Products;
using NodaMoney;

namespace DiscountCalculator.Tests.DALTests
{
    
    
    public class OrderDtoToClientData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Client {id = 1, name = "jeff", revenue = new Money(12.0m, "EUR"), since = new DateTime(2000,12,12)},
                new Client {id = 2, name = "jeff", revenue = new Money(12.0m, "EUR"),since = new DateTime(2000,12,12)}
                
            };

        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class OrderDtoProductIdToProductData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Product() { id = "123A", description = "a", category = 1, price = new Money(12.0m,"EUR")},
                new Product() { id = "123B", description = "a", category = 1, price = new Money(12.0m,"EUR")}
                
            };

        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

        
    
}