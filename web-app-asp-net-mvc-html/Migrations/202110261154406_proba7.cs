namespace web_app_asp_net_mvc_html.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proba7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Lessons", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lessons", "Name", c => c.String(nullable: false));
        }
    }
}
