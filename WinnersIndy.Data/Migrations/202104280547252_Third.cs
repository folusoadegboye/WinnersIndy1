namespace WinnersIndy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MemberAddress", "Zipcode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MemberAddress", "Zipcode", c => c.Int(nullable: false));
        }
    }
}
