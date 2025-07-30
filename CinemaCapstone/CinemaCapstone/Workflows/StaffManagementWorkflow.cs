// Workflows/StaffManagementWorkflow.cs

using System;

using System.Linq;

using Capstone.Models;

using Capstone.Utility;



namespace Capstone.Workflows

{

    public static class StaffManagementWorkflow

    {

        public static void Execute(Cinema cinema)

        {

            Console.WriteLine("\nStaff Management");

            Console.WriteLine("===============");

            Console.WriteLine("1. Add Staff");

            Console.WriteLine("2. Remove Staff");

            Console.WriteLine("3. View Staff");

            Console.WriteLine("4. Back to Main Menu");



            int choice = Utilities.GetIntegerInput("Enter your choice: ", 1, 4);

            switch (choice)

            {

                case 1:

                    AddStaff(cinema);

                    break;

                case 2:

                    RemoveStaff(cinema);

                    break;

                case 3:

                    ViewStaff(cinema);

                    break;

                case 4:

                    return;

            }

        }



        public static void ManageSchedule(Cinema cinema)

        {

            Console.WriteLine("\nManage Schedule");

            Console.WriteLine("==============");

            Console.WriteLine("1. Add Screening");

            Console.WriteLine("2. Remove Screening");

            Console.WriteLine("3. View Screenings");

            Console.WriteLine("4. Back to Main Menu");



            int choice = Utilities.GetIntegerInput("Enter your choice: ", 1, 4);

            switch (choice)

            {

                case 1:

                    AddScreening(cinema);

                    break;

                case 2:

                    RemoveScreening(cinema);

                    break;

                case 3:

                    ViewScreenings(cinema);

                    break;

                case 4:

                    return;

            }

        }



        private static void AddStaff(Cinema cinema)

        {

            try

            {

                Console.WriteLine("\nAdd New Staff");

                Console.WriteLine("------------");



                string staffId = Utilities.GetStringInput("Staff ID (6 digits): ");

                if (cinema.Staff.Any(s => s.StaffId == staffId))

                {

                    Console.WriteLine("Staff ID already exists.");

                    return;

                }



                string firstName = Utilities.GetStringInput("First Name: ");

                string lastName = Utilities.GetStringInput("Last Name: ");



                Console.WriteLine("Staff Level:");

                Console.WriteLine("1. General Staff");

                Console.WriteLine("2. Manager");

                int levelChoice = Utilities.GetIntegerInput("Enter choice: ", 1, 2);



                Staff newStaff = levelChoice == 2 ? new Manager() : new GeneralStaff();

                newStaff.StaffId = staffId;

                newStaff.FirstName = firstName;

                newStaff.LastName = lastName;



                cinema.Staff.Add(newStaff);

                Console.WriteLine("Staff added successfully.");

            }

            catch (Exception ex)

            {

                Console.WriteLine($"Error: {ex.Message}");

            }

        }



        private static void RemoveStaff(Cinema cinema)

        {

            if (cinema.Staff.Count == 0)

            {

                Console.WriteLine("No staff available to remove.");

                return;

            }



            var staff = Utilities.SelectFromList("Select staff to remove:", cinema.Staff,

                s => $"{s.FirstName} {s.LastName} (ID: {s.StaffId}) - {(s is Manager ? "Manager" : "General Staff")}");



            cinema.Staff.Remove(staff);

            Console.WriteLine("Staff removed successfully.");

        }



        private static void ViewStaff(Cinema cinema)

        {

            if (cinema.Staff.Count == 0)

            {

                Console.WriteLine("No staff registered.");

                return;

            }



            Console.WriteLine("\nStaff List");

            Console.WriteLine("----------");

            foreach (var staff in cinema.Staff.OrderBy(s => s.LastName))

            {

                Console.WriteLine($"{staff.FirstName} {staff.LastName} (ID: {staff.StaffId}) - {(staff is Manager ? "Manager" : "General Staff")}");

            }

        }



        private static void AddScreening(Cinema cinema)

