namespace BanLaptop_DoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThemLoaiSanPham : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoaiSanPhams",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        TenLoai = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SanPhams", "LoaiSanPhamId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.SanPhams", "LoaiSanPhamId");
            AddForeignKey("dbo.SanPhams", "LoaiSanPhamId", "dbo.LoaiSanPhams", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPhams", "LoaiSanPhamId", "dbo.LoaiSanPhams");
            DropIndex("dbo.SanPhams", new[] { "LoaiSanPhamId" });
            DropColumn("dbo.SanPhams", "LoaiSanPhamId");
            DropTable("dbo.LoaiSanPhams");
        }
    }
}
