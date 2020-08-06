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
        public MedalInformation MedalInformation { get; set; }
    }
}
