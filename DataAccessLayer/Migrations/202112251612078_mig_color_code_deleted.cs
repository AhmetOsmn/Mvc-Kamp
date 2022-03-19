namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_color_code_deleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Writers", "ColorCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "ColorCode", c => c.String(maxLength: 15));
        }
    }
}
