namespace SuperMarketDal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Goods
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Goods()
        //{
        //    sell = new HashSet<sell>();
        //}

        public int GoodsId { get; set; }

        [StringLength(200)]
        public string GoodsName { get; set; }

        public int GoodsTypeId { get; set; }

        [Column(TypeName = "money")]
        public decimal? SellPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? EnterPrice { get; set; }

        public virtual GoodsType GoodsType { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
      //  public virtual ICollection<sell> sell { get; set; }
    }
}
