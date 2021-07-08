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
        private const int SWITCH_CATEGORY = 2;
        private const int TOOLS_CATEGORY = 1;
        private const int MIN_TOOLS_FOR_TOOL_DISC = 2;
     

        private Order order;

        public DiscountLog discountLog { get; set; }
        public DiscountCalculator(Order order)
        {
            this.order = order;
            this.discountLog = new DiscountLog(){order = order};
        }

        
        public Order CalculateTotalDiscount()
        {
            if (cangetDiscountForTools())
            {
                calculateToolPercent();
            }
            
            freeSwitches();

            if (cangetDiscountForTools())
            {
                calculateToolPercent();
            }

            if (clientGetsWholeOrderDiscount())
            {
                applyGlobalDiscount();
            }

            return order;
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
                    itemsInToolsCategory += item.quantity;;
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
    
                    return x.unitPrice.CompareTo(y.unitPrice);

     
            
        }

        public int cheapestToolItemIndex()
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

            Item cheapestItem = toolItems[0];

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
            
        public void calculateToolPercent()
        {

            Item cheapestItem = order.items[cheapestToolItemIndex()];

            Money calculatePc = cheapestItem.unitPrice / 5;



            order.items[cheapestToolItemIndex()].total = order.items[cheapestToolItemIndex()].total - calculatePc;

            order.total = order.total - calculatePc;


           

       
           // todo logging object data gives nul reference error.
            
        }
        
        
    }
    

    
}
