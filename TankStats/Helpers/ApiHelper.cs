using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace TankStats.Helpers
{
    public class ApiHelper
    {
        private static HttpClient client = new HttpClient();

        /// <summary>
        /// Get the api data and return a json string which can then be deserialized into an object
        /// </summary>
        public async Task<string> GetApiData(string Url)
        {
            HttpResponseMessage rawHttpCall = await client.GetAsync(Url);
            string stringResult = await rawHttpCall.Content.ReadAsStringAsync();

            //convert to dynamic to get the data we want, then convert back to a string
            dynamic dynamicData = JsonConvert.DeserializeObject(stringResult);
            dynamic justDataNode = dynamicData.data;
            string jsonString = JsonConvert.SerializeObject(justDataNode);

            return jsonString;
        }

        public enum MasteryBadgeLevels
        {
            None = 0,
            ThirdClass = 1,
            SecondClass = 2,
            FirstClass = 3,
            AceTanker = 4
        }
    }
}
