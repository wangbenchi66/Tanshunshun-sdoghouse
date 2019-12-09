using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class BookTypeInfoController : Controller
    {
        // GET: BookTypeInfo
        public ActionResult Index()
        {
            return View(DALHelp.bookTypeInfos());
        }
        public ActionResult Delete(int id)
        {
            DALHelp.BookTypeDelete(id);
            return RedirectToAction("Index");
        }
    }
}