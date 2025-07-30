// Models/ConcessionItem.cs

namespace Capstone.Models

{

    public class ConcessionItem

    {

        public Concession Concession { get; set; }

        public int Quantity { get; set; }

        public int TotalPrice { get; set; }



        public void CalculateTotal(bool isGoldMember)

        {

            TotalPrice = Concession.GetDiscountedPrice(isGoldMember) * Quantity;

        }

    }

}