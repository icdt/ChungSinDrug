namespace ChungSinDrug.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthOptions",
                c => new
                    {
                        AuthOption_Id = c.String(nullable: false, maxLength: 128),
                        AuthOption_Admin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AuthOption_Id);
            
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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IdFK_UserProfile = c.String(maxLength: 128),
                        IdFK_AuthOptions = c.String(maxLength: 128),
                        DelLock = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        CreatorId = c.String(),
                        CreatorUserName = c.String(),
                        UpdateTime = c.DateTime(nullable: false),
                        UpdaterId = c.String(),
                        UpdaterUserName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuthOptions", t => t.IdFK_AuthOptions)
                .ForeignKey("dbo.MemberProfiles", t => t.IdFK_UserProfile)
                .Index(t => t.IdFK_UserProfile)
                .Index(t => t.IdFK_AuthOptions)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MemberProfiles",
                c => new
                    {
                        Profile_Id = c.String(nullable: false, maxLength: 128),
                        CustomerProfile_Name = c.String(),
                        EmployeeProfile_Name = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Profile_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "IdFK_UserProfile", "dbo.MemberProfiles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "IdFK_AuthOptions", "dbo.AuthOptions");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "IdFK_AuthOptions" });
            DropIndex("dbo.AspNetUsers", new[] { "IdFK_UserProfile" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.MemberProfiles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.SystemParas");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.News");
            DropTable("dbo.AuthOptions");
        }
    }
}
