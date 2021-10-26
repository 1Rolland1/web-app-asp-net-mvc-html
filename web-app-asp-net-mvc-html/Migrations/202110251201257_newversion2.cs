namespace web_app_asp_net_mvc_html.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newversion2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lessons", "DisciplineGoal", c => c.String(nullable: false));
            AddColumn("dbo.Lessons", "DisciplineObjectives", c => c.String(nullable: false));
            AddColumn("dbo.Lessons", "MainSections", c => c.String(nullable: false));
            DropColumn("dbo.Lessons", "Annotation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lessons", "Annotation", c => c.String(nullable: false));
            DropColumn("dbo.Lessons", "MainSections");
            DropColumn("dbo.Lessons", "DisciplineObjectives");
            DropColumn("dbo.Lessons", "DisciplineGoal");
        }
    }
}
