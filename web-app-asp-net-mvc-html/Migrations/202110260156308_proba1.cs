namespace web_app_asp_net_mvc_html.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proba1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Disciplines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DisciplineGoal = c.String(nullable: false),
                        DisciplineObjectives = c.String(nullable: false),
                        MainSections = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Lessons", "Discipline_Id", c => c.Int());
            CreateIndex("dbo.Lessons", "Discipline_Id");
            AddForeignKey("dbo.Lessons", "Discipline_Id", "dbo.Disciplines", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "Discipline_Id", "dbo.Disciplines");
            DropIndex("dbo.Lessons", new[] { "Discipline_Id" });
            DropColumn("dbo.Lessons", "Discipline_Id");
            DropTable("dbo.Disciplines");
        }
    }
}
