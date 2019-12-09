namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookInfo")]
    public partial class BookInfo
    {
        [Key]
        [DisplayName("编号")]
        public int BookID { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("书名")]
        public string BookName { get; set; }

        //[ForeignKey("BookTypeID")]
        [DisplayName("书籍类型")]
        public int BookType { get; set; }

        [DisplayName("书籍价格")]
        public double BookPrice { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("作者")]
        public string AuthorName { get; set; }

        [DisplayName("是否借出")]
        public bool IsLoan { get; set; }

        [DisplayName("时间")]
        public DateTime Addtime { get; set; }

        [StringLength(100)]
        [DisplayName("备注")]
        public string Remark { get; set; }

        //public virtual BookTypeInfo BookTypeInfo { get; set; }
    }
}
