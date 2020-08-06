using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using TankStats.Helpers;
using TankStats.Models;

namespace TankStats.Data.Repositories
{
    public class MedalRepository
    {
        private readonly ApiHelper _apiHelper;

        public MedalRepository(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<UserMedals> GetUserMedals(string AccountId)
        {
            //can't filter on specific medals here because the api doesn't allow it
            string url = $"https://api.worldoftanks.eu/wot/account/achievements/?application_id= {TankConstants.APPLICATION_ID}&account_id={AccountId}";
            string returnedJson = await _apiHelper.GetApiData(url);

            UserMedals medals = JObject.Parse(returnedJson).SelectToken(AccountId).ToObject<UserMedals>();

            return medals;
        }

        public async Task<Medals> GetAllMedals()
        {
            string url = $"https://api.worldoftanks.eu/wot/encyclopedia/achievements/?application_id= {TankConstants.APPLICATION_ID}";

            /*Don't need to get all the medals here, just the ones we're interested in. But this api method doesn't seem to support filtering unlike the other methods.*/

            string returnedJson = await _apiHelper.GetApiData(url);
            Medals allMedals = JsonConvert.DeserializeObject<Medals>(returnedJson);

            return allMedals;
        }

    }
}
