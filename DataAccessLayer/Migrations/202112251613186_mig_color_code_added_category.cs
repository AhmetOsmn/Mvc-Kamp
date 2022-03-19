namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_color_code_added_category : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "ColorCode", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "ColorCode");
        }
    }
}
