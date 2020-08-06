using System;
using System.Threading.Tasks;
using TankStats.Data;
using TankStats.Data.Repositories;
using TankStats.Models;

namespace TankStats.Services
{
    public class UserStatisticsService
    {
        private readonly TankService _tankService;
        private readonly UserRepository _userRepository;
        private readonly StatisticsRepository _statisticsRepository;

        public UserStatisticsService(UserRepository userRepository, StatisticsRepository statisticsRepository, TankService tankService)
        {
            _userRepository = userRepository;
            _statisticsRepository = statisticsRepository;
            _tankService = tankService;
        }

        /// <summary>
        /// Search for the user in the world of tanks api, this then returns their account id which we need for the rest of the api calls
        /// </summary>
        public async Task<User> GetPersonalData(string Username)
        {
            User foundUser = await _userRepository.GetPersonalData(Username);

            return foundUser;
        }

        public async Task<UserStats> GetUserStats(string AccountId)
        {
            UserStats serializedStats = await _statisticsRepository.GetUserStats(AccountId);

            //we have the users stats, but we now need to get the tank information for their highest xp, max xp and max kills tank
            All all = serializedStats.statistics.all;
            all.MaxDamageTank = await _tankService.GetTankById(all.max_damage_tank_id);
            all.MaxKillsTank = await _tankService.GetTankById(all.max_frags_tank_id);
            all.MaxXpTank = await _tankService.GetTankById(all.max_xp_tank_id);
            all.win_percent = CalculateWinPercent(all.battles, all.wins);

            return serializedStats;
        }

        public decimal CalculateWinPercent(int TotalGames, int TotalWins)
        {
            Decimal decimalCalculation = (decimal)TotalWins / (decimal)TotalGames;
            decimalCalculation = decimalCalculation * 100;
            var rounded = Math.Round(decimalCalculation, 2);//round to 2 decimal places

            return rounded;
        }
    }
}
