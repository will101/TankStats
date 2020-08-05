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

        public async Task<List<UserTanks>> GetUserTanks(string AccountId)
        {
            List<UserTanks> tanks = await _tankRepository.GetUserTanks(AccountId);

            //go through each tank returned and get the tank details - name and image
            await GetTankDetails(tanks);

            return tanks;
        }


        public async Task<List<UserTanks>> GetTankDetails(List<UserTanks> UserTanks)
        {
            foreach (UserTanks tank in UserTanks)
            {
                TankDetails tankDetails = await _tankRepository.GetTankById(tank.tank_id);
                MasteryBadgeLevels tankMastery = (MasteryBadgeLevels)tank.mark_of_mastery;
                string masteryLevel = tankMastery.ToString(); //TODO: Add spacing in between the words. Look at method used for this for medal names? Make an extension method?


                tank.MasteryBadgeText = masteryLevel;
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
