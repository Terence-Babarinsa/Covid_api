﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Covid_API
{
    public class CovidDataCallManager
    {
        //restsharp object to handlge call
        readonly IRestClient _client;

        //accesses the API using url entered in app.config
        public CovidDataCallManager()
        {
            _client = new RestClient(CovidConfigReader.BaseUrl);
        }

        public string GetLatestCovidResults()
        {
            var request = new RestRequest("");
            var response = _client.Execute(request, Method.GET);
            return response.Content;
        }
    }
}
