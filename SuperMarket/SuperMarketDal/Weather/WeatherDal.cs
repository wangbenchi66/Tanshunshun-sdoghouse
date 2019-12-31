using HPIT.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SuperMarketDal.weatherModel;

namespace SuperMarketDal.Weather
{
    public class WeatherDal
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static WeatherEn WeatherSelete(string ID)
        {
            string url = "http://t.weather.sojson.com/api/weather/city/" + ID;
            var list = HTTPService.Get(url);
            WeatherEn model = JsonConvert.DeserializeObject<WeatherEn>(list);
            return model;
        }
    }
}
