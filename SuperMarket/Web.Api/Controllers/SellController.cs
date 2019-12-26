using System.Collections.Generic;
using System.Web.Http;
using SuperMarketDal;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Results;

namespace Web.Api.Controllers
{
    public class SellController : ApiController
    {
        public object Get(string name = "")
        {
            sellDal dal = new sellDal();
            var json = new { Data = dal.sel(name) };
            return json;
        }
            
        

    }

}
