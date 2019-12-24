using SuperMarketDal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketDal
{
    public class EchartDal
    {
        /// <summary>
        /// 各类别统计
        /// </summary>
        /// <returns></returns>
        public static List<EchartModel> EcSellAnalyze()
        {
            SuperMarketDB db = new SuperMarketDB();
            string sql = @"	SELECT   GoodsTypeName as Name ,COUNT(GoodsTypeName) as Value
                    FROM      dbo.Goods INNER JOIN
                dbo.GoodsType ON dbo.Goods.GoodsTypeId = dbo.GoodsType.GoodsTypeId  group by GoodsTypeName";
            List<EchartModel> list = db.Database.SqlQuery<EchartModel>(sql).ToList();
            return list;
        }
        /// <summary>
        /// 前五名销售冠军
        /// </summary>
        /// <returns></returns>
        public static List<EchartModel> EcSellTOP()
        {
            SuperMarketDB db = new SuperMarketDB();
            string sql = @"	SELECT top 5  dbo.Goods.GoodsName AS NAME, dbo.sell.SellCount AS VALUE
                    FROM      dbo.sell INNER JOIN
                dbo.Goods ON dbo.sell.GoodsId = dbo.Goods.GoodsId group by Goods.GoodsName,sell.SellCount order by Value desc";
            List<EchartModel> list = db.Database.SqlQuery<EchartModel>(sql).ToList();
            return list;
        }
        /// <summary>
        /// 各商品销售记录
        /// </summary>
        /// <returns></returns>
        public static List<EchartModel> EcSellList()
        {
            SuperMarketDB db = new SuperMarketDB();
            string sql = @"	SELECT   dbo.Goods.GoodsName AS NAME, dbo.sell.SellCount AS VALUE
                    FROM      dbo.sell INNER JOIN
                dbo.Goods ON dbo.sell.GoodsId = dbo.Goods.GoodsId group by Goods.GoodsName,sell.SellCount";
            List<EchartModel> list = db.Database.SqlQuery<EchartModel>(sql).ToList();
            return list;
        }
        /// <summary>
        /// 根据分类查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static List<Goods> GoodsList( string name)
        {
            SuperMarketDB db = new SuperMarketDB();
            string sql =string.Format( @"SELECT   *
                    FROM      dbo.Goods INNER JOIN
                dbo.GoodsType ON dbo.Goods.GoodsTypeId = dbo.GoodsType.GoodsTypeId  where GoodsTypeName='{0}'",name);
            List<Goods> list = db.Database.SqlQuery<Goods>(sql).ToList();
            return list;
        }
        /// <summary>
        /// 查询销售记录
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static List<ModelCount> sellList(string name)
        {
            SuperMarketDB db = new SuperMarketDB();
            string sql = string.Format(@"SELECT   *
                FROM      dbo.Goods INNER JOIN
                dbo.sell ON dbo.Goods.GoodsId = dbo.sell.GoodsId where GoodsName='{0}'", name);
            List<ModelCount> list = db.Database.SqlQuery<ModelCount>(sql).ToList();

            return list;
        }
    }
}
