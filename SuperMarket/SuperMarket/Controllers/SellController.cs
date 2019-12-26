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
        public JsonResult SellList(string name="")
        {
            JsonResult json = new JsonResult();
            sellDal dal = new sellDal();
            List<ModelCount> list = dal.sel(name);
            json.Data = new { Data = list };
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return json;
        }
    }
}