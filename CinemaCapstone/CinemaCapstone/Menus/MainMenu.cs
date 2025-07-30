// Menu/MainMenu.cs

using System;



namespace Capstone.Menu

{

    public static class MainMenu

    {

        public static void Display(bool isManager)

        {

            Console.WriteLine("=== Hull-ywood Cinema Point of Sale ===");

            Console.WriteLine("1. Sell Tickets and Concessions");

            Console.WriteLine("2. Manage Schedule");

            Console.WriteLine("3. Loyalty Scheme");

            Console.WriteLine("4. Gold Membership");



            if (isManager)

            {

                Console.WriteLine("5. Staff Management");

            }



            Console.WriteLine("6. Exit");

        }

    }

}