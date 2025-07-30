// Models/Concession.cs

using System;

using System.Text.RegularExpressions;



namespace Capstone.Models

{

    public class Concession

    {

        private string _name;

        private int _price;



        public string Name

        {

            get => _name;

            set

            {

                if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, @"^[a-zA-Z0-9 ]+$"))

                {

                    throw new ArgumentException("Concession name can only contain letters, numbers and spaces");

                }

                _name = value;

            }

        }



        public int Price

        {

            get => _price;

            set

            {

                if (value <= 0)

                {

                    throw new ArgumentException("Price must be a positive number");

                }

                _price = value;

            }

        }



        public int GetDiscountedPrice(bool isGoldMember)

        {

            return isGoldMember ? (int)(Price * 0.75) : Price;

        }

    }

}
