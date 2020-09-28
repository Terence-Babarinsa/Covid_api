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
        public JArray json_data { get; set; }
        public JObject json_object { get; set; }

        public CServices(string country)
        {
            //stores string from Api call made by CovidDataCallManager
            RecentData = CovidDataCallManager.GetLatestCovidResults(country);





            json_data = JsonConvert.DeserializeObject<JArray>(RecentData);
        }
        public CServices()
        {
            //stores string from Api call made by CovidDataCallManager
            RecentData = CovidDataCallManager.GetLatestCovidResults();

            CovidDTO.DeserialiseCovidData(RecentData);

            json_object = JsonConvert.DeserializeObject<JObject>(RecentData);
        }






    }
}
