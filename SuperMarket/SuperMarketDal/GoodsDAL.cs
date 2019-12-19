using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketDal
{
    public class GoodsDAL
    {

        public static List<ModelCount> select()
        {
            SuperMarketDB db = new SuperMarketDB();
            List<ModelCount> list = (from cc in db.Goods
                                     join aa in db.GoodsType
                                     on cc.GoodsTypeId equals aa.GoodsTypeId
                                     select new ModelCount
                                     {
                                         Goods = cc,
                                         GoodsType = aa,
                                     }).ToList();
            return list;
        }
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <returns></returns>
        public static List<GoodsType> GoodsTypeList()
        {
            SuperMarketDB db = new SuperMarketDB();
            string sql = @"	select * from GoodsType";
            List<GoodsType> list = db.Database.SqlQuery<GoodsType>(sql).ToList();
            return list;
        }
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public static int GoodsInsert(Goods goods)
        {
            SuperMarketDB db = new SuperMarketDB();
            string sql = string.Format(@"insert into Goods values('{0}',{1},{2},{3},'{4}')", goods.GoodsName, goods.GoodsTypeId, goods.SellPrice, goods.EnterPrice, goods.GoodsImg);
            int result = (int)db.Database.ExecuteSqlCommand(sql);
            return result;
        }
        /// <summary>
        /// 下架商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int GoodsDelete(Goods goods)
        {
            SuperMarketDB db = new SuperMarketDB();
            string sql = string.Format(@"update Goods set GoodsState=2 where GoodsId={0}", goods.GoodsId);
            int result = (int)db.Database.ExecuteSqlCommand(sql);
            return result;
        }

        /// <summary>
        /// 上架商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int GoodsState(Goods goods)
        {
            SuperMarketDB db = new SuperMarketDB();
            string sql = string.Format(@"update Goods set GoodsState=1 where GoodsId={0}", goods.GoodsId);
            int result = (int)db.Database.ExecuteSqlCommand(sql);
            return result;
        }
    }
}
