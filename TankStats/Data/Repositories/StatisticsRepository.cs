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
            //api filter - just to get only the data we want back
            string stats = "statistics.all";
            string fieldList = $"account_id,global_rating,statistics.trees_cut,{stats}.wins,{stats}.max_xp,{stats}.avg_damage_blocked,{stats}.max_damage_tank_id,{stats}.xp,{stats}.survived_battles," +
                $"{stats}.hits_percents,{stats}.max_xp_tank_id,{stats}.battles,{stats}.avg_damage_assisted,{stats}.max_frags_tank_id,{stats}.frags,{stats}.max_damage,{stats}.battle_avg_xp," +
                $"{stats}.wins,{stats}.losses,{stats}.damage_dealt,{stats}.explosion_hits_received,{stats}.max_frags,{stats}.damage_received,{stats}.spotted,{stats}.shots";

            string url = $"https://api.worldoftanks.{TankConstants.PLAYER_SERVER}/wot/account/info/?application_id= {TankConstants.APPLICATION_ID}&account_id= {AccountId}&fields={fieldList}";
            string returnedJson = await _apiHelper.GetApiData(url);

            /*the returned json has a top level node of the accountId, which needs to be expanded to access the rest of the data.
            * this is why we have to use the .SelectToken method*/
            UserStats serializedStats = JObject.Parse(returnedJson).SelectToken(AccountId).ToObject<UserStats>();

            return serializedStats;
        }
    }
}