        {

            try

            {

                Console.WriteLine("\nAdd New Screening");

                Console.WriteLine("----------------");



                if (cinema.Movies.Count == 0)

                {

                    Console.WriteLine("No movies available. Please add movies first.");

                    return;

                }



                if (cinema.Screens.Count == 0)

                {

                    Console.WriteLine("No screens available. Please add screens first.");

                    return;

                }



                var movie = Utilities.SelectFromList("Select movie:", cinema.Movies, m => $"{m.Title} ({m.Rating}) - {m.Length} mins");

                var screen = Utilities.SelectFromList("Select screen:", cinema.Screens, s => $"Screen {s.ScreenId} - {s.NumStandardSeats} standard, {s.NumPremiumSeats} premium");



                DateTime date = Utilities.GetDateInput("Enter date (dd/mm/yyyy): ");

                DateTime startTime = Utilities.GetTimeInput("Enter start time (hh:mm): ");



                // Combine date and time

                DateTime screeningStart = date.Add(startTime.TimeOfDay);

                DateTime screeningEnd = screeningStart.AddMinutes(movie.Length);



                // Add trailers and turnaround time

                screeningEnd = screeningEnd.AddMinutes(20); // Trailers

                screeningEnd = screeningEnd.AddMinutes(screen.TurnaroundTime);



                // Check for conflicts

                foreach (var existing in cinema.Screenings)

                {

                    if (existing.Screen.ScreenId == screen.ScreenId &&

                        ((screeningStart >= existing.StartTime && screeningStart < existing.EndTime) ||

                        (screeningEnd > existing.StartTime && screeningEnd <= existing.EndTime) ||

                        (screeningStart <= existing.StartTime && screeningEnd >= existing.EndTime)))

                    {

                        Console.WriteLine($"Conflict with existing screening: {existing.Movie.Title} in Screen {existing.Screen.ScreenId} from {existing.StartTime} to {existing.EndTime}");

                        return;

                    }

                }



                var screening = new Screening

                {

                    Movie = movie,

                    Screen = screen,

                    StartTime = screeningStart,

                    EndTime = screeningEnd,

                    AvailableStandardSeats = screen.NumStandardSeats,

                    AvailablePremiumSeats = screen.NumPremiumSeats

                };



                cinema.AddScreening(screening);

                Console.WriteLine("Screening added successfully.");



                // Save schedule for the day

                cinema.SaveSchedule(date.ToString("dd/MM/yyyy"));

            }

            catch (Exception ex)

            {

                Console.WriteLine($"Error: {ex.Message}");

            }

        }



        private static void RemoveScreening(Cinema cinema)

        {

            if (cinema.Screenings.Count == 0)

            {

                Console.WriteLine("No screenings scheduled.");

                return;

            }



            var screening = Utilities.SelectFromList("Select screening to remove:", cinema.Screenings,

                s => $"{s.Movie.Title} - Screen {s.Screen.ScreenId} - {s.StartTime:dd/MM/yyyy HH:mm}");



            cinema.Screenings.Remove(screening);

            Console.WriteLine("Screening removed successfully.");



            // Save schedule for the day

            cinema.SaveSchedule(screening.StartTime.ToString("dd/MM/yyyy"));

        }



        private static void ViewScreenings(Cinema cinema)

        {

            if (cinema.Screenings.Count == 0)

            {

                Console.WriteLine("No screenings scheduled.");

                return;

            }



            Console.WriteLine("\nScheduled Screenings");

            Console.WriteLine("-------------------");

            foreach (var screening in cinema.Screenings.OrderBy(s => s.StartTime))

            {

                Console.WriteLine($"{screening.Movie.Title} ({screening.Movie.Rating}) - {screening.Movie.Length} mins");

                Console.WriteLine($"  Screen {screening.Screen.ScreenId} - {screening.StartTime:dd/MM/yyyy HH:mm} to {screening.EndTime:HH:mm}");

                Console.WriteLine($"  Available: {screening.AvailableStandardSeats} standard, {screening.AvailablePremiumSeats} premium");

                Console.WriteLine();

            }

        }

    }

}