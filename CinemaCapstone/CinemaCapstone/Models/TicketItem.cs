// Models/TicketItem.cs

namespace Capstone.Models

{

    public class TicketItem

    {

        public Screening Screening { get; set; }

        public bool IsPremium { get; set; }

        public int CustomerAge { get; set; }

        public int Price { get; set; }

        public bool IsFree { get; set; }

    }

}