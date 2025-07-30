// Workflows/GoldMembershipWorkflow.cs

using System;

using Capstone.Models;

using Capstone.Utility;



namespace Capstone.Workflows

{

    public static class GoldMembershipWorkflow

    {

        public static void Execute(Cinema cinema, Staff staff)

        {

            Console.WriteLine("\nGold Membership");

            Console.WriteLine("==============");



            if (cinema.Members.Count == 0)

            {

                Console.WriteLine("No members available. Please sign up for the loyalty scheme first.");

                return;

            }



            var member = Utilities.SelectFromList("Select member:", cinema.Members,

                m => $"{m.FirstName} {m.LastName} (Member: {m.MemberNumber}) - {(m.IsGoldMember ? $"Gold (expires {m.GoldMembershipExpiry:dd/MM/yyyy})" : "Standard")}");



            if (member.IsGoldMember)

            {

                Console.WriteLine($"This member is already a Gold member until {member.GoldMembershipExpiry:dd/MM/yyyy}");

                return;

            }



            Console.WriteLine($"\nUpgrading {member.FirstName} {member.LastName} to Gold membership");

            int years = Utilities.GetIntegerInput("Enter number of years for membership (1-5): ", 1, 5);

            member.UpgradeToGold(years);



            Console.WriteLine($"\n{member.FirstName} {member.LastName} is now a Gold member until {member.GoldMembershipExpiry:dd/MM/yyyy}");

            Console.WriteLine("They will receive 25% off all concessions during this period.");



            DataLoader.SaveMembers("Resources/members.txt", cinema);

        }

    }

}