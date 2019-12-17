namespace SuperMarketDal
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SuperMarketDB : DbContext
    {
        public SuperMarketDB()
            : base("name=SuperMarketDB")
        {
        }

        public virtual DbSet<employee> employee { get; set; }
        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<GoodsType> GoodsType { get; set; }
        public virtual DbSet<role> role { get; set; }
        public virtual DbSet<sell> sell { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Goods>()
                .Property(e => e.SellPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Goods>()
                .Property(e => e.EnterPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Goods>()
                .HasMany(e => e.sell)
                .WithRequired(e => e.Goods)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GoodsType>()
                .HasMany(e => e.Goods)
                .WithRequired(e => e.GoodsType)
                .WillCascadeOnDelete(false);
        }
    }
}
