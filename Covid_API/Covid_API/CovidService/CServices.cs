using Covid_API.CovidService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covid_API.CovidService.DataHandling;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Covid_API
{
    class CServices
    {
        //instance of call manager that manages call to API
        public CovidDataCallManager CovidDataCallManager { get; set; } = new CovidDataCallManager();
        
        //deserialiser that transform data into format for model
        public CovidDTO CovidDTO { get; set; } = new CovidDTO();

        //string containing latest set of values retrieved
        public string RecentData { get; set; }

        //data converted into a JObject
        public JObject json_data { get; set; }

        public CServices()
        {
            //stores string from Api call made by CovidDataCallManager
            RecentData = CovidDataCallManager.GetLatestCovidResults();
       
            json_data = JsonConvert.DeserializeObject<JObject>(RecentData);
        }

        public int CovidDataCount()
        {
            var count = json_data["cdata"].Count();
            return count;
        }
    }
}
