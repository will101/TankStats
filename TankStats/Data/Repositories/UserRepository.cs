using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TankStats.Helpers;
using TankStats.Models;


namespace TankStats.Data
{
    public class UserRepository
    {
        private readonly ApiHelper _apiHelper;

        public UserRepository(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<User> GetPersonalData(string Username)
        {
            string url = $"https://api.worldoftanks.eu/wot/account/list/?application_id= {TankConstants.APPLICATION_ID}&search={Username}";
            string returnedJson = await _apiHelper.GetApiData(url);

            //serialize the json into the object we want
            List<User> convertedUser = JsonConvert.DeserializeObject<List<User>>(returnedJson);

            return convertedUser.FirstOrDefault();
        }
    }
}
