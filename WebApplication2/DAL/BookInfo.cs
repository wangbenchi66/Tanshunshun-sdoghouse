namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookInfo")]
    public partial class BookInfo
    {
        [Key]
        public int BookID { get; set; }

        [Required]
        [StringLength(30)]
        public string BookName { get; set; }

        //[ForeignKey("BookTypeID")]
        public int BookType { get; set; }

        public double BookPrice { get; set; }

        [Required]
        [StringLength(20)]
        public string AuthorName { get; set; }

        public bool IsLoan { get; set; }

        public DateTime Addtime { get; set; }

        [StringLength(100)]
        public string Remark { get; set; }

        //public virtual BookTypeInfo BookTypeInfo { get; set; }
    }
}
