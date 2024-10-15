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
                        ThuongHieu = c.String(),
                        PhanKhucSanPham = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SanPhams");
        }
    }
}
