using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Covid_API.CovidService.DataHandling
{
    public class CovidDTO
    {
        CovidModel CovidModel { get; set; }

        public void DeserialiseCovidData(string latestCovidData)
        {
            CovidModel = JsonConvert.DeserializeObject<CovidModel>(latestCovidData);
        }
    }
}
