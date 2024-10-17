namespace BanLaptop_DoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SanPhams",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Ten = c.String(),
                        Gia = c.Double(nullable: false),
                        HinhAnh = c.String(),
                        MoTaChiTiet = c.String(),
                        MoTaNgan = c.String(),
                        SoLuong = c.Long(nullable: false),
                        DaBan = c.Long(nullable: false),
                        PhanKhucSanPham = c.String(),
                        ThuongHieuId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ThuongHieus", t => t.ThuongHieuId, cascadeDelete: true)
                .Index(t => t.ThuongHieuId);
            
            CreateTable(
                "dbo.ThuongHieus",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenThuongHieu = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPhams", "ThuongHieuId", "dbo.ThuongHieus");
            DropIndex("dbo.SanPhams", new[] { "ThuongHieuId" });
            DropTable("dbo.ThuongHieus");
            DropTable("dbo.SanPhams");
        }
    }
}
