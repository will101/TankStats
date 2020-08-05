using System.Collections.Generic;

namespace TankStats.Models.ViewModels
{
    public class UserMedalsViewModel
    {
        public List<UserMedalsReceived> MedalsReceived { get; set; } = new List<UserMedalsReceived>();
    }

    public class UserMedalsReceived
    {
        public int AmountReceived { get; set; }
        public string MedalName { get; set; }
        public string MedalImage { get; set; }
        public string MedalDescription { get; set; }
        public string MedalCondition { get; set; }
        public string HistoricalInfo { get; set; }
    }
}
