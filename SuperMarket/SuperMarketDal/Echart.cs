using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketDal
{
    public class Echart
    {
        public static List<Echart> EcSellAnalyze()
        {
            SuperMarketDB db = new SuperMarketDB();
            string sql = @"	SELECT   GoodsTypeName as name ,COUNT(GoodsTypeName) as value
                    FROM      dbo.Goods INNER JOIN
                dbo.GoodsType ON dbo.Goods.GoodsTypeId = dbo.GoodsType.GoodsTypeId  group by GoodsTypeName";

            List<Echart> list = db.Database.SqlQuery<Echart>(sql).ToList();
            return list;
        }
    }
}
