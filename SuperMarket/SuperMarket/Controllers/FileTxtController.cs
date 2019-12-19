using HPIT.Data.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XIT.MVC.Web.Models;
using HPIT.Survey.Portal.Filters;
namespace XIT.MVC.Web.Controllers
{
    public class FileTxtController : Controller
    {
        // GET: FileTxt
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="filenames"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult processUpLoadFiles(IEnumerable<HttpPostedFileBase> filenames)
        {
            foreach (var file in filenames)
            {
                var filename = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/UpLoad"),filename);
                file.SaveAs(path);
            }
            return RedirectToAction("Index");
            //return RedirectToAction("FileInputIndex");
        }
        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public FileResult DownLoad(string filename)
        {
            string filepath = Server.MapPath("~/UpLoad/" + filename);//路径
            return File(filepath,"text/plain",filename);//filename是客户端保存的名字
            //return File(new FileStream(filepath, FileMode.Open), "text/plain", filename);
        }
        /// <summary>
        /// 列表显示图片信息
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public JsonResult GetFileList(SearchModel<FileModel> search)
        {
            int total = 0;
            string filepath = Server.MapPath("~/UpLoad/");//路径
            DirectoryInfo directoryInfo = new DirectoryInfo(filepath);
            //获取文件夹下的所有文件
            FileInfo[] allfiles = directoryInfo.GetFiles();
            //生成新的文件类型的数据集合
            var data = from file in allfiles
                       select new
                       {
                           filename = file.Name,
                           path = file.DirectoryName,
                           time = file.LastWriteTime,
                           fullname = file.FullName
                       };
            //总条数
            total = allfiles.Length;
            var totalPages = total % search.PageSize == 0 ? total / search.PageSize : total / search.PageSize + 1;
            JsonResult result = new JsonResult();
            //原生分页代码 skip take
            var pagedata = data.Skip((search.PageIndex - 1) * search.PageSize).Take(search.PageSize);
            //组织新的数据 Data,Total,TotalPages
            result.Data = new { Data = pagedata, Total = total, TotalPages = totalPages };
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            //return result;

            return new DeluxeJsonResult(new
            {
                Data = pagedata,
                Total = total,
                TotalPages = totalPages
            }, "yyyy-MM- dd HH: mm");
        }
        /// <summary>
        /// 列表图片信息视图
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult FileListIndex()
        {
            return View();
        }
        /// <summary>
        /// 扩展上传图片
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult FileInputIndex()
        {
            return View();
        }
    }
}