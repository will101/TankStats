using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using TankStats.Helpers;
using TankStats.Models;

namespace TankStats.Data.Repositories
{
    public class StatisticsRepository
    {
        private readonly ApiHelper _apiHelper;

        public StatisticsRepository(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<UserStats> GetUserStats(string AccountId)
        {
            string url = $"https://api.worldoftanks.eu/wot/account/info/?application_id= {TankConstants.APPLICATION_ID}&account_id= {AccountId}";
            string returnedJson = await _apiHelper.GetApiData(url);

            /*the returned json has a top level node of the accountId, which needs to  be expanded to access the rest of the data.
            * this is why we have to use the .SelectToken method*/
            UserStats serializedStats = JObject.Parse(returnedJson).SelectToken(AccountId).ToObject<UserStats>();

            return serializedStats;
        }
    }
}
