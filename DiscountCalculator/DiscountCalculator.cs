using System;
using System.Collections.Generic;
using Domain.Clients;
using Domain.Orders;
using Domain.OrdersDto;
using Domain.Products;
using NodaMoney;

namespace Discount.Calculators
{
    public class DiscountCalculator
    {
        private const int SWITCH_CATEGORY = 2;
        private const int TOOLS_CATEGORY = 1;
        private const int MIN_TOOLS_FOR_TOOL_DISC = 2;
     

        private Order order;
        private List<KeyValuePair<String, String>> discountLog;
        public DiscountCalculator(Order order)
        {
            this.order = order;
        }
        
        

        public bool clientGetsWholeOrderDiscount()
        {
            
           if (this.order.client.revenue < new Money(1000m,"EUR"))
           {
               return false;
           }
           
           return true;
        }

        public void applyGlobalDiscount()
        {

            Money totalMinusTenPc = this.order.total - (this.order.total / 10);

          //  this.discountLog.Add(new KeyValuePair<string, string>("GlobalDiscount",$"{this.order.total.ToString()} - 10% ")); 

            this.order.total = totalMinusTenPc;

            
        }

        public void freeSwitches()
        {
            int freeSwitches = 0;

            Order originalOrder = order;

            List<Item> eligibleItems = new List<Item>();

            foreach (var item in this.order.items)
            {

                if (item.product.category == SWITCH_CATEGORY)
                {
                    
                    for (int i = 0; i <= item.quantity; i++)
                    {
                        if (i % 5 == 0 && i != 0)
                        {
                            eligibleItems.Add(item);
                            item.quantity += 1;
                            freeSwitches++;
                        }
                    }
                    
                }
                
            }
            
           //Todo display calculation 
            
        }



        public bool cangetDiscountForTools()
        {
            int itemsInToolsCategory = 0;

            foreach (var item in this.order.items)
            {

                if (item.product.category == TOOLS_CATEGORY)
                {
                    itemsInToolsCategory += 1;
                }
                
            }

            if (itemsInToolsCategory < MIN_TOOLS_FOR_TOOL_DISC)
            {
                return false;
            }

    
            return true;
            
            
        }
        
        private static int compareIemsByUnitPrice(Item x, Item y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal.
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater.
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                    // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    int retval = x.unitPrice.CompareTo(y.unitPrice);

                    if (retval != 0)
                    {

                        return retval;
                    }
                    else
                    {
                        return x.product.id.CompareTo(y);
                    }
                }
            }
        }

        public Item getCheapestToolItem()
        {

            List<Item> toolItems = new List<Item>();

            foreach (var item in order.items)
            {

                if (item.product.category == TOOLS_CATEGORY)
                {
                    toolItems.Add(item);
                }
                
            }
            toolItems.Sort(compareIemsByUnitPrice);

            return toolItems[0];


        }

        public void calculateToolPercent()
        {

            Item item = getCheapestToolItem();

            Money calculatePc = item.unitPrice / 5;

            order.total = order.total - calculatePc;
          // this.discountLog.Add(new KeyValuePair<string, string>("ToolDiscount",$" 5% of {item.product.description} for buying two items of category tools"));
        }
        
        
    }
    

    
}
