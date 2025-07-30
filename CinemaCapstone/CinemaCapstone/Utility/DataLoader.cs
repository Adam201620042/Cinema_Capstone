// Utility/DataLoader.cs (updated)

using System;

using System.IO;

using System.Linq;

using Capstone.Models;



namespace Capstone.Utility

{

    public static class DataLoader

    {

        public static Cinema LoadCinema(string filename)

        {

            var cinema = new Cinema();



            if (!File.Exists(filename)) return cinema;



            foreach (var line in File.ReadAllLines(filename))

            {

                if (line.StartsWith("[Name:") && line.EndsWith("]"))

                {

                    cinema.Name = line[6..^1];

                }

                else if (line.StartsWith("[Screen:") && line.EndsWith("]"))

                {

                    var parts = line[8..^1].Split('%');

                    var screen = new Screen();



                    foreach (var part in parts)

                    {

                        var keyValue = part.Split(':');

                        switch (keyValue[0])

                        {

                            case "Screen":

                                screen.ScreenId = keyValue[1][0];

                                break;

                            case "NumPremiumSeat":

                                screen.NumPremiumSeats = int.Parse(keyValue[1]);

                                screen.AvailablePremiumSeats = screen.NumPremiumSeats;

                                break;

                            case "NumStandardSeat":

                                screen.NumStandardSeats = int.Parse(keyValue[1]);

                                screen.AvailableStandardSeats = screen.NumStandardSeats;

                                break;

                        }

                    }



                    cinema.Screens.Add(screen);

                }

                else if (line.StartsWith("[Staff:") && line.EndsWith("]"))

                {

                    var parts = line[7..^1].Split('%');

                    Staff staff = null;



                    foreach (var part in parts)

                    {

                        var keyValue = part.Split(':');

                        if (keyValue[0] == "Level")

                        {

                            staff = keyValue[1] == "Manager" ? new Manager() : new GeneralStaff();

                            break;

                        }

                    }



                    if (staff == null) continue;



                    foreach (var part in parts)

                    {

                        var keyValue = part.Split(':');

                        switch (keyValue[0])

                        {

                            case "Staff":

                                staff.StaffId = keyValue[1];

                                break;

                            case "FirstName":

                                staff.FirstName = keyValue[1];

                                break;

                            case "LastName":

                                staff.LastName = keyValue[1];

                                break;

                        }

                    }



                    cinema.Staff.Add(staff);

                }

                else if (line.StartsWith("[Ticket:") && line.EndsWith("]"))

                {

                    var parts = line[8..^1].Split(':');

                    foreach (var part in parts)

                    {

                        var keyValue = part.Split('%');

                        switch (keyValue[0])

                        {

                            case "Standard":

                                cinema.StandardTicketPrice = int.Parse(keyValue[1]);

                                break;

                            case "Premium":

                                cinema.PremiumTicketPrice = int.Parse(keyValue[1]);

                                break;

                        }

                    }

                }

                else if (line.StartsWith("[Concession:") && line.EndsWith("]"))

                {

                    var parts = line[12..^1].Split('%');

                    var concession = new Concession();



                    foreach (var part in parts)

                    {

                        var keyValue = part.Split(':');

                        switch (keyValue[0])

                        {

                            case "Concession":

                                concession.Name = keyValue[1];

                                break;

                            case "Price":

                                concession.Price = int.Parse(keyValue[1]);

                                break;

                        }

                    }



                    cinema.Concessions.Add(concession);

                }

            }



            return cinema;

        }



        public static void LoadMovies(string filename, Cinema cinema)

        {

            if (!File.Exists(filename)) return;



            foreach (var line in File.ReadAllLines(filename))

            {

                if (line.StartsWith("[Movie:") && line.EndsWith("]"))

                {

                    var parts = line[7..^1].Split('%');

                    var movie = new Movie();



                    foreach (var part in parts)

                    {

                        var keyValue = part.Split(':');

                        switch (keyValue[0])

                        {

                            case "Movie":

                                movie.Title = keyValue[1];

                                break;

                            case "Length":

                                movie.Length = int.Parse(keyValue[1]);

                                break;

                            case "Genre":

                                movie.Genre = keyValue[1];

                                break;

                            case "Rating":

                                movie.Rating = keyValue[1];

                                break;

                        }

                    }



                    if (!cinema.Movies.Any(m => m.Title == movie.Title))

                    {

                        cinema.Movies.Add(movie);

                    }

                }

            }

        }



        public static void LoadMembers(string filename, Cinema cinema)

        {

            if (!File.Exists(filename)) return;



            foreach (var line in File.ReadAllLines(filename))

            {

                if (line.StartsWith("[Member:") && line.EndsWith("]"))

                {

                    var parts = line[8..^1].Split('%');

                    var member = new Member();



                    foreach (var part in parts)

                    {

                        var keyValue = part.Split(':');

                        switch (keyValue[0])

                        {

                            case "FirstName":

                                member.FirstName = keyValue[1];

                                break;

                            case "LastName":

                                member.LastName = keyValue[1];

                                break;

                            case "Email":

                                member.Email = keyValue[1];

                                break;

                            case "MemberNumber":

                                // Skip as it's generated in constructor

                                break;

                            case "VisitCount":

                                member.VisitCount = int.Parse(keyValue[1]);

                                break;

                            case "GoldExpiry":

                                if (DateTime.TryParse(keyValue[1], out var expiry))

                                {

                                    member.GoldMembershipExpiry = expiry;

                                }

                                break;

                        }

                    }



                    if (!cinema.Members.Any(m => m.Email == member.Email))

                    {

                        cinema.Members.Add(member);

                    }

                }

            }

        }



        public static void SaveMembers(string filename, Cinema cinema)

        {

            using (var writer = new StreamWriter(filename))

            {

                foreach (var member in cinema.Members)

                {

                    writer.WriteLine($"[Member:FirstName:{member.FirstName}%LastName:{member.LastName}%Email:{member.Email}%MemberNumber:{member.MemberNumber}%VisitCount:{member.VisitCount}%GoldExpiry:{(member.GoldMembershipExpiry.HasValue ? member.GoldMembershipExpiry.Value.ToString("yyyy-MM-dd") : "")}]");

                }

            }

        }

    }

}