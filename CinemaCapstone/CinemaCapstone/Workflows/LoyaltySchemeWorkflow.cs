// Workflows/LoyaltySchemeWorkflow.cs

using System;

using System.Linq;

using Capstone.Models;

using Capstone.Utility;



namespace Capstone.Workflows

{

    public static class LoyaltySchemeWorkflow

    {

        public static void Execute(Cinema cinema, Staff staff)

        {

            Console.WriteLine("\nLoyalty Scheme");

            Console.WriteLine("=============");

            Console.WriteLine("1. Register New Member");

            Console.WriteLine("2. View Member Details");

            Console.WriteLine("3. Back to Main Menu");



            int choice = Utilities.GetIntegerInput("Enter your choice: ", 1, 3);

            switch (choice)

            {

                case 1:

                    RegisterNewMember(cinema);

                    break;

                case 2:

                    ViewMemberDetails(cinema);

                    break;

                case 3:

                    return;

            }

        }



        private static void RegisterNewMember(Cinema cinema)

        {

            try

            {

                Console.WriteLine("\nRegister New Member");

                Console.WriteLine("------------------");



                string firstName = Utilities.GetStringInput("First Name: ");

                string lastName = Utilities.GetStringInput("Last Name: ");

                string email = Utilities.GetStringInput("Email: ");



                if (cinema.Members.Any(m => m.Email == email))

                {

                    Console.WriteLine("A member with this email already exists.");

                    return;

                }



                var member = new Member

                {

                    FirstName = firstName,

                    LastName = lastName,

                    Email = email

                };



                cinema.Members.Add(member);

                DataLoader.SaveMembers("Resources/members.txt", cinema);



                Console.WriteLine($"\nNew member registered successfully. Membership number: {member.MemberNumber}");

            }

            catch (Exception ex)

            {

                Console.WriteLine($"Error: {ex.Message}");

            }

        }



        private static void ViewMemberDetails(Cinema cinema)

        {

            if (cinema.Members.Count == 0)

            {

                Console.WriteLine("No members registered yet.");

                return;

            }



            var member = Utilities.SelectFromList("Select member:", cinema.Members,

                m => $"{m.FirstName} {m.LastName} (Member: {m.MemberNumber})");



            Console.WriteLine($"\nMember Details");

            Console.WriteLine("-------------");

            Console.WriteLine($"Name: {member.FirstName} {member.LastName}");

            Console.WriteLine($"Email: {member.Email}");

            Console.WriteLine($"Member Number: {member.MemberNumber}");

            Console.WriteLine($"Visits: {member.VisitCount}");

            Console.WriteLine($"Status: {(member.IsGoldMember ? $"Gold (expires {member.GoldMembershipExpiry:dd/MM/yyyy})" : "Standard")}");

            if (!member.IsGoldMember && member.VisitCount >= 10)

            {

                Console.WriteLine("This member is eligible for a free standard ticket on their next visit!");

            }

        }

    }

}