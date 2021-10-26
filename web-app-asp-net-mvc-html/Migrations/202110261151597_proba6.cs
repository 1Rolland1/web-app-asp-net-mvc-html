namespace web_app_asp_net_mvc_html.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proba6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Lessons", "DisciplineGoal");
            DropColumn("dbo.Lessons", "DisciplineObjectives");
            DropColumn("dbo.Lessons", "MainSections");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lessons", "MainSections", c => c.String(nullable: false));
            AddColumn("dbo.Lessons", "DisciplineObjectives", c => c.String(nullable: false));
            AddColumn("dbo.Lessons", "DisciplineGoal", c => c.String(nullable: false));
        }
    }
}
