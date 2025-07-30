// Workflows/ConcessionsWorkflow.cs

using System;

using System.Collections.Generic;

using System.Linq;

using Capstone.Models;

using Capstone.Utility;



namespace Capstone.Workflows

{

    public static class ConcessionsWorkflow

    {

        public static void Execute(Cinema cinema, Staff staff)

        {

            if (staff is Manager)

            {

                Console.WriteLine("\nConcession Management");

                Console.WriteLine("====================");

                Console.WriteLine("1. Add Concession");

                Console.WriteLine("2. Remove Concession");

                Console.WriteLine("3. Edit Concession Price");

                Console.WriteLine("4. Back to Main Menu");



                int choice = Utilities.GetIntegerInput("Enter your choice: ", 1, 4);

                switch (choice)

                {

                    case 1:

                        AddConcession(cinema);

                        break;

                    case 2:

                        RemoveConcession(cinema);

                        break;

                    case 3:

                        EditConcessionPrice(cinema);

                        break;

                    case 4:

                        return;

                }

            }

        }



        private static void AddConcession(Cinema cinema)

        {

            try

            {

                string name = Utilities.GetStringInput("Enter concession name: ");

                int price = Utilities.GetIntegerInput("Enter price in pence: ", 1);



                var concession = new Concession { Name = name, Price = price };

                cinema.Concessions.Add(concession);

                Console.WriteLine("Concession added successfully.");

            }

            catch (Exception ex)

            {

                Console.WriteLine($"Error: {ex.Message}");

            }

        }



        private static void RemoveConcession(Cinema cinema)

        {

            if (cinema.Concessions.Count == 0)

            {

                Console.WriteLine("No concessions available to remove.");

                return;

            }



            var concession = Utilities.SelectFromList("Select concession to remove:", cinema.Concessions, c => $"{c.Name} (£{c.Price / 100.0:F2})");

            cinema.Concessions.Remove(concession);

            Console.WriteLine("Concession removed successfully.");

        }



        private static void EditConcessionPrice(Cinema cinema)

        {

            if (cinema.Concessions.Count == 0)

            {

                Console.WriteLine("No concessions available to edit.");

                return;

            }



            var concession = Utilities.SelectFromList("Select concession to edit:", cinema.Concessions, c => $"{c.Name} (£{c.Price / 100.0:F2})");

            int newPrice = Utilities.GetIntegerInput("Enter new price in pence: ", 1);

            concession.Price = newPrice;

            Console.WriteLine("Concession price updated successfully.");

        }

    }

}