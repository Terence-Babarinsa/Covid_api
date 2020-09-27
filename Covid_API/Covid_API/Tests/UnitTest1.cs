using System;
using System.Linq;
using NUnit.Framework;

namespace Covid_API
{

    public class CovidDataTest
    {


        private CServices CovidData = new CServices("united-kingdom");
        private CServices CovidPortugal = new CServices("portugal");
        private CServices CovidDataGlobal = new CServices();


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

        [Test]
        public void CheckCountryCodePortugal()
        {
            Assert.That(CovidPortugal.json_data[0]["CountryCode"].ToString(), Is.EqualTo("PT"));
        }

        [Test]
        public void CheckGlobal()
        {
            Assert.That(CovidDataGlobal.CovidDTO.CovidModel.Message, Is.EqualTo(""));
        }
        [Test]
        public void CheckUKCode()
        {
            Assert.That(CovidDataGlobal.CovidDTO.CovidModel.Countries.Where(c => c.CountryCode == "GB").First().CountryCode, Is.EqualTo("GB"));
        }
        [Test]
        public void CheckUKName()
        {
            Assert.That(CovidDataGlobal.CovidDTO.CovidModel.Countries.Where(c => c.CountryCode == "GB").First().Slug, Is.EqualTo("united-kingdom"));
        }

        [Test]
        public void CheckUpdated()
        {
            Assert.That(int.Parse(CovidPortugal.json_data[90]["Confirmed"].ToString()), Is.LessThan(int.Parse(CovidPortugal.json_data[91]["Confirmed"].ToString())));
        }

        [Test]
        public void CheckTotalCasesUK()
        {
            Assert.That(CovidDataGlobal.CovidDTO.CovidModel.Countries.Where(c => c.CountryCode == "GB").First().TotalConfirmed, Is.LessThan(500000));
        }
        [Test]

        public void CheckDateOfUpdateIsToday()
        {
            var date = DateTime.Now.ToString("d/MM/yyyy");

            Assert.That(CovidDataGlobal.CovidDTO.CovidModel.Countries.Where(c => c.CountryCode == "GB").First().Date.ToString().Contains(date));


        }
    }


}



