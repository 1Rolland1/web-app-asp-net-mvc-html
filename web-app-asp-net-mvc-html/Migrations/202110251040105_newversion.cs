namespace web_app_asp_net_mvc_html.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newversion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PositionTeachers", "Position_Id", "dbo.Positions");
            DropForeignKey("dbo.PositionTeachers", "Teacher_Id", "dbo.Teachers");
            DropIndex("dbo.PositionTeachers", new[] { "Position_Id" });
            DropIndex("dbo.PositionTeachers", new[] { "Teacher_Id" });
            AddColumn("dbo.Teachers", "PositionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Teachers", "PositionId");
            AddForeignKey("dbo.Teachers", "PositionId", "dbo.Positions", "Id", cascadeDelete: true);
            DropTable("dbo.PositionTeachers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PositionTeachers",
                c => new
                    {
                        Position_Id = c.Int(nullable: false),
                        Teacher_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Position_Id, t.Teacher_Id });
            
            DropForeignKey("dbo.Teachers", "PositionId", "dbo.Positions");
            DropIndex("dbo.Teachers", new[] { "PositionId" });
            DropColumn("dbo.Teachers", "PositionId");
            CreateIndex("dbo.PositionTeachers", "Teacher_Id");
            CreateIndex("dbo.PositionTeachers", "Position_Id");
            AddForeignKey("dbo.PositionTeachers", "Teacher_Id", "dbo.Teachers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PositionTeachers", "Position_Id", "dbo.Positions", "Id", cascadeDelete: true);
        }
    }
}
