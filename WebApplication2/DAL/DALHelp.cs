using HPIT.Data.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALHelp
    {
        public static DALHelp Instance = new DALHelp();
        public BookInfo book { get; set; }
        public DALHelp()
        {
            this.book = new BookInfo();
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="model"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public object GetpaheData(SearchModel<BookInfo> model, out int count)
        {
            GetPageListParameter<BookInfo, int> parameter = new GetPageListParameter<BookInfo, int>();
            parameter.isAsc = true;
            parameter.orderByLambda = a => a.BookID;
            parameter.pageIndex = model.PageIndex;
            parameter.pageSize = model.PageSize;
            parameter.whereLambda = a => a.BookID != 0;
            Model1 Instance = new Model1();
            DBBaseService baseService = new DBBaseService(Instance);
            List<BookInfo> list = baseService.GetSimplePagedData<BookInfo, int>(parameter, out count);
            return list;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public static List<BookInfo> BookInfoSelect()
        {
            Model1 mo = new Model1();
            return mo.BookInfo.ToList();
        }

        public static List<BookTypeInfo> bookTypeInfos()
        {
            Model1 model = new Model1();
            return model.BookTypeInfo.ToList();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static int BookInfoCreate(BookInfo info)
        {
            Model1 model = new Model1();
            model.BookInfo.Add(info);
            return model.SaveChanges();
        }
        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BookInfo BookInfoID(int id)
        {
            Model1 model = new Model1();
            BookInfo Book = model.BookInfo.FirstOrDefault(w => w.BookID == id);
            return Book;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static int BookInfoUpdate(BookInfo info)
        {
            Model1 model = new Model1();
            model.Entry(info).State = System.Data.Entity.EntityState.Modified;
            return model.SaveChanges();
        }
        /// <summary>
        /// 删除某一行
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int BookInfoDelete(int id)
        {
            Model1 model = new Model1();
            var Book = model.BookInfo.FirstOrDefault(w => w.BookID == id);
            model.BookInfo.Remove(Book);
            return model.SaveChanges();
        }
        /// <summary>
        /// 删除类型  多表删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int BookTypeDelete(int id)
        {
            Model1 model = new Model1();
            BookTypeInfo Type = model.BookTypeInfo.FirstOrDefault(w => w.BookTypeID == id);
            //if (Type!=null)
            //{
            //    model.BookInfo.RemoveRange(Type.BookInfo);
            //}
            model.BookTypeInfo.Remove(Type);
            return model.SaveChanges();
        }
    }
}
