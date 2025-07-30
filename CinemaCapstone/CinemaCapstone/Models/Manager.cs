// Models/Manager.cs

namespace Capstone.Models

{

    public class Manager : Staff

    {

        public override bool CanEditSchedule => true;

        public override bool CanEditConcession => true;

        public override bool CanEditStaff => true;

    }

}
