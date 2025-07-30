// Models/Staff.cs

using System.Text.RegularExpressions;



namespace Capstone.Models

{

    public abstract class Staff

    {

        private string _staffId;

        private string _firstName;

        private string _lastName;



        public string StaffId

        {

            get => _staffId;

            set

            {

                if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, @"^\d{6}$"))

                {

                    throw new ArgumentException("Staff ID must be 6 digits");

                }

                _staffId = value;

            }

        }



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



        public abstract bool CanEditSchedule { get; }

        public abstract bool CanEditConcession { get; }

        public abstract bool CanEditStaff { get; }



        public override string ToString()

        {

            return $"{FirstName} {LastName}";

        }

    }

}