namespace web_app_asp_net_mvc_html.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proba5 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.LessonGroups", newName: "GroupLessons");
            DropPrimaryKey("dbo.GroupLessons");
            AddPrimaryKey("dbo.GroupLessons", new[] { "Group_Id", "Lesson_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.GroupLessons");
            AddPrimaryKey("dbo.GroupLessons", new[] { "Lesson_Id", "Group_Id" });
            RenameTable(name: "dbo.GroupLessons", newName: "LessonGroups");
        }
    }
}
