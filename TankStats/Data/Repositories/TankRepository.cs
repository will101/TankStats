using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TankStats.Helpers;
using TankStats.Models;
using static TankStats.TankConstants;

namespace TankStats.Data.Repositories
{
    public class TankRepository
    {
        private readonly ApiHelper _apiHelper;
        public TankRepository(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<UserTanks>> GetUserTanks(string AccountId)
        {
            string url = $"https://api.worldoftanks.eu/wot/account/tanks/?application_id= {TankConstants.APPLICATION_ID}&account_id= {AccountId}";
            string returnedJson = await _apiHelper.GetApiData(url);

            List<UserTanks> tanks = JObject.Parse(returnedJson).SelectToken(AccountId).ToObject<List<UserTanks>>();
            tanks = tanks.OrderByDescending(t => t.statistics.battles).Take(10).ToList(); //get the top 15 to start with

            return tanks;
        }   

        public async Task<TankDetails> GetTankById(int TankId)
        {
            string url = $"https://api.worldoftanks.eu/wot/encyclopedia/vehicles/?application_id= {APPLICATION_ID}&tank_id={TankId}";
            string returnedJson = await _apiHelper.GetApiData(url);
            TankDetails tankDetails = JObject.Parse(returnedJson).SelectToken(TankId.ToString()).ToObject<TankDetails>();

            return tankDetails;
        }
    }
}
