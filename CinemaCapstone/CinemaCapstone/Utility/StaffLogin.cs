// Utility/StaffLogin.cs

using System;

using System.Linq;

using Capstone.Models;



namespace Capstone.Utility

{

    public static class StaffLogin

    {

        public static Staff Authenticate(List<Staff> staffList)
         

        {

            Console.WriteLine("Staff Login");

            Console.WriteLine("===========");
            Console.WriteLine("staffdata",staffList);


            while (true)

            {

                Console.WriteLine("\nAvailable Staff:");

                for (int i = 0; i < staffList.Count; i++)

                {

                    Console.WriteLine($"{i + 1}. {staffList[i]} (ID: {staffList[i].StaffId})");

                }



                int choice = Utilities.GetIntegerInput("\nSelect your staff number (0 to exit): ", 0, staffList.Count);

                if (choice == 0) return null;



                var selectedStaff = staffList[choice - 1];

                Console.WriteLine($"\nWelcome, {selectedStaff}!");



                return selectedStaff;

            }

        }

    }

}