using System;
using NUnit.Framework;

namespace Covid_API
{

    public class CovidDataTest
    {

        private CServices CovidData = new CServices();

        [Test]
        public void CheckCorrectCountry()
        {
            Assert.That(CovidData.json_data[0]["Country"].ToString(), Is.EqualTo("United Kingdom"));
        }

        [Test]
        public void CheckCountryCode()
        {
            Assert.That(CovidData.json_data[0]["CountryCode"].ToString(), Is.EqualTo("GB"));
        }
    }
 
}
