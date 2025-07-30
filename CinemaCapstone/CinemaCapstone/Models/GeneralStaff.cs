// Models/GeneralStaff.cs

namespace Capstone.Models

{

    public class GeneralStaff : Staff

    {

        public override bool CanEditSchedule => false;

        public override bool CanEditConcession => false;

        public override bool CanEditStaff => false;

    }

}