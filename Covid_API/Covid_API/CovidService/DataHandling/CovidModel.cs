using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Covid_API
{
    public class Rootobject
    {
        public string Message { get; set; }
        public Global Global { get; set; }
        public Country[] Countries { get; set; }
        public DateTime Date { get; set; }
    }

    public class Global
    {
        public int NewConfirmed { get; set; }
        public int TotalConfirmed { get; set; }
        public int NewDeaths { get; set; }
        public int TotalDeaths { get; set; }
        public int NewRecovered { get; set; }
        public int TotalRecovered { get; set; }
    }

    public class Country
    {
        public string Country1 { get; set; }
        public string CountryCode { get; set; }
        public string Slug { get; set; }
        public int NewConfirmed { get; set; }
        public int TotalConfirmed { get; set; }
        public int NewDeaths { get; set; }
        public int TotalDeaths { get; set; }
        public int NewRecovered { get; set; }
        public int TotalRecovered { get; set; }
        public DateTime Date { get; set; }
        public Premium Premium { get; set; }
    }

    public class Premium
    {
    }


}
