namespace SuperMarketDal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("employee")]
    public partial class employee
    {
        [Key]
        public int EmpId { get; set; }

        [Required]
        [StringLength(200)]
        public string EmpName { get; set; }

        [Required]
        [StringLength(200)]
        public string EmpPwd { get; set; }

        public int? RoleId { get; set; }

        public virtual role role { get; set; }
    }
}
