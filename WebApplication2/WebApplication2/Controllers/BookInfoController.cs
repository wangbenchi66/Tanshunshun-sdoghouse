using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class BookInfoController : Controller
    {
        // GET: BookInfo
        public ActionResult Index()
        {

            return View(DALHelp.BookInfoSelect());
        }
        public ActionResult carete()
        {

            ViewData["BookType"] = DALHelp.bookTypeInfos().Select(w => new SelectListItem() { Text = w.BookTypeName, Value = w.BookTypeID.ToString() }).ToList();
            return View();
        }
        public ActionResult CreateModel(BookInfo book)
        {
            if (DALHelp.BookInfoCreate(book) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Update(int id)
        {
            ViewData["BookType"] = DALHelp.bookTypeInfos().Select(w => new SelectListItem() { Text = w.BookTypeName, Value = w.BookTypeID.ToString() }).ToList();
            return View(DALHelp.BookInfoID(id));
        }
        public ActionResult UpdateModel(BookInfo bookInfo)
        {
            if (DALHelp.BookInfoUpdate(bookInfo) > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            DALHelp.BookInfoDelete(id);

            return RedirectToAction("Index");
        }

    }
}