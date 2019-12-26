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

        [HttpPost]
        public JsonResult select(string name="")
        {
            List<ModelCount> list = GoodsDAL.select(name);
            JsonResult json = new JsonResult();
            json.Data = new { Data = list };
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
        /// <summary>
        /// 商品信息下架
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GoodsDelete(int id)
        {
            int num = 0;
            Goods goods = new Goods()
            {
                GoodsId = id
            };
            int result = GoodsDAL.GoodsDelete(goods);
            if (result > 0)
            {
                num = result;
            }
            return Json(num);
        }

        /// <summary>
        /// 商品信息上架
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GoodsState(int id)
        {
            int num = 0;
            Goods goods = new Goods()
            {
                GoodsId = id
            };
            int result = GoodsDAL.GoodsState(goods);
            if (result > 0)
            {
                num = result;
            }
            return Json(num);
        }

        [HttpPost]
        public JsonResult GoodsUpdate(string GoodsName, int GoodsTypeId,decimal SellPrice,decimal EnterPrice,string GoodsImg,int GoodsState,int GoodsId)
        {
            int num = 0;
            Goods goods = new Goods()
            {
                GoodsName = GoodsName,
                GoodsTypeId = GoodsTypeId,
                SellPrice = SellPrice,
                EnterPrice = EnterPrice,
                GoodsImg = GoodsImg,
                GoodsState = GoodsState,
                GoodsId = GoodsId,
            };
            int result = GoodsDAL.GoodsUpdate(goods);
            if (result > 0)
            {
                num = result;
            }
            return Json(num);
        }
    }
}