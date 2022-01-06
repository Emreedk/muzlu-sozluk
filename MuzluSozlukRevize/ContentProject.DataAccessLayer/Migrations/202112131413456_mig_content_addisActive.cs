namespace ContentProject.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_content_addisActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "isActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "isActive");
        }
    }
}
