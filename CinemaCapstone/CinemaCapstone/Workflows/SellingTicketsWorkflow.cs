// Workflows/SellingTicketsWorkflow.cs

using System;

using System.Collections.Generic;

using System.Linq;

using Capstone.Models;

using Capstone.Utility;



namespace Capstone.Workflows

{

    public static class SellingTicketsWorkflow

    {

        public static void Execute(Cinema cinema, Staff staff)

        {

            Console.WriteLine("\nSelling Tickets and Concessions");

            Console.WriteLine("==============================");



            // Select screening

            if (cinema.Screenings.Count == 0)

            {

                Console.WriteLine("No screenings scheduled. Please check back later.");

                return;

            }



            // Filter screenings to those in the future

            var futureScreenings = cinema.Screenings

                .Where(s => s.StartTime > DateTime.Now)

                .OrderBy(s => s.StartTime)

                .ToList();



            if (futureScreenings.Count == 0)

            {

                Console.WriteLine("No upcoming screenings. Please check back later.");

                return;

            }



            var screening = Utilities.SelectFromList("Select a screening:", futureScreenings,

                s => $"{s.Movie.Title} ({s.Movie.Rating}) - Screen {s.Screen.ScreenId} - {s.StartTime:dd/MM/yyyy HH:mm} - " +

                     $"Standard: {s.AvailableStandardSeats}/{s.Screen.NumStandardSeats}, " +

                     $"Premium: {s.AvailablePremiumSeats}/{s.Screen.NumPremiumSeats}");



            // Check if member

            Member member = null;

            Console.Write("\nIs the customer a loyalty scheme member? (y/n): ");

            if (Console.ReadLine().ToLower() == "y")

            {

                if (cinema.Members.Count == 0)

                {

                    Console.WriteLine("No members registered yet.");

                }

                else

                {

                    member = Utilities.SelectFromList("Select member:", cinema.Members,

                        m => $"{m.FirstName} {m.LastName} (Member: {m.MemberNumber}) - Visits: {m.VisitCount}");

                }

            }



            // Create transaction

            var transaction = new Transaction(new Random().Next(1000, 9999), staff);

            if (member != null)

            {

                transaction.AddMember(member);

            }



            // Sell tickets

            Console.WriteLine("\nSelling Tickets");

            Console.WriteLine("--------------");

            int numTickets = Utilities.GetIntegerInput("How many tickets would you like to purchase? ", 1);



            for (int i = 0; i < numTickets; i++)

            {

                Console.WriteLine($"\nTicket {i + 1}:");

                bool isPremium = Utilities.GetStringInput("Premium ticket? (y/n): ").ToLower() == "y";



                if (isPremium && screening.AvailablePremiumSeats == 0)

                {

                    Console.WriteLine("No premium seats available for this screening.");

                    isPremium = false;

                }

                else if (!isPremium && screening.AvailableStandardSeats == 0)

                {

                    Console.WriteLine("No standard seats available for this screening.");

                    if (screening.AvailablePremiumSeats > 0)

                    {

                        isPremium = true;

                        Console.WriteLine("Premium seats are available.");

                    }

                    else

                    {

                        Console.WriteLine("No seats available for this screening.");

                        return;

                    }

                }



                int age = Utilities.GetIntegerInput("Enter customer age: ", 1, 120);

                if (!screening.Movie.IsAgeAppropriate(age))

                {

                    Console.WriteLine($"This film is rated {screening.Movie.Rating}. Customer is too young.");

                    i--; // Retry this ticket

                    continue;

                }



                transaction.AddTicket(screening, isPremium, age, cinema);

                Console.WriteLine($"Added {(isPremium ? "Premium" : "Standard")} ticket for {screening.Movie.Title}");

            }



            // Sell concessions

            Console.WriteLine("\nSelling Concessions");

            Console.WriteLine("------------------");

            while (true)

            {

                if (cinema.Concessions.Count == 0)

                {

                    Console.WriteLine("No concessions available.");

                    break;

                }



                Console.Write("\nAdd concession? (y/n): ");

                if (Console.ReadLine().ToLower() != "y") break;



                var concession = Utilities.SelectFromList("Select concession:", cinema.Concessions,

                    c => $"{c.Name} (£{c.Price / 100.0:F2})");



                int quantity = Utilities.GetIntegerInput($"How many {concession.Name}? ", 1);

                transaction.AddConcession(concession, quantity);

                Console.WriteLine($"Added {quantity}x {concession.Name}");

            }



            // Finalise transaction

            Console.WriteLine("\nTransaction Summary");

            Console.WriteLine("------------------");

            Console.WriteLine(transaction.GenerateReceipt());



            Console.Write("\nConfirm and finalise transaction? (y/n): ");

            if (Console.ReadLine().ToLower() == "y")

            {

                transaction.Finalise();

                Console.WriteLine("Transaction completed successfully.");



                // Save updated member data if applicable

                if (member != null)

                {

                    DataLoader.SaveMembers("Resources/members.txt", cinema);

                }

            }

            else

            {

                Console.WriteLine("Transaction cancelled.");

            }

        }

    }

}