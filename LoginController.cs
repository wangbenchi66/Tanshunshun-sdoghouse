using HPIT.Data.Core;
using MVC.EF.DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult LoginIn(string name = "", int pwd = 0)
        {
            TaskDal dal = new TaskDal();
            List<Task> tasks = dal.LoginSel(name, pwd);
            JsonResult jsonResult = new JsonResult();
            if (tasks != null && tasks.Count >= 1)
            {
                string json = JsonConvert.SerializeObject(tasks.FirstOrDefault());
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
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOff()
        {
            Request.Cookies.Clear();
            Response.Cookies.Clear();
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult ProcessUploadFiles(IEnumerable<HttpPostedFileBase> filenames)
        {
            foreach (var file in filenames)
            {
                var filename = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Upload"), filename);
                file.SaveAs(path);
            }
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public FileResult FileResult(string filename)
        {
            string filepath = Server.MapPath("~/Upload/"+filename);//路径
            return File(filepath, "text/plain",filename);//filename 是客户端存储的名字
        }
        //[AllowAnonymous] 二选一
        //public FileStreamResult FileStreamResult(string filename)
        //{
        //    string filepath = Server.MapPath("~/Upload" + filename);//路径    
        //    return File(new FileStream (filepath, FileMode.Open),"text/plain", filename );//filename 是客户端存储的名字
        //}
        [AllowAnonymous]
        public JsonResult GetFileList(SearchModel<FileModel> search)
        {
            int total = 0;
            string filepath = Server.MapPath("~/Upload/");//路径
            DirectoryInfo directoryInfo = new DirectoryInfo(filepath);
            FileInfo[] allfiles = directoryInfo.GetFiles();
            var data = from file in allfiles
                       select new
                       {
                           filename = file.Name,
                           path = file.DirectoryName,
                           time = file.LastWriteTime,
                           fullname = file.FullName
                       };
            total = allfiles.Length;
            var totalPages = total % search.PageSize == 0 ? total / search.PageSize : total / search.PageSize + 1;
            JsonResult result = new JsonResult();
            var pagedata = data.Skip((search.PageIndex-1)*search.PageSize).Take(search.PageSize);
            result.Data = new { Data=pagedata,Total=total,TotalPages=totalPages};
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

    }
}