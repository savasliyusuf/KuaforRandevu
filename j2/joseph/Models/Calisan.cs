namespace joseph.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Calisan")]
    public partial class Calisan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Calisan()
        {
            Randevus = new HashSet<Randevu>();
        }

        [Key]
        public int CalisanNo { get; set; }

        [Required]
        [StringLength(20)]
        public string Adi { get; set; }

        [Required]
        [StringLength(50)]
        public string Soyadi { get; set; }

        [Required]
        [StringLength(20)]
        public string KullaniciAdi { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Sifre { get; set; }

        [Required]
        public string Adres { get; set; }

        [Required]
        [StringLength(11)]
        public string Telefon { get; set; }

        [Required]
        [StringLength(50)]
        public string Uzmanlik { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Randevu> Randevus { get; set; }
    }
}
