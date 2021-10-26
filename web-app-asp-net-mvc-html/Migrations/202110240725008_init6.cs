namespace web_app_asp_net_mvc_html.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PositionTeachers",
                c => new
                    {
                        Position_Id = c.Int(nullable: false),
                        Teacher_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Position_Id, t.Teacher_Id })
                .ForeignKey("dbo.Positions", t => t.Position_Id, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id, cascadeDelete: true)
                .Index(t => t.Position_Id)
                .Index(t => t.Teacher_Id);
            
            DropColumn("dbo.Teachers", "Position");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "Position", c => c.Int(nullable: false));
            DropForeignKey("dbo.PositionTeachers", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.PositionTeachers", "Position_Id", "dbo.Positions");
            DropIndex("dbo.PositionTeachers", new[] { "Teacher_Id" });
            DropIndex("dbo.PositionTeachers", new[] { "Position_Id" });
            DropTable("dbo.PositionTeachers");
            DropTable("dbo.Positions");
        }
    }
}
