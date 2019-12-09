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
        [DisplayName("���")]
        public int BookID { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("����")]
        public string BookName { get; set; }

        //[ForeignKey("BookTypeID")]
        [DisplayName("�鼮����")]
        public int BookType { get; set; }

        [DisplayName("�鼮�۸�")]
        public double BookPrice { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("����")]
        public string AuthorName { get; set; }

        [DisplayName("�Ƿ���")]
        public bool IsLoan { get; set; }

        [DisplayName("ʱ��")]
        public DateTime Addtime { get; set; }

        [StringLength(100)]
        [DisplayName("��ע")]
        public string Remark { get; set; }

        //public virtual BookTypeInfo BookTypeInfo { get; set; }
    }
}
