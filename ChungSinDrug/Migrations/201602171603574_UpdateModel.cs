namespace ChungSinDrug.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.News");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.News",
                c => new
                    {
                        News_Id = c.String(nullable: false, maxLength: 128),
                        News_Title = c.String(),
                        News_StartTime = c.DateTime(nullable: false),
                        News_EndTime = c.DateTime(nullable: false),
                        News_Content = c.String(),
                        News_CoverImage = c.String(),
                        News_Tag = c.String(nullable: false),
                        News_IsPublish = c.Boolean(nullable: false),
                        News_IsTop = c.Boolean(nullable: false),
                        News_CreateTime = c.DateTime(nullable: false),
                        News_CreatorId = c.String(),
                        News_CreatorUserName = c.String(),
                        News_UpdateTime = c.DateTime(nullable: false),
                        News_UpdaterId = c.String(),
                        News_UpdaterUserName = c.String(),
                        News_DelLock = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.News_Id);
            
        }
    }
}
