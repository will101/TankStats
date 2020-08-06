using System;
using System.Threading.Tasks;
using TankStats.Data;
using TankStats.Data.Repositories;
using TankStats.Models;

namespace TankStats.Services
{
    public class UserStatisticsService
    {
        private readonly UserRepository _userRepository;
        private readonly StatisticsRepository _statisticsRepository;
        private readonly TankService _tankService;

        public UserStatisticsService(UserRepository userRepository, StatisticsRepository statisticsRepository, TankService tankService)
        {
            _userRepository = userRepository;
            _statisticsRepository = statisticsRepository;
            _tankService = tankService;
        }

        public async Task<User> GetPersonalData(string Username)
        {
            User foundUser = await _userRepository.GetPersonalData(Username);

            return foundUser;
        }

        public async Task<UserStats> GetUserStats(string AccountId)
        {
            UserStats serializedStats = await _statisticsRepository.GetUserStats(AccountId);

            All all = serializedStats.statistics.all;
            all.MaxDamageTank = await _tankService.GetTankById(all.max_damage_tank_id);
            all.MaxKillsTank = await _tankService.GetTankById(all.max_frags_tank_id);
            all.MaxXpTank = await _tankService.GetTankById(all.max_xp_tank_id);

            //calculate win percentage
            //TODO: add vm here
            all.win_percent = CalculateWinPercent(all.battles, all.wins, all.losses);

            return serializedStats;
        }

        public decimal CalculateWinPercent(int TotalGames, int TotalWins, int TotalLosses)
        {
            Decimal decimalCalculation = (decimal)TotalWins / (decimal)TotalGames;

            //round to 2 decimal places
            decimalCalculation = decimalCalculation * 100;

            var rounded =  Math.Round(decimalCalculation, 2);

            return rounded;
        }
    }
}
