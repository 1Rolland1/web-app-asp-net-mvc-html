namespace web_app_asp_net_mvc_html.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nationalities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NationalityGroups",
                c => new
                    {
                        Nationality_Id = c.Int(nullable: false),
                        Group_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Nationality_Id, t.Group_Id })
                .ForeignKey("dbo.Nationalities", t => t.Nationality_Id, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.Group_Id, cascadeDelete: true)
                .Index(t => t.Nationality_Id)
                .Index(t => t.Group_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NationalityGroups", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.NationalityGroups", "Nationality_Id", "dbo.Nationalities");
            DropIndex("dbo.NationalityGroups", new[] { "Group_Id" });
            DropIndex("dbo.NationalityGroups", new[] { "Nationality_Id" });
            DropTable("dbo.NationalityGroups");
            DropTable("dbo.Nationalities");
        }
    }
}
