using System.Collections.Generic;
using System.Linq;

namespace SuperMarketDal
{
    public class sellDal
    {
        SuperMarketDB db = new SuperMarketDB();
        /// <summary>
        /// 商品销售列表
        /// </summary>
        /// <returns></returns>
        public List<sell> List()
        {
            string sql = "select * from sell";
            List<sell> list = db.Database.SqlQuery<sell>(sql).ToList();
            return list;
        }
        /// <summary>
        /// 添加商品销售信息
        /// </summary>
        /// <param name="sell"></param>
        /// <returns></returns>
        public int Insert(sell sell)
        {
            db.sell.Add(sell);
            return db.SaveChanges();
        }
    }
}
