namespace web_app_asp_net_mvc_html.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(nullable: false),
                        NumberOfStudents = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Sex = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeacherImages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Guid = c.Guid(nullable: false),
                        Data = c.Binary(nullable: false),
                        ContentType = c.String(maxLength: 100),
                        DateChanged = c.DateTime(),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lessons", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.LessonGroups",
                c => new
                    {
                        Lesson_Id = c.Int(nullable: false),
                        Group_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Lesson_Id, t.Group_Id })
                .ForeignKey("dbo.Lessons", t => t.Lesson_Id, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.Group_Id, cascadeDelete: true)
                .Index(t => t.Lesson_Id)
                .Index(t => t.Group_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherImages", "Id", "dbo.Lessons");
            DropForeignKey("dbo.Lessons", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.LessonGroups", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.LessonGroups", "Lesson_Id", "dbo.Lessons");
            DropIndex("dbo.LessonGroups", new[] { "Group_Id" });
            DropIndex("dbo.LessonGroups", new[] { "Lesson_Id" });
            DropIndex("dbo.TeacherImages", new[] { "Id" });
            DropIndex("dbo.Lessons", new[] { "TeacherId" });
            DropTable("dbo.LessonGroups");
            DropTable("dbo.TeacherImages");
            DropTable("dbo.Teachers");
            DropTable("dbo.Lessons");
            DropTable("dbo.Groups");
        }
    }
}
