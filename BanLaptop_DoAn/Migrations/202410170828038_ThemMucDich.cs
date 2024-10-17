namespace BanLaptop_DoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThemMucDich : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MucDichSuDungs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenLoai = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SanPhams", "MucDichSuDungId", c => c.Long(nullable: false));
            CreateIndex("dbo.SanPhams", "MucDichSuDungId");
            AddForeignKey("dbo.SanPhams", "MucDichSuDungId", "dbo.MucDichSuDungs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPhams", "MucDichSuDungId", "dbo.MucDichSuDungs");
            DropIndex("dbo.SanPhams", new[] { "MucDichSuDungId" });
            DropColumn("dbo.SanPhams", "MucDichSuDungId");
            DropTable("dbo.MucDichSuDungs");
        }
    }
}
