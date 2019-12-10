using DAL;
using HPIT.Data.Core;
using HPIT.Survey.Portal.Filters;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class FYController : Controller
    {
        // GET: FY
        public ActionResult Index()
        {
            return View();
        }
        public DeluxeJsonResult QueryPageData(SearchModel<BookInfo> search)
        {
            int total = 0;
            var result = DALHelp.Instance.GetpaheData(search, out total);
            var totalPages = total % search.PageSize == 0 ? total / search.PageSize : total / search.PageSize + 1;
            return new DeluxeJsonResult(new
            {
                Data = result,
                Total = total,
                TotalPages = totalPages
            }, "yyyy-MM- dd HH: mm");
        }
    }
}