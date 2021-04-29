namespace WinnersIndy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nine : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Member", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Member", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Member", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Member", "EmailAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Member", "DateOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Member", "DateOfBirth", c => c.String());
            AlterColumn("dbo.Member", "EmailAddress", c => c.String());
            AlterColumn("dbo.Member", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Member", "LastName", c => c.String());
            AlterColumn("dbo.Member", "FirstName", c => c.String());
        }
    }
}
