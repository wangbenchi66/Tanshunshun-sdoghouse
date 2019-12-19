namespace SuperMarketDal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GoodsType")]
    public partial class GoodsType
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public GoodsType()
        //{
        //    Goods = new HashSet<Goods>();
        //}

        public int GoodsTypeId { get; set; }

        [StringLength(200)]
        public string GoodsTypeName { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Goods> Goods { get; set; }
    }
}
