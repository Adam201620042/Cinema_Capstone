// Models/Member.cs (updated)

using System;

using System.Text.RegularExpressions;



namespace Capstone.Models

{

    public class Member

    {

        private string _firstName;

        private string _lastName;

        private string _email;

        private DateTime? _goldMembershipExpiry;



        public string MemberNumber { get; } = GenerateMemberNumber();

        public int VisitCount { get; set; } // Changed from private set to public set

        public bool IsGoldMember => _goldMembershipExpiry.HasValue && _goldMembershipExpiry > DateTime.Now;



        public string FirstName

        {

            get => _firstName;

            set

            {

                if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, @"^[A-Z][a-zA-Z]*$"))

                {

                    throw new ArgumentException("First name must start with capital letter and contain only letters");

                }

                _firstName = value;

            }

        }



        public string LastName

        {

            get => _lastName;

            set

            {

                if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, @"^[A-Z][a-zA-Z]*$"))

                {

                    throw new ArgumentException("Last name must start with capital letter and contain only letters");

                }

                _lastName = value;

            }

        }



        public string Email

        {

            get => _email;

            set

            {

                if (!IsValidEmail(value))

                {

                    throw new ArgumentException("Invalid email format");

                }

                _email = value;

            }

        }



        public DateTime? GoldMembershipExpiry

        {

            get => _goldMembershipExpiry;

            set => _goldMembershipExpiry = value;

        }



        private static string GenerateMemberNumber()

        {

            return "M" + DateTime.Now.ToString("yyMMddHHmmss");

        }



        private bool IsValidEmail(string email)

        {

            if (string.IsNullOrWhiteSpace(email)) return false;

            if (email.StartsWith(".") || email.StartsWith("@") || email.EndsWith(".") || email.EndsWith("@")) return false;

            if (email.Count(c => c == '@') != 1) return false;

            if (email.Contains("..") || email.Contains(".@") || email.Contains("@.")) return false;



            return Regex.IsMatch(email, @"^[a-zA-Z0-9.@]+$");

        }



        public void RecordVisit()

        {

            VisitCount++;

        }



        public void UpgradeToGold(int years)

        {

            GoldMembershipExpiry = DateTime.Now.AddYears(years);

        }



        public bool IsFreeStandardTicketAvailable()

        {

            return VisitCount >= 10 && !IsGoldMember;

        }



        public void ResetFreeTicket()

        {

            if (IsFreeStandardTicketAvailable())

            {

                VisitCount = 0;

            }

        }

    }

}