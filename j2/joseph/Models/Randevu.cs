namespace joseph.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Randevu")]
    public partial class Randevu
    {
        public int RandevuID { get; set; }

        public int MusteriNo { get; set; }

        public int CalisanNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime Tarih { get; set; }

        public int SaatID { get; set; }

        public virtual Calisan Calisan { get; set; }

        public virtual Musteri Musteri { get; set; }

        public virtual Saat Saat { get; set; }
    }
}
