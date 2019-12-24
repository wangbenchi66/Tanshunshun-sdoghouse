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
        [HttpGet]
        public object Get(string name = "")
        {
            return  GoodsDAL.select(name);
            
        }
    }
}
