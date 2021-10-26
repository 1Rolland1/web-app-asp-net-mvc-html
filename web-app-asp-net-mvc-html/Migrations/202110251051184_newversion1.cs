namespace web_app_asp_net_mvc_html.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newversion1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teachers", "PositionId", "dbo.Positions");
            DropIndex("dbo.Teachers", new[] { "PositionId" });
            AddColumn("dbo.Teachers", "Position", c => c.Int(nullable: false));
            DropColumn("dbo.Teachers", "PositionId");
            DropTable("dbo.Positions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Teachers", "PositionId", c => c.Int(nullable: false));
            DropColumn("dbo.Teachers", "Position");
            CreateIndex("dbo.Teachers", "PositionId");
            AddForeignKey("dbo.Teachers", "PositionId", "dbo.Positions", "Id", cascadeDelete: true);
        }
    }
}
