namespace ShopLapTop.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hoadon")]
    public partial class Hoadon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hoadon()
        {
            CT_HoaDon = new HashSet<CT_HoaDon>();
        }

        [Key]
        public int MaHD { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaymua { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaygiaohang { get; set; }

        public decimal? TrigiaHD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HoaDon> CT_HoaDon { get; set; }

        public virtual Khachhang Khachhang { get; set; }
    }
}
