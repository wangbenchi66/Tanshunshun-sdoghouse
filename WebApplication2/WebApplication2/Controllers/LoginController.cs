using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace WebApplication2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 根据账号密码查询
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pow"></param>
        /// <returns></returns>
        //[AllowAnonymous]
        //[HttpPost]
        public JsonResult loginName(string name, int pow)
        {
            BookInfo book = DALHelp.UserLogin(name);
            JsonResult jsonResult = new JsonResult();
            if (book.BookID == pow)
            {
                string json = JsonConvert.SerializeObject(book);
                jsonResult.Data = new { data = book, state = "666" };
                jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                return jsonResult;
            }
            else
            {
                jsonResult.Data = new { data = "找不到用户", state = "555" };
                return jsonResult;
            }
        }
    }
}