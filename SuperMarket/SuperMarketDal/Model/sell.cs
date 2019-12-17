namespace SuperMarketDal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sell")]
    public partial class sell
    {
        public int SellId { get; set; }

        public int GoodsId { get; set; }

        public int? SellCount { get; set; }

        public DateTime? CreateData { get; set; }

        public virtual Goods Goods { get; set; }
    }
}
