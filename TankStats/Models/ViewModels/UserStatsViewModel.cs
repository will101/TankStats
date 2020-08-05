using System.Collections.Generic;

namespace TankStats.Models.ViewModels
{
    public class UserStatsViewModel
    {
        public UserStats UserStats { get; set; }
        public List<UserTanks> UserTanks { get; set; }
        public UserMedalsViewModel UserMedals { get; set; }
    }
}
