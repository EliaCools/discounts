using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Domain.Clients;
using Domain.Orders;
using Domain.OrdersDto;
using Domain.Products;
using NodaMoney;
using Domain.Discounts;



namespace Discount.Calculators
{
    public class DiscountCalculator
    {
        

        private Order order;

        public DiscountLog discountLog { get; set; }
        public DiscountCalculator(Order order)
        {
            this.order = order;
            this.discountLog = new DiscountLog(){order = order};
        }

        



        public DiscountCalculator GlobalDiscount(int percentage, Money minimumRevenue )
        {
            
            if (this.order.client.revenue >= minimumRevenue)
            {
                this.order.total = this.order.total - ((decimal) percentage / 100 * this.order.total);
            }

            return this;

        }

        
        
        
        
        public DiscountCalculator freeItems(int productCategory)
        {
            int freeItems = 0;

            Order originalOrder = order;

            List<Item> eligibleItems = new List<Item>();

            foreach (var item in this.order.items)
            {

                if (item.product.category == productCategory)
                {
                    
                    for (int i = 0; i <= item.quantity; i++)
                    {
                        if (i % 5 == 0 && i != 0)
                        {
                            eligibleItems.Add(item);
                            item.quantity += 1;
                            freeItems++;
                        }
                    }
                    
                }
                
            }

            return this;
        }



        public bool canGetDiscountForCategory(int category, int minimumItemsInCategory)
        {
            int itemsInCategory = 0;

            foreach (var item in this.order.items)
            {

                if (item.product.category == category)
                {
                    itemsInCategory += item.quantity;;
                }
                
            }

            if (itemsInCategory < minimumItemsInCategory)
            {
                return false;
            }

    
            return true;
            
            
        }
        
        private static int compareItemsByUnitPrice(Item x, Item y)
        {
    
                    return x.unitPrice.CompareTo(y.unitPrice);
                    
        }

        private int cheapestItemIndex(int category)
        {

            List<Item> itemsInCategory = new List<Item>();

            foreach (var item in order.items)
            {

                if (item.product.category == category)
                {
                    itemsInCategory.Add(item);
                }
                
            }

            if (!itemsInCategory.Any())
            {
                throw new Exception("Client does not have items in this category");
            }
            
            
            itemsInCategory.Sort(compareItemsByUnitPrice);

            Item cheapestItem = itemsInCategory[0];

            int refindIndex = 0;

            foreach (var orderitem in order.items)
            {
                
                if (orderitem.product == cheapestItem.product)
                {
                    break;
                }
                
                refindIndex++;
            }

        

            return refindIndex;

        }
            
        public DiscountCalculator giveDiscountByCategory(int percentage, int category, int minimumItemsInCategory)
        {

            if (!canGetDiscountForCategory(category,minimumItemsInCategory))
            {
                return this;
            }
            
            Item cheapestItem = order.items[cheapestItemIndex(category)];
            Money calculatePc = ((decimal) percentage / 100 * cheapestItem.unitPrice);
            
            order.items[cheapestItemIndex(category)].total = order.items[cheapestItemIndex(category)].total - calculatePc;
            order.total = order.total - calculatePc;


            return this;

        }
        
        
    }
    

    
}
