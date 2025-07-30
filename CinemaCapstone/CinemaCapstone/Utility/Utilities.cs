// Utility/Utilities.cs

using System;

using System.Collections.Generic;

using System.Linq;



namespace Capstone.Utility

{

    public static class Utilities

    {

        public static int GetIntegerInput(string prompt, int min = int.MinValue, int max = int.MaxValue)

        {

            while (true)

            {

                Console.Write(prompt);

                if (int.TryParse(Console.ReadLine(), out int result) && result >= min && result <= max)

                {

                    return result;

                }

                Console.WriteLine($"Invalid input. Please enter a number between {min} and {max}.");

            }

        }



        public static string GetStringInput(string prompt, bool allowEmpty = false)

        {

            while (true)

            {

                Console.Write(prompt);

                string input = Console.ReadLine();

                if (allowEmpty || !string.IsNullOrWhiteSpace(input))

                {

                    return input;

                }

                Console.WriteLine("Input cannot be empty. Please try again.");

            }

        }



        public static DateTime GetDateInput(string prompt)

        {

            while (true)

            {

                Console.Write(prompt);

                if (DateTime.TryParse(Console.ReadLine(), out DateTime result))

                {

                    return result.Date;

                }

                Console.WriteLine("Invalid date format. Please try again (dd/mm/yyyy).");

            }

        }



        public static DateTime GetTimeInput(string prompt)

        {

            while (true)

            {

                Console.Write(prompt);

                if (DateTime.TryParse(Console.ReadLine(), out DateTime result))

                {

                    return result;

                }

                Console.WriteLine("Invalid time format. Please try again (hh:mm).");

            }

        }



        public static T SelectFromList<T>(string prompt, List<T> items, Func<T, string> displayFunc)

        {

            Console.WriteLine(prompt);

            for (int i = 0; i < items.Count; i++)

            {

                Console.WriteLine($"{i + 1}. {displayFunc(items[i])}");

            }



            int choice = GetIntegerInput("Enter your choice: ", 1, items.Count);

            return items[choice - 1];

        }

    }

}