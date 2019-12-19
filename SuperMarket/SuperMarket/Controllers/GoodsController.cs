using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SuperMarketDal;

namespace SuperMarket.Controllers
{
    public class GoodsController : Controller
    {
        // GET: Goods
        public ActionResult GoodsIndex()
        {
            return View();
        }
        //public JsonResult select()
        //{
        //    var ef = {(from Goods in GoodsType
        //             join tbMC in myModels.CY_FangTaiMC on tbfangtai.FangTaiMCID equals tbMC.FangTaiMCID
        //             select new Fangtai{ }).ToList();
        //}
        [HttpPost]
        public JsonResult select()
        {
            List<ModelCount> list = GoodsDAL.select();
            JsonResult json = new JsonResult();
            //var cc = from ss in list
            //         select new
            //         {
            //             GoodsTypeName = ss.GoodsType.GoodsTypeName
            //         };
            JsonSerializerSettings setting = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.None
            };
            string ret = JsonConvert.SerializeObject(new { Data = list }, setting);
            json.Data = new { Data = ret };
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return json;
        }
        /// <summary>
        /// 商品类型
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GoodsTypeList()
        {
            List<GoodsType> list = GoodsDAL.GoodsTypeList();
            //JsonSerializerSettings setting = new JsonSerializerSettings()
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            //    Formatting = Formatting.None
            //};
            //JsonResult json = new JsonResult();
            //json.Data = new { Data = list };
            return Json(list);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GoodsInsert(string name, decimal jinjia,decimal shoujia, string img,int Select)
        {
            int num = 0;
            Goods goods = new Goods()
            {
                GoodsName=name,
                EnterPrice=jinjia,
                SellPrice=shoujia,
                GoodsImg=img,
                GoodsTypeId= Select,

            };
            int result = GoodsDAL.GoodsInsert(goods);
            if (result>0)
            {
                num = result  ;
            }
            return Json(num);
        }
    }
}