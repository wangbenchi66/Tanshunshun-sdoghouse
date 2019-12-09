namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public  partial class Model1 : DbContext
    {
        public  Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<BookInfo> BookInfo { get; set; }
        public virtual DbSet<BookTypeInfo> BookTypeInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookInfo>()
                .Property(e => e.BookName)
                .IsUnicode(false);

            modelBuilder.Entity<BookInfo>()
                .Property(e => e.AuthorName)
                .IsUnicode(false);

            modelBuilder.Entity<BookInfo>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<BookTypeInfo>()
                .Property(e => e.BookTypeName)
                .IsUnicode(false);

            //modelBuilder.Entity<BookTypeInfo>()
            //    .HasMany(e => e.BookInfo)
            //    .WithRequired(e => e.BookTypeInfo)
            //    .HasForeignKey(e => e.BookType)
            //    .WillCascadeOnDelete(false);
        }
    }
}
