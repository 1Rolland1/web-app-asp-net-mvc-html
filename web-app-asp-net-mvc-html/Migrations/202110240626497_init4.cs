namespace web_app_asp_net_mvc_html.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lessons", "Annotation", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lessons", "Annotation");
        }
    }
}
