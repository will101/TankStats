using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using TankStats.Helpers;
using TankStats.Models;
using TankStats.Models.ViewModels;

namespace TankStats.Controllers
{
    public class HomeController : Controller
    {
        /** Main todo: 
         * Add a section about tanks(players vehicles)
         * Add a section about players achievements
         * Add a comparison feature between up to 3 players
         * Refactor front end in Angular or react
         * Refactor everything
         * Add some decent error handling in
         * */


        private ApiHelper _apiHelper;

        public HomeController(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<User> GetUser(string Username)
        {
            User user = new User();
            if (!string.IsNullOrEmpty(Username))
            {
                user = await _apiHelper.GetPersonalData(Username);
            }

            return user;
        }

        [HttpGet]
        public async Task<UserStatsViewModel> GetUserStats(string AccountId)
        {
            UserStatsViewModel stats = new UserStatsViewModel();
            if (!string.IsNullOrEmpty(AccountId))
            {
                stats.UserStats = await _apiHelper.GetUserStats(AccountId);
                stats.UserTanks = await _apiHelper.GetUserTanks(AccountId);
                stats.UserMedals = await _apiHelper.GetUserMedals(AccountId);
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
