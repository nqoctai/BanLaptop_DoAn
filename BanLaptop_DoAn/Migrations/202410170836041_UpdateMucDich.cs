namespace BanLaptop_DoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMucDich : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MucDichSuDungs", "TenMucDich", c => c.String(nullable: false));
            DropColumn("dbo.SanPhams", "PhanKhucSanPham");
            DropColumn("dbo.MucDichSuDungs", "TenLoai");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MucDichSuDungs", "TenLoai", c => c.String(nullable: false));
            AddColumn("dbo.SanPhams", "PhanKhucSanPham", c => c.String());
            DropColumn("dbo.MucDichSuDungs", "TenMucDich");
        }
    }
}
