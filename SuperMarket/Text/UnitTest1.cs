using System;
using HPIT.Data.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SuperMarketDal.Weather;
using SuperMarketDal.weatherModel;

namespace Text
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var json =  WeatherDal.WeatherSelete("101220101") ;
        }
    }
}
