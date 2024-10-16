namespace BanLaptop_DoAn.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class themavatar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NguoiDung", "Avatar", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NguoiDung", "Avatar");
        }
    }
}
