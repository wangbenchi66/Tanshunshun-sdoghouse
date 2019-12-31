using HPIT.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SuperMarketDal.Weather;
using SuperMarketDal.weatherModel;

namespace SuperMarket.Controllers
{
    public class WeaTherController : Controller
    {
        // GET: WeaTher
        public ActionResult WeaTherIndex()
        {
            return View();
        }

        public JsonResult select(string url)
        {
            JsonResult json = new JsonResult();
            json.Data = new { Data =WeatherDal.WeatherSelete(url) };
            //反序列化
            //Dictionary<string, string> jsonDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(HTTPService.Get(url));
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return json;
        }
        //public JsonResult insert(List<WeatherEn> list)
        //{
        //    string result = JsonConvert.SerializeObject(list);
        //    return Json(result);
        //}

        //public JsonResult insCityInfo(string city,string citykey,string parent,string updateTime)
        //{
        //   //调用方法，首先进行查询验证

        //    //验证是否存在

        //    //if判断是否成功，存在值则直接添加，不存在当前数据则添加一个城市
            
        //    //返回对应数据（存在则存储已查询的id，不存在则添加一个，在查询将id存储以便其他数据插入的外键关系）
        //}
    }
}