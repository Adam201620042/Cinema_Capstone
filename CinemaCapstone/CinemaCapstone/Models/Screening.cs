// Models/Screening.cs

using System;



namespace Capstone.Models

{

    public class Screening

    {

        public Movie Movie { get; set; }

        public Screen Screen { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int AvailableStandardSeats { get; set; }

        public int AvailablePremiumSeats { get; set; }



        public bool BookSeats(bool isPremium, int quantity)

        {

            if (isPremium)

            {

                if (AvailablePremiumSeats >= quantity)

                {

                    AvailablePremiumSeats -= quantity;

                    return true;

                }

            }

            else

            {

                if (AvailableStandardSeats >= quantity)

                {

                    AvailableStandardSeats -= quantity;

                    return true;

                }

            }

            return false;

        }

    }

}