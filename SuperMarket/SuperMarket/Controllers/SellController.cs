using Newtonsoft.Json;
using SuperMarketDal;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SuperMarket.Controllers
{
    public class SellController : Controller
    {
        // GET: Sell
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SellList()
        {
            JsonResult json = new JsonResult();
            sellDal dal = new sellDal();
           // List<sell> list = dal.List();
            List<ModelCount> list = dal.sel();
            //var cc = from ss in list
            //         select new
            //         {
            //             GoodsTypeName = ss.GoodsType.GoodsTypeName
            //         };
            //JsonSerializerSettings setting = new JsonSerializerSettings()
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            //    Formatting = Formatting.None
            //};
            

            json.Data = new { Data = list };
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            
            return json;
        }
    }
}