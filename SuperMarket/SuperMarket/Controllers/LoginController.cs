using Newtonsoft.Json;
using SuperMarketDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperMarket.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult LoginIn(string name = "", string pwd = "")
        {
            LoginDal dal = new LoginDal();
            List<employee> emy = dal.LoginSel(name, pwd);
            JsonResult jsonResult = new JsonResult();
            if (emy != null && emy.Count >= 1)
            {
                string json = JsonConvert.SerializeObject(emy.FirstOrDefault());
                HttpCookie cookie = new HttpCookie("Login", Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(json)));
                Response.Cookies.Add(cookie);
                jsonResult.Data = new { data = json, state = "200" };
                jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                return jsonResult;
            }
            else
            {
                jsonResult.Data = new { data = "未找到用户！", state = "403" };
                return jsonResult;
            }
        }
    }
}