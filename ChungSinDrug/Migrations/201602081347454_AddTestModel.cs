namespace ChungSinDrug.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTestModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.icdtTests",
                c => new
                    {
                        icdtTest_Id = c.String(nullable: false, maxLength: 128),
                        icdtTest_DatePicker_StartOfDay = c.DateTime(nullable: false),
                        icdtTest_DatePicker_EndOfDay = c.DateTime(nullable: false),
                        icdtTest_DateDropDownList_StartOfDay = c.DateTime(nullable: false),
                        icdtTest_DateDropDownList_EndOfDay = c.DateTime(nullable: false),
                        icdtTest_DropDownList = c.String(),
                        icdtTest_CKEditor = c.String(),
                        icdtTest_Image = c.String(),
                        icdtTest_Checkbox = c.Boolean(nullable: false),
                        icdtTest_CreateTime = c.DateTime(nullable: false),
                        icdtTest_CreatorId = c.String(),
                        icdtTest_CreatorUserName = c.String(),
                        icdtTest_UpdateTime = c.DateTime(nullable: false),
                        icdtTest_UpdaterId = c.String(),
                        icdtTest_UpdaterUserName = c.String(),
                        icdtTest_DelLock = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.icdtTest_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.icdtTests");
        }
    }
}
