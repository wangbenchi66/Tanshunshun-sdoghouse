using SuperMarketDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Api.Controllers
{
    public class Echaert1Controller : ApiController
    {
        /// <summary>
        /// 图表各类型统计
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object EcSellAnalyze()
        {
            return EchartDal.EcSellAnalyze();
            
        }

        /// <summary>
        /// 图表统计
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object EcSellTOP()
        {
            return EchartDal.EcSellTOP();

        }

        /// <summary>
        /// 图表列表统计
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object EcSellList()
        {
            return EchartDal.EcSellList();

        }
        /// <summary>
        /// 商品类别条件查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GoodsList(string name)
        {

            var json=new { Data = EchartDal.GoodsList(name) };
            return json;

        }

        /// <summary>
        /// 商品类别条件查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GoodsList2(string name)
        {
            sellDal dal = new sellDal();
            var json = new { Data = dal.sel(name) };
            return json;
        }
    }
}
