using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using SuperMarketDal;
using Newtonsoft.Json;

namespace Web.Api.Controllers
{
    public class SellController : ApiController
    {
        public object Get(string name = "")
        {
            sellDal dal = new sellDal();
            return dal.sel();

        }

    }
}
