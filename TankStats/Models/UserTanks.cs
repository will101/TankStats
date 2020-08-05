namespace TankStats.Models
{
    public class UserTanks
    {
        public int mark_of_mastery { get; set; }
        public string MasteryBadgeText { get; set; }

        public int tank_id { get; set; }

        public TankStatistics statistics { get; set; }

        public TankDetails tank_details { get; set; }
    }

    public class TankStatistics
    {
        public int battles { get; set; }
        public int wins { get; set; }
    }

    public class TankDetails
    {
        public bool is_premium { get; set; }
        public string name { get; set; }
        public string nation { get; set; }
        public string description { get; set; }
        public TankImages images { get; set; }
    }

    public class TankImages
    {
        public string small_icon { get; set; }
        public string contour_icon { get; set; }
    }
}
