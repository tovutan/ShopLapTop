
namespace ShopLapTop.Areas.Admin.Models
{
    using System;     
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Khachhang")]
    public partial class Khachhang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Khachhang()
        {
            Hoadons = new HashSet<Hoadon>();
        }
      

        [Key]
        [StringLength(50)]
        [Required(ErrorMessage ="Vui lòng nhập Email")]
       
        public string Email { get; set; }

       
        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(60)]     
        public string Hoten { get; set; }

        [StringLength(6)]
        public string Gioitinh { get; set; }

        [StringLength(90)]    
        public string Diachi { get; set; }
  
        [StringLength(11)]     
        public string Dienthoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
