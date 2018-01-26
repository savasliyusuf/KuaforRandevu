namespace joseph.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KDB : DbContext
    {
        public KDB()
            : base("name=KDB1")
        {
        }

        public virtual DbSet<Calisan> Calisans { get; set; }
        public virtual DbSet<Musteri> Musteris { get; set; }
        public virtual DbSet<Randevu> Randevus { get; set; }
        public virtual DbSet<Saat> Saats { get; set; }
        public virtual DbSet<Yetki> Yetkis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
