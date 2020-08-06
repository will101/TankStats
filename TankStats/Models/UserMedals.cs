using Newtonsoft.Json;

namespace TankStats.Models
{
    public class UserMedals
    {
        public Achievements achievements { get; set; }
    }

    public class Achievements
    {
        public int duelist { get; set; }
        public int defender { get; set; }
        public int supporter { get; set; }
        public int medalBrothersInArms { get; set; }
        public int mainGun { get; set; }
        public int scout { get; set; }
        public int warrior { get; set; }
        public int medalKolobanov { get; set; }
        public int medalRadleyWalters { get; set; }
        public int fighter { get; set; }
    }
}
