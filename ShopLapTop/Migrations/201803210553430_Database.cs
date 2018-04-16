namespace ShopLapTop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChildCategory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Maloai = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Loai", t => t.Maloai)
                .Index(t => t.Maloai);
            
            CreateTable(
                "dbo.Loai",
                c => new
                    {
                        Maloai = c.Int(nullable: false),
                        Tenloai = c.String(maxLength: 60),
                    })
                .PrimaryKey(t => t.Maloai);
            
            CreateTable(
                "dbo.Sanpham",
                c => new
                    {
                        MaSP = c.Int(nullable: false),
                        TenSP = c.String(nullable: false, maxLength: 150),
                        cpu = c.String(nullable: false, maxLength: 200, unicode: false),
                        vga = c.String(nullable: false, maxLength: 200, unicode: false),
                        ram = c.String(nullable: false, maxLength: 100, unicode: false),
                        hdd = c.String(maxLength: 100, unicode: false),
                        ssd = c.String(maxLength: 70, unicode: false),
                        manhinh = c.String(nullable: false, maxLength: 200, unicode: false),
                        cd_dvd = c.String(nullable: false, maxLength: 100, unicode: false),
                        ketnoi = c.String(nullable: false, maxLength: 150),
                        tichhop = c.String(nullable: false, maxLength: 300),
                        trongluong = c.String(nullable: false, maxLength: 30),
                        pin = c.String(nullable: false, maxLength: 30),
                        hdh = c.String(nullable: false, maxLength: 90),
                        Giaban = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Giakhuyenmai = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BaoHanh = c.Int(nullable: false),
                        Mota = c.String(nullable: false, storeType: "ntext"),
                        Ngayban = c.DateTime(storeType: "date"),
                        Hinh = c.String(nullable: false, maxLength: 70, unicode: false),
                        trangthai = c.Boolean(),
                        Maloai = c.Int(nullable: false),
                        Mahieu = c.Int(nullable: false),
                        LikeCount = c.Int(),
                    })
                .PrimaryKey(t => t.MaSP)
                .ForeignKey("dbo.Loai", t => t.Maloai, cascadeDelete: true)
                .ForeignKey("dbo.Nhanhieu", t => t.Mahieu, cascadeDelete: true)
                .Index(t => t.Maloai)
                .Index(t => t.Mahieu);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        ProductID = c.Int(nullable: false),
                        Datetime = c.DateTime(),
                        UserName = c.String(),
                        Content = c.String(),
                        LikeCount = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        sanpham_MaSP = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sanpham", t => t.sanpham_MaSP)
                .Index(t => t.sanpham_MaSP);
            
            CreateTable(
                "dbo.CommentLike",
                c => new
                    {
                        CommentID = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        Like = c.Boolean(nullable: false),
                        Dislike = c.Boolean(nullable: false),
                        Comment_ID = c.String(),
                        comment_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Comment", t => t.comment_ID)
                .Index(t => t.comment_ID);
            
            CreateTable(
                "dbo.Reply",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        ProductID = c.Int(nullable: false),
                        CommentId = c.String(maxLength: 128),
                        ParentReplyID = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        UserName = c.String(),
                        Content = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        sanpham_MaSP = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Comment", t => t.CommentId)
                .ForeignKey("dbo.Sanpham", t => t.sanpham_MaSP)
                .Index(t => t.CommentId)
                .Index(t => t.sanpham_MaSP);
            
            CreateTable(
                "dbo.ReplyLike",
                c => new
                    {
                        ReplyID = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        Like = c.Boolean(nullable: false),
                        Dislike = c.Boolean(nullable: false),
                        Reply_ID = c.String(),
                        reply_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ReplyID)
                .ForeignKey("dbo.Reply", t => t.reply_ID)
                .Index(t => t.reply_ID);
            
            CreateTable(
                "dbo.CT_HoaDon",
                c => new
                    {
                        MaHD = c.Int(nullable: false),
                        MaSP = c.Int(nullable: false),
                        Soluong = c.Int(),
                        Dongia = c.Decimal(precision: 18, scale: 0),
                    })
                .PrimaryKey(t => new { t.MaHD, t.MaSP })
                .ForeignKey("dbo.Hoadon", t => t.MaHD)
                .ForeignKey("dbo.Sanpham", t => t.MaSP)
                .Index(t => t.MaHD)
                .Index(t => t.MaSP);
            
            CreateTable(
                "dbo.Hoadon",
                c => new
                    {
                        MaHD = c.Int(nullable: false, identity: true),
                        Ngaymua = c.DateTime(storeType: "date"),
                        Email = c.String(maxLength: 50, unicode: false),
                        Ngaygiaohang = c.DateTime(storeType: "date"),
                        TrigiaHD = c.Decimal(precision: 18, scale: 0),
                    })
                .PrimaryKey(t => t.MaHD)
                .ForeignKey("dbo.Khachhang", t => t.Email)
                .Index(t => t.Email);
            
            CreateTable(
                "dbo.Khachhang",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(maxLength: 50, unicode: false),
                        Hoten = c.String(maxLength: 60),
                        Gioitinh = c.String(maxLength: 6),
                        Diachi = c.String(maxLength: 90),
                        Dienthoai = c.String(maxLength: 11, unicode: false),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.Nhanhieu",
                c => new
                    {
                        Mahieu = c.Int(nullable: false),
                        Tenhieu = c.String(maxLength: 60),
                        hinh = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Mahieu);
            
            CreateTable(
                "dbo.ProductLike",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Like = c.Boolean(nullable: false),
                        Dislike = c.Boolean(nullable: false),
                        Product_ID = c.Int(nullable: false),
                        sanpham_MaSP = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sanpham", t => t.sanpham_MaSP)
                .Index(t => t.sanpham_MaSP);
            
            CreateTable(
                "dbo.Credential",
                c => new
                    {
                        UserGroupID = c.String(nullable: false, maxLength: 128),
                        RoleID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserGroupID, t.RoleID });
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.taikhoan",
                c => new
                    {
                        username = c.String(nullable: false, maxLength: 60, unicode: false),
                        password = c.String(nullable: false, maxLength: 60, unicode: false),
                        status = c.Boolean(nullable: false),
                        GroupID = c.String(),
                    })
                .PrimaryKey(t => t.username);
            
            CreateTable(
                "dbo.UserGroup",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductLike", "sanpham_MaSP", "dbo.Sanpham");
            DropForeignKey("dbo.Sanpham", "Mahieu", "dbo.Nhanhieu");
            DropForeignKey("dbo.Sanpham", "Maloai", "dbo.Loai");
            DropForeignKey("dbo.CT_HoaDon", "MaSP", "dbo.Sanpham");
            DropForeignKey("dbo.Hoadon", "Email", "dbo.Khachhang");
            DropForeignKey("dbo.CT_HoaDon", "MaHD", "dbo.Hoadon");
            DropForeignKey("dbo.Comment", "sanpham_MaSP", "dbo.Sanpham");
            DropForeignKey("dbo.Reply", "sanpham_MaSP", "dbo.Sanpham");
            DropForeignKey("dbo.ReplyLike", "reply_ID", "dbo.Reply");
            DropForeignKey("dbo.Reply", "CommentId", "dbo.Comment");
            DropForeignKey("dbo.CommentLike", "comment_ID", "dbo.Comment");
            DropForeignKey("dbo.ChildCategory", "Maloai", "dbo.Loai");
            DropIndex("dbo.ProductLike", new[] { "sanpham_MaSP" });
            DropIndex("dbo.Hoadon", new[] { "Email" });
            DropIndex("dbo.CT_HoaDon", new[] { "MaSP" });
            DropIndex("dbo.CT_HoaDon", new[] { "MaHD" });
            DropIndex("dbo.ReplyLike", new[] { "reply_ID" });
            DropIndex("dbo.Reply", new[] { "sanpham_MaSP" });
            DropIndex("dbo.Reply", new[] { "CommentId" });
            DropIndex("dbo.CommentLike", new[] { "comment_ID" });
            DropIndex("dbo.Comment", new[] { "sanpham_MaSP" });
            DropIndex("dbo.Sanpham", new[] { "Mahieu" });
            DropIndex("dbo.Sanpham", new[] { "Maloai" });
            DropIndex("dbo.ChildCategory", new[] { "Maloai" });
            DropTable("dbo.UserGroup");
            DropTable("dbo.taikhoan");
            DropTable("dbo.Role");
            DropTable("dbo.Credential");
            DropTable("dbo.ProductLike");
            DropTable("dbo.Nhanhieu");
            DropTable("dbo.Khachhang");
            DropTable("dbo.Hoadon");
            DropTable("dbo.CT_HoaDon");
            DropTable("dbo.ReplyLike");
            DropTable("dbo.Reply");
            DropTable("dbo.CommentLike");
            DropTable("dbo.Comment");
            DropTable("dbo.Sanpham");
            DropTable("dbo.Loai");
            DropTable("dbo.ChildCategory");
        }
    }
}
