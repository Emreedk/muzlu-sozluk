namespace ContentProject.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_heading_addisactive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headings", "isActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Headings", "isActive");
        }
    }
}
