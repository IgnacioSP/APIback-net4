namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "title", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "content", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "content", c => c.String());
            AlterColumn("dbo.Posts", "title", c => c.String());
        }
    }
}
