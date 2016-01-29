namespace ChungSinDrug.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNewsModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "News_StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.News", "News_EndTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "News_EndTime");
            DropColumn("dbo.News", "News_StartTime");
        }
    }
}
