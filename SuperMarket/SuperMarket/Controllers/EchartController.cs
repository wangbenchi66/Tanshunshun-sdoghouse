using SuperMarketDal;
using SuperMarketDal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace SuperMarket.Controllers
{
    public class EchartController : Controller
    {
        // GET: Echart
        //[AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        //[AllowAnonymous]
        /// <summary>
        /// 图表各类型统计
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult EcSellAnalyze()
        {
            List<EchartModel> list = EchartDal.EcSellAnalyze();
            //var ss = JsonConvert.SerializeObject(list);
            return Json(list);
        }

        /// <summary>
        /// 图表统计
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult EcSellTOP()
        {
            List<EchartModel> list = EchartDal.EcSellTOP();
            //var ss = JsonConvert.SerializeObject(list);
            return Json(list);
        }
    }
}