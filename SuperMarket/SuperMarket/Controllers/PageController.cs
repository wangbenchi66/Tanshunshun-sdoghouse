//using HPIT.Data.Core;
//using HPIT.Survey.Portal.Filters;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using SuperMarket;
//using SuperMarketDal;
////using XIT.EF.DAL;
////using XIT.EF.DAL.UDMP;

//namespace XIT.MVC.Web.Controllers
//{
//    public class PageController : Controller
//    {
//        // GET: Page
//        public ActionResult Index()
//        {
//            return View();
//        }
//        public DeluxeJsonResult QueryPageData(SearchModel<XIT.EF.DAL.UDMP.StuInfo> search)
//        {
//            int total = 0;
//            var result = StuInfoDal.Instance.GetPageData(search, out total);
//            var totalPages = total % search.PageSize == 0 ? total / search.PageSize : total / search.PageSize + 1;
//            return new DeluxeJsonResult(new
//            {
//                Data = result,
//                Total = total,
//                TotalPages = totalPages
//            }, "yyyy-MM- dd HH: mm");
//        }
//    }
//}