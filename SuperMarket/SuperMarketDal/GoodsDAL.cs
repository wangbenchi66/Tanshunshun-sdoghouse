using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketDal
{
   public  class GoodsDAL
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
    }
}
