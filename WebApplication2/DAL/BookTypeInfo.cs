namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookTypeInfo")]
    public partial class BookTypeInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BookTypeInfo()
        {
            //BookInfo = new HashSet<BookInfo>();
        }

        [Key]
        public int BookTypeID { get; set; }

        [Required]
        [StringLength(30)]
        public string BookTypeName { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<BookInfo> BookInfo { get; set; }
    }
}
