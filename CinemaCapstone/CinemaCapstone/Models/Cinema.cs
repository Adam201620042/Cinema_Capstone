// Models/Cinema.cs

using System;

using System.Collections;

using System.Collections.Generic;

using System.IO;

using Microsoft.VisualBasic;



namespace Capstone.Models

{

    public class Cinema

    {

        public string Name { get; set; }

        public List<Screen> Screens { get; set; } = new List<Screen>();

        public List<Staff> Staff { get; set; } = new List<Staff>();

        public List<Concession> Concessions { get; set; } = new List<Concession>();

        public List<Member> Members { get; set; } = new List<Member>();

        public List<Movie> Movies { get; set; } = new List<Movie>();

        public List<Screening> Screenings { get; set; } = new List<Screening>();

        public int StandardTicketPrice { get; set; }

        public int PremiumTicketPrice { get; set; }



        public void AddScreening(Screening screening)

        {

            // Check for schedule conflicts

            foreach (var existing in Screenings)

            {

                if (existing.Screen.ScreenId == screening.Screen.ScreenId &&

                    ((screening.StartTime >= existing.StartTime && screening.StartTime < existing.EndTime) ||

                    (screening.EndTime > existing.StartTime && screening.EndTime <= existing.EndTime) ||

                    (screening.StartTime <= existing.StartTime && screening.EndTime >= existing.EndTime)))

                {

                    throw new Exception("Screening conflicts with existing schedule");

                }

            }

            Screenings.Add(screening);

        }



        public void SaveSchedule(string date)

        {

            string filename = $"Resources/schedule_{date.Replace("/", "")}.fs";

            using (StreamWriter writer = new StreamWriter(filename))

            {

                foreach (var screening in Screenings)

                {

                    if (screening.StartTime.ToString("dd/MM/yyyy") == date)

                    {

                        writer.WriteLine($"[Screening:{screening.Movie.Title}%Screen:{screening.Screen.ScreenId}%Start:{screening.StartTime:HH:mm}%End:{screening.EndTime:HH:mm}]");

                    }

                }

            }

        }



        public void LoadSchedule(string date)

        {

            string filename = $"Resources/schedule_{date.Replace("/", "")}.fs";

            if (!File.Exists(filename)) return;



            Screenings.RemoveAll(s => s.StartTime.ToString("dd/MM/yyyy") == date);



            foreach (var line in File.ReadAllLines(filename))

            {

                if (line.StartsWith("[Screening:") && line.EndsWith("]"))

                {

                    var parts = line[11..^1].Split('%');

                    string movieTitle = parts[0];

                    char screenId = parts[1].Split(':')[1][0];

                    string startTime = parts[2].Split(':')[1];

                    string endTime = parts[3].Split(':')[1];



                    var movie = Movies.Find(m => m.Title == movieTitle);

                    var screen = Screens.Find(s => s.ScreenId == screenId);



                    if (movie != null && screen != null)

                    {

                        var screening = new Screening

                        {

                            Movie = movie,

                            Screen = screen,

                            StartTime = DateTime.Parse($"{date} {startTime}"),

                            EndTime = DateTime.Parse($"{date} {endTime}")

                        };

                        Screenings.Add(screening);

                    }

                }

            }

        }

    }

}