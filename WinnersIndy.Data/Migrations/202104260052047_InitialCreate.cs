namespace WinnersIndy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chat",
                c => new
                    {
                        ChatId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        dateTimeOffset = c.DateTimeOffset(precision: 7),
                        MemberID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChatId)
                .ForeignKey("dbo.Member", t => t.MemberID, cascadeDelete: true)
                .Index(t => t.MemberID);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        EmailAddress = c.String(),
                        DateOfBirth = c.String(),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceUnit",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceUnitExecutive",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UnitHeadName = c.String(),
                        UnitAssistanceName = c.String(),
                        UnitSecretaryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MemberAddress",
                c => new
                    {
                        MemberAddressID = c.Int(nullable: false),
                        StreetName = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MemberAddressID)
                .ForeignKey("dbo.Member", t => t.MemberAddressID)
                .Index(t => t.MemberAddressID);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        MessageType = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ServiceUnitMember",
                c => new
                    {
                        ServiceUnit_Id = c.Int(nullable: false),
                        Member_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ServiceUnit_Id, t.Member_Id })
                .ForeignKey("dbo.ServiceUnit", t => t.ServiceUnit_Id, cascadeDelete: true)
                .ForeignKey("dbo.Member", t => t.Member_Id, cascadeDelete: true)
                .Index(t => t.ServiceUnit_Id)
                .Index(t => t.Member_Id);
            
            CreateTable(
                "dbo.ServiceUnitExecutiveServiceUnit",
                c => new
                    {
                        ServiceUnitExecutive_Id = c.Int(nullable: false),
                        ServiceUnit_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ServiceUnitExecutive_Id, t.ServiceUnit_Id })
                .ForeignKey("dbo.ServiceUnitExecutive", t => t.ServiceUnitExecutive_Id, cascadeDelete: true)
                .ForeignKey("dbo.ServiceUnit", t => t.ServiceUnit_Id, cascadeDelete: true)
                .Index(t => t.ServiceUnitExecutive_Id)
                .Index(t => t.ServiceUnit_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Chat", "MemberID", "dbo.Member");
            DropForeignKey("dbo.MemberAddress", "MemberAddressID", "dbo.Member");
            DropForeignKey("dbo.ServiceUnitExecutiveServiceUnit", "ServiceUnit_Id", "dbo.ServiceUnit");
            DropForeignKey("dbo.ServiceUnitExecutiveServiceUnit", "ServiceUnitExecutive_Id", "dbo.ServiceUnitExecutive");
            DropForeignKey("dbo.ServiceUnitMember", "Member_Id", "dbo.Member");
            DropForeignKey("dbo.ServiceUnitMember", "ServiceUnit_Id", "dbo.ServiceUnit");
            DropIndex("dbo.ServiceUnitExecutiveServiceUnit", new[] { "ServiceUnit_Id" });
            DropIndex("dbo.ServiceUnitExecutiveServiceUnit", new[] { "ServiceUnitExecutive_Id" });
            DropIndex("dbo.ServiceUnitMember", new[] { "Member_Id" });
            DropIndex("dbo.ServiceUnitMember", new[] { "ServiceUnit_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.MemberAddress", new[] { "MemberAddressID" });
            DropIndex("dbo.Chat", new[] { "MemberID" });
            DropTable("dbo.ServiceUnitExecutiveServiceUnit");
            DropTable("dbo.ServiceUnitMember");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Message");
            DropTable("dbo.MemberAddress");
            DropTable("dbo.ServiceUnitExecutive");
            DropTable("dbo.ServiceUnit");
            DropTable("dbo.Member");
            DropTable("dbo.Chat");
        }
    }
}
