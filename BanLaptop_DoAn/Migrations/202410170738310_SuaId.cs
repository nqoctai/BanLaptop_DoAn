namespace BanLaptop_DoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SuaId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SanPhams", "LoaiSanPhamId", "dbo.LoaiSanPhams");
            DropIndex("dbo.SanPhams", new[] { "LoaiSanPhamId" });
            DropPrimaryKey("dbo.LoaiSanPhams");
            AlterColumn("dbo.LoaiSanPhams", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.SanPhams", "LoaiSanPhamId", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.LoaiSanPhams", "Id");
            CreateIndex("dbo.SanPhams", "LoaiSanPhamId");
            AddForeignKey("dbo.SanPhams", "LoaiSanPhamId", "dbo.LoaiSanPhams", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPhams", "LoaiSanPhamId", "dbo.LoaiSanPhams");
            DropIndex("dbo.SanPhams", new[] { "LoaiSanPhamId" });
            DropPrimaryKey("dbo.LoaiSanPhams");
            AlterColumn("dbo.SanPhams", "LoaiSanPhamId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.LoaiSanPhams", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.LoaiSanPhams", "Id");
            CreateIndex("dbo.SanPhams", "LoaiSanPhamId");
            AddForeignKey("dbo.SanPhams", "LoaiSanPhamId", "dbo.LoaiSanPhams", "Id", cascadeDelete: true);
        }
    }
}
