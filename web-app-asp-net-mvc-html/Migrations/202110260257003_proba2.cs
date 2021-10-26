namespace web_app_asp_net_mvc_html.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proba2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lessons", "Discipline_Id", "dbo.Disciplines");
            DropIndex("dbo.Lessons", new[] { "Discipline_Id" });
            RenameColumn(table: "dbo.Lessons", name: "Discipline_Id", newName: "DisciplineId");
            AlterColumn("dbo.Lessons", "DisciplineId", c => c.Int(nullable: false));
            CreateIndex("dbo.Lessons", "DisciplineId");
            AddForeignKey("dbo.Lessons", "DisciplineId", "dbo.Disciplines", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "DisciplineId", "dbo.Disciplines");
            DropIndex("dbo.Lessons", new[] { "DisciplineId" });
            AlterColumn("dbo.Lessons", "DisciplineId", c => c.Int());
            RenameColumn(table: "dbo.Lessons", name: "DisciplineId", newName: "Discipline_Id");
            CreateIndex("dbo.Lessons", "Discipline_Id");
            AddForeignKey("dbo.Lessons", "Discipline_Id", "dbo.Disciplines", "Id");
        }
    }
}
