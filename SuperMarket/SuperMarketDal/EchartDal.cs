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

        public static List<EchartModel> EcSellTOP()
        {
            SuperMarketDB db = new SuperMarketDB();
            string sql = @"	SELECT   GoodsName as Name ,COUNT(GoodsName) as Value
                FROM      dbo.Goods INNER JOIN
                dbo.GoodsType ON dbo.Goods.GoodsTypeId = dbo.GoodsType.GoodsTypeId INNER JOIN
                dbo.sell ON dbo.Goods.GoodsId = dbo.sell.GoodsId group by GoodsName";
            List<EchartModel> list = db.Database.SqlQuery<EchartModel>(sql).ToList();
            return list;
        }
    }
}
