using ShopLapTop.Areas.Admin.Dao;
using ShopLapTop.Areas.Admin.Lopdungchung;
namespace ShopLapTop.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sanpham")]
    public partial class Sanpham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sanpham()
        {
            CT_HoaDon = new HashSet<CT_HoaDon>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Không được để trống")]

        public int MaSP { get; set; }
        [DataType(DataType.Currency, ErrorMessage = "Chỉ được nhập số")]
        [Required(ErrorMessage = "không được để trống")]
        [StringLength(150)]

        public string  TenSP { get; set; }
       // bodautiengviet.LoaiBoDauTiengViet(TenSP)


        [Required(ErrorMessage = "không được để trống")]
        [StringLength(200)]
        public string cpu { get; set; }


        [Required(ErrorMessage = "không được để trống")]
        [StringLength(200)]
        public string vga { get; set; }


        [Required(ErrorMessage = "không được để trống")]
        [StringLength(100)]
        public string ram { get; set; }


        [StringLength(100)]
        //[Required(ErrorMessage = "không được để trống")]
        public string hdd { get; set; }


        [StringLength(70)]
        //[Required(ErrorMessage = "không được để trống")]
        public string ssd { get; set; }


        [StringLength(200)]
        [Required(ErrorMessage = "không được để trống")]
        public string manhinh { get; set; }


        [Required(ErrorMessage = "không được để trống")]
        [StringLength(100)]
        public string cd_dvd { get; set; }

        [Required(ErrorMessage = "không được để trống")]
        [StringLength(150)]
        public string ketnoi { get; set; }


        [Required(ErrorMessage = "không được để trống")]
        [StringLength(300)]
        public string tichhop { get; set; }


        [Required(ErrorMessage = "không được để trống")]
        [StringLength(30)]
        public string trongluong { get; set; }


        [Required(ErrorMessage = "không được để trống")]
        [StringLength(30)]
        public string pin { get; set; }

        [Required(ErrorMessage = "không được để trống")]
        [StringLength(90)]
        public string hdh { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Range(100000, 1000000000, ErrorMessage = "Tiền phải từ 100K đến 1000000K")]
        [tienVN(ErrorMessage = "Không phải tiền VN")]
        public decimal? Giaban { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Range(100000, 1000000000, ErrorMessage = "Tiền phải từ 100K đến 1000000K")]
        [tienVN(ErrorMessage = "Không phải tiền VN")]
        public decimal? Giakhuyenmai { get; set; }


        [Required(ErrorMessage = "không được để trống")]
        [DataType(DataType.Currency, ErrorMessage = "Chỉ được nhập số")]
        public int? BaoHanh { get; set; }


        [Required(ErrorMessage = "không được để trống")]
        [Column(TypeName = "ntext")]
        public string Mota { get; set; }

        //[Required(ErrorMessage = "không được để trống")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date, ErrorMessage = "Phải nhập kiểu ngày tháng năm")]
        public DateTime? Ngayban { get; set; }

        [Required(ErrorMessage = "không được để trống")]
        [StringLength(70)]
        public string Hinh { get; set; }


        //[Required(ErrorMessage = "không được để trống")]
        public bool? trangthai { get; set; }


        [Required(ErrorMessage = "không được để trống")]
        public int? Maloai { get; set; }


        [Required(ErrorMessage = "không được để trống")]
        public int? Mahieu { get; set; }

        // đếm like
        [DefaultValue(0)] 
        public int? LikeCount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HoaDon> CT_HoaDon { get; set; }

        //[Required(ErrorMessage = "không được để trống")]
        //[DataType(DataType.Currency, ErrorMessage = "Chỉ được nhập số")]
        public virtual Loai Loai { get; set; }
   
        //[DataType(DataType.Currency, ErrorMessage = "Chỉ được nhập số")]
        //[Required(ErrorMessage = "không được để trống")]
        public virtual Nhanhieu Nhanhieu { get; set; }

        


        // lấy Comment
        public virtual ICollection<Comment>  comment{get;set;}
        
        // lấy Reply
        public virtual ICollection<Reply> Replies { get; set; }

        // Lấy ProductLike
        public virtual ICollection<ProductLike> ProductLike { get; set; }
    }
}
