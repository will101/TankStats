using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TankStats.Models;
using TankStats.Models.ViewModels;
using TankStats.Services;

namespace TankStats.Controllers
{
    public class HomeController : Controller
    {
        /** TODO: 
         * Add the different regions in (when searching for players), as its only looking at EU for the moment
         * Display all tanks the user has played, add some pagination and filters/search to make this easier
         * Switch CSS out for SASS
         * Add a comparison feature between up to 3 players
         * Replace front end with an Angular or react UI
         * Add a database to log errors
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

        /// <summary>
        /// Called by some JavaScript to get users info
        /// </summary>
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

        /// <summary>
        /// Called by some JavaScript to get users stats
        /// </summary>
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
            int httpStatusCode = HttpContext.Response.StatusCode;
            IExceptionHandlerFeature exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            string errorMessage = exceptionHandlerPathFeature.Error.Message;

            //redirect to an error page
            switch (httpStatusCode)
            {
                case 404:
                    return RedirectToAction("PageNotFound");
                default:
                    return RedirectToAction("ServerError");
            }
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult PageNotFound()
        {
            return View();
        }

        public IActionResult ServerError()
        {
            return View();
        }
    }
}
