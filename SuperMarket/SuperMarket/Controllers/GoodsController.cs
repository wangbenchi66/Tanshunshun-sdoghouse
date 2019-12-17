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
            string ret = JsonConvert.SerializeObject(new {Data= list }, setting);
            json.Data = new { Data = ret };
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return json;
        }
    }
}