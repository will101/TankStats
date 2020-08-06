using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using TankStats.Models;
using TankStats.Models.ViewModels;
using TankStats.Services;

namespace TankStats.Controllers
{
    public class HomeController : Controller
    {
        /** TODO: 
         * Switch CSS out for SASS
         * Add a comparison feature between up to 3 players
         * Refactor front end in Angular or react
         * */

        private readonly TankService _tankService;
        private readonly MedalService _medalService;
        private readonly UserStatisticsService _userStatisticsService;

        public HomeController(TankService tankService, MedalService medalService, UserStatisticsService userStatisticsService)
        {
            _tankService = tankService;
            _medalService = medalService;
            _userStatisticsService = userStatisticsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public async Task<User> GetUser(string Username)
        {
            User user = new User();
            if (!string.IsNullOrEmpty(Username))
            {
                user = await _userStatisticsService.GetPersonalData(Username);
            }

            return user;
        }

        [HttpGet]
        public async Task<UserStatsViewModel> GetUserStats(string AccountId)
        {
            UserStatsViewModel stats = new UserStatsViewModel();
            if (!string.IsNullOrEmpty(AccountId))
            {
                //get all the data we need for the user
                stats.UserStats = await _userStatisticsService.GetUserStats(AccountId);
                stats.UserTanks = await _tankService.GetUserTanks(AccountId);
                stats.UserMedals = await _medalService.GetUserMedals(AccountId);
            }

            return stats;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
