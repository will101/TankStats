using System.Collections.Generic;
using System.Threading.Tasks;
using TankStats.Data.Repositories;
using TankStats.Extensions;
using TankStats.Models;
using static TankStats.Helpers.ApiHelper;

namespace TankStats.Services
{
    public class TankService
    {
        private readonly TankRepository _tankRepository;

        public TankService(TankRepository tankRepository)
        {
            _tankRepository = tankRepository;
        }

        /// <summary>
        /// Gets all the users tanks and then filters them to the users top 10 most popular tanks
        /// </summary>
        public async Task<List<UserTanks>> GetUserTanks(string AccountId)
        {
            List<UserTanks> tanks = await _tankRepository.GetUserTanks(AccountId);
            await GetTankDetails(tanks);

            return tanks;
        }

        /// <summary>
        /// Goes through each tank and gets the details about it e.g.name, history, nation
        /// </summary>
        public async Task<List<UserTanks>> GetTankDetails(List<UserTanks> UserTanks)
        {
            foreach (UserTanks tank in UserTanks)
            {
                TankDetails tankDetails = await _tankRepository.GetTankById(tank.tank_id);
                MasteryBadgeLevels tankMastery = (MasteryBadgeLevels)tank.mark_of_mastery;
                string masteryLevel = tankMastery.ToString();


                tank.MasteryBadgeText = masteryLevel.AddSpace();
                tank.tank_details = tankDetails;
            }

            return UserTanks;
        }

        public async Task<TankDetails> GetTankById(int TankId)
        {
            return await _tankRepository.GetTankById(TankId);
        }
    }
}
