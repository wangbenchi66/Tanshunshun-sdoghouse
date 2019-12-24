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
            return Json(list);
        }

        /// <summary>
        /// 图表列表统计
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult EcSellList()
        {
            List<EchartModel> list = EchartDal.EcSellList();
            return Json(list);
        }

        /// <summary>
        /// 商品类别条件查询
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GoodsList(string name)
        {
            List<Goods> list = EchartDal.GoodsList(name);
            JsonResult json = new JsonResult();
            json.Data = new { Data = list };
            return json;
        }

        /// <summary>
        /// 根据商品名称查询销售记录
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
         [HttpPost]
        public JsonResult sellList(string name)
        {
            sellDal dal = new sellDal();
            List<ModelCount> list = dal.sel(name);
            JsonResult json = new JsonResult();
            json.Data = new { Data = list };
            return json;
        }
    }
}