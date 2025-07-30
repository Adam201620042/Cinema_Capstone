// Models/Transaction.cs

using System;

using System.Collections.Generic;

using System.Linq;



namespace Capstone.Models

{

    public class Transaction

    {

        public int TransactionNumber { get; }

        public Staff Staff { get; }

        public Member Member { get; private set; }

        public List<TicketItem> Tickets { get; } = new List<TicketItem>();

        public List<ConcessionItem> Concessions { get; } = new List<ConcessionItem>();

        public DateTime TransactionDate { get; } = DateTime.Now;

        public bool IsFinalised { get; private set; }



        public Transaction(int transactionNumber, Staff staff)

        {

            TransactionNumber = transactionNumber;

            Staff = staff;

        }



        public void AddMember(Member member)

        {

            Member = member;

            member.RecordVisit();

        }



        public void AddTicket(Screening screening, bool isPremium, int customerAge, Cinema cinema)

        {

            if (Member != null && !isPremium && Member.IsFreeStandardTicketAvailable())

            {

                Tickets.Add(new TicketItem

                {

                    Screening = screening,

                    IsPremium = false,

                    CustomerAge = customerAge,

                    Price = 0,

                    IsFree = true

                });

                Member.ResetFreeTicket();

            }

            else

            {

                Tickets.Add(new TicketItem

                {

                    Screening = screening,

                    IsPremium = isPremium,

                    CustomerAge = customerAge,

                    Price = isPremium ? cinema.PremiumTicketPrice : cinema.StandardTicketPrice,

                    IsFree = false

                });

            }

        }



        public void AddConcession(Concession concession, int quantity)

        {

            var existing = Concessions.FirstOrDefault(c => c.Concession.Name == concession.Name);

            if (existing != null)

            {

                existing.Quantity += quantity;

                existing.CalculateTotal(Member?.IsGoldMember ?? false);

            }

            else

            {

                var item = new ConcessionItem

                {

                    Concession = concession,

                    Quantity = quantity

                };

                item.CalculateTotal(Member?.IsGoldMember ?? false);

                Concessions.Add(item);

            }

        }



        public int CalculateTotal()

        {

            int total = Tickets.Sum(t => t.Price) + Concessions.Sum(c => c.TotalPrice);

            return total;

        }



        public void Finalise()

        {

            foreach (var ticket in Tickets)

            {

                ticket.Screening.BookSeats(ticket.IsPremium, 1);

            }

            IsFinalised = true;

        }



        public string GenerateReceipt()

        {

            string receipt = $@"--- Receipt ---

=================================

       HULL-YWOOD CINEMA

=================================

Transaction: {TransactionNumber}

Date: {TransactionDate:dd/MM/yyyy HH:mm:ss}

Staff: {Staff}

---------------------------------

TICKETS:

";



            foreach (var ticket in Tickets)

            {

                receipt += $"  {ticket.Screening.Movie.Title} ({ticket.Screening.Movie.Rating})\n" +

                           $"    Screen: {ticket.Screening.Screen.ScreenId} | {ticket.Screening.StartTime:HH:mm}\n" +

                           $"    {(ticket.IsPremium ? "Premium Seat" : "Standard Seat")}\n" +

                           $"    Price: {(ticket.IsFree ? "FREE" : $"£{ticket.Price / 100.0:F2}")}\n";

            }



            receipt += "---------------------------------\nCONCESSIONS:\n";



            foreach (var concession in Concessions)

            {

                receipt += $"  {concession.Quantity}x {concession.Concession.Name}\n" +

                           $"    Price: £{concession.Concession.GetDiscountedPrice(Member?.IsGoldMember ?? false) / 100.0:F2}\n" +

                           $"    Total: £{concession.TotalPrice / 100.0:F2}\n";

            }



            receipt += $"---------------------------------\nTOTAL: £{CalculateTotal() / 100.0:F2}\n" +

                       "=================================\n" +

                       "        THANK YOU!\n" +

                       "=================================";



            return receipt;

        }

    }

}