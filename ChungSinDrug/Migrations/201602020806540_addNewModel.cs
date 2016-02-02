namespace ChungSinDrug.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SystemParas",
                c => new
                    {
                        SystemPara_Id = c.String(nullable: false, maxLength: 128),
                        SystemPara_ParentId = c.String(),
                        SystemPara_Name = c.String(),
                        SystemPara_Code = c.String(),
                        SystemPara_Sort = c.Int(nullable: false),
                        SystemPara_Group = c.String(),
                        SystemPara_DelLock = c.Boolean(nullable: false),
                        SystemPara_CreateTime = c.DateTime(nullable: false),
                        SystemPara_CreatorId = c.String(),
                        SystemPara_CreatorUserName = c.String(),
                        SystemPara_UpdateTime = c.DateTime(nullable: false),
                        SystemPara_UpdaterId = c.String(),
                        SystemPara_UpdaterUserName = c.String(),
                    })
                .PrimaryKey(t => t.SystemPara_Id);
            
            AddColumn("dbo.News", "News_Tag", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "News_Tag");
            DropTable("dbo.SystemParas");
        }
    }
}
