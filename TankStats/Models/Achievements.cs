using Newtonsoft.Json;

namespace TankStats.Models
{
    public class Medals
    {
        public medalBrothersInArms MedalBrothersInArms { get; set; }
        public defender Defender { get; set; }
        public scout Scout { get; set; }
        public medalRadleyWalters MedalRadleyWalters { get; set; }

        [JsonProperty("maingun")]
        public mainGun HighCalibre { get; set; }

        [JsonProperty("warrior")]
        public warrior TopGun { get; set; }

        [JsonProperty("supporter")]
        public supporter Confederate { get; set; }

        [JsonProperty("medalKolobanov")]
        public medalKolobanovs Kolobanovs { get; set; }

        public fighter Fighter { get; set; }
        public duelist Duelist { get; set; }
    }

    public class medalBrothersInArms : MedalInformation { }
    public class defender : MedalInformation { }
    public class scout : MedalInformation { }
    public class medalRadleyWalters : MedalInformation { }
    public class mainGun : MedalInformation { }
    public class warrior : MedalInformation { }
    public class supporter : MedalInformation { }
    public class medalKolobanovs : MedalInformation { }
    public class fighter : MedalInformation { }
    public class duelist : MedalInformation { }

    public class MedalInformation
    {
        public string condition { get; set; }
        public string description { get; set; }
        public string hero_info { get; set; }
        public string image { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }

}
