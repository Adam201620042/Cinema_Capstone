// Program.cs

using System;

using Capstone.Menu;

using Capstone.Models;

using Capstone.Utility;

using Capstone.Workflows;



namespace Capstone

{

    class Program

    {

        static void Main(string[] args)

        {

            // Load initial data

            Cinema cinema = DataLoader.LoadCinema("../../../Resources/cinema.txt");
            Console.WriteLine("Cinemadata", cinema);


            DataLoader.LoadMovies("../../../Resources/movies.txt", cinema);



            // Staff login

            Staff staff = StaffLogin.Authenticate(cinema.Staff);

            if (staff == null)

            {

                Console.WriteLine("Login failed. Exiting application.");

                return;

            }



            bool exit = false;

            while (!exit)

            {

                Console.Clear();

                MainMenu.Display(staff is Manager);

                int choice = Utilities.GetIntegerInput("Enter your choice: ", 1, staff is Manager ? 5 : 4);



                switch (choice)

                {

                    case 1: // Sell tickets and concessions

                        SellingTicketsWorkflow.Execute(cinema, staff);

                        break;

                    case 2: // Manage schedule (Manager only)

                        if (staff is Manager)

                        {

                            StaffManagementWorkflow.ManageSchedule(cinema);

                        }

                        break;

                    case 3: // Loyalty scheme

                        LoyaltySchemeWorkflow.Execute(cinema, staff);

                        break;

                    case 4: // Gold membership

                        GoldMembershipWorkflow.Execute(cinema, staff);

                        break;

                    case 5: // Staff management (Manager only)

                        if (staff is Manager)

                        {

                            StaffManagementWorkflow.Execute(cinema);

                        }

                        break;

                    case 6: // Exit

                        exit = true;

                        break;

                }

            }

        }

    }

}