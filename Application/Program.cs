using System;
using DAL;
using Domain.Orders;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            DtoToModelConverter converter = new DtoToModelConverter();
            JsonFileToObject jsonFileToObject = new JsonFileToObject();

            Order order = new JsonFileToObject().convertJsonToOrder("Resources/orders/order1.json", converter);


            
            Console.WriteLine("Welcome to the homepage of this discount price calculator application");
            Console.WriteLine("What would you like to see:");
            
            Console.WriteLine("");
            
            Console.WriteLine("1. All Orders");

            
            Console.WriteLine("");
            Console.WriteLine("");

            int command = 0;

            while (command != 1)
            {
                string rawCommand = Console.ReadLine();
                bool parsed = int.TryParse(rawCommand, out int result);
                
                if(parsed && result == 1)
                {
                    command = result;
                }

                if (command != 1)
                {
                    Console.WriteLine("Please Enter a valid command");
                }
                
            }

            if (command == 1)
            {
                Application.OrderPage productPage = new OrderPage();
                productPage.orderIndex();
            }

            

        }
        
    }
}   
