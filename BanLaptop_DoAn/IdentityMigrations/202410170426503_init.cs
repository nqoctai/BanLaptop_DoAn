namespace BanLaptop_DoAn.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VaiTro",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        TenVaiTro = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenVaiTro, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.VaiTroNguoiDung",
                c => new
                    {
                        IdNguoiDung = c.String(nullable: false, maxLength: 128),
                        IdVaiTro = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.IdNguoiDung, t.IdVaiTro })
                .ForeignKey("dbo.VaiTro", t => t.IdVaiTro, cascadeDelete: true)
                .ForeignKey("dbo.NguoiDung", t => t.IdNguoiDung, cascadeDelete: true)
                .Index(t => t.IdNguoiDung)
                .Index(t => t.IdVaiTro);
            
            CreateTable(
                "dbo.NguoiDung",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        NgaySinh = c.DateTime(),
                        DiaChi = c.String(),
                        HoVaTen = c.String(),
                        Avatar = c.String(),
                        Email = c.String(maxLength: 256),
                        XacNhanEmail = c.Boolean(nullable: false),
                        MatKhau = c.String(),
                        SecurityStamp = c.String(),
                        SoDienThoai = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        TenNguoiDung = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenNguoiDung, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NguoiDung", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.DangNhapNguoiDung",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.NguoiDung", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VaiTroNguoiDung", "IdNguoiDung", "dbo.NguoiDung");
            DropForeignKey("dbo.DangNhapNguoiDung", "UserId", "dbo.NguoiDung");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.NguoiDung");
            DropForeignKey("dbo.VaiTroNguoiDung", "IdVaiTro", "dbo.VaiTro");
            DropIndex("dbo.DangNhapNguoiDung", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.NguoiDung", "UserNameIndex");
            DropIndex("dbo.VaiTroNguoiDung", new[] { "IdVaiTro" });
            DropIndex("dbo.VaiTroNguoiDung", new[] { "IdNguoiDung" });
            DropIndex("dbo.VaiTro", "RoleNameIndex");
            DropTable("dbo.DangNhapNguoiDung");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.NguoiDung");
            DropTable("dbo.VaiTroNguoiDung");
            DropTable("dbo.VaiTro");
        }
    }
}
