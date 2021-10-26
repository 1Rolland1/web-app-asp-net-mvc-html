namespace web_app_asp_net_mvc_html.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TeacherImages", "Id", "dbo.Lessons");
            AddForeignKey("dbo.TeacherImages", "Id", "dbo.Teachers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherImages", "Id", "dbo.Teachers");
            AddForeignKey("dbo.TeacherImages", "Id", "dbo.Lessons", "Id", cascadeDelete: true);
        }
    }
}
