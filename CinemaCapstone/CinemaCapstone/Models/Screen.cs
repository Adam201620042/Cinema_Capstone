// Models/Screen.cs

namespace Capstone.Models

{

    public class Screen

    {

        public char ScreenId { get; set; }

        public int NumPremiumSeats { get; set; }

        public int NumStandardSeats { get; set; }

        public int AvailablePremiumSeats { get; set; }

        public int AvailableStandardSeats { get; set; }



        public int TotalSeats => NumPremiumSeats + NumStandardSeats;

        public int TurnaroundTime => TotalSeats <= 50 ? 15 : TotalSeats <= 100 ? 30 : 45;

    }

}