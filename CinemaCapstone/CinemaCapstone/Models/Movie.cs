// Models/Movie.cs

using System;

using System.Collections.Generic;

using System.IO;

using System.Linq;



namespace Capstone.Models

{

    public class Movie

    {

        private string _title;

        private int _length;

        private string _rating;



        public string Title

        {

            get => _title;

            set

            {

                if (string.IsNullOrWhiteSpace(value))

                {

                    throw new ArgumentException("Title must be at least 1 character long");

                }

                _title = value;

            }

        }



        public int Length

        {

            get => _length;

            set

            {

                if (value <= 0)

                {

                    throw new ArgumentException("Length must be a positive number");

                }

                _length = value;

            }

        }



        public string Genre { get; set; }



        public string Rating

        {

            get => _rating;

            set

            {

                if (value != "U" && value != "12" && value != "15" && value != "18")

                {

                    throw new ArgumentException("Rating must be U, 12, 15 or 18");

                }

                _rating = value;

            }

        }



        public bool IsAgeAppropriate(int age)

        {

            return Rating switch

            {

                "U" => true,

                "12" => age >= 12,

                "15" => age >= 15,

                "18" => age >= 18,

                _ => false

            };

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

                            case "Title":

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

    }

}