using SuperMarketDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Api.Controllers
{
    public class GoodsController : ApiController
    {
        /// <summary>
        /// 商品条件查找
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public object select(string name)
        {
            var list =new { Data = GoodsDAL.select(name) };
            return list;
        }
        [HttpPost]
        public object GoodsDelete(int id)
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
        public object GoodsState(int id)
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
    }
}
