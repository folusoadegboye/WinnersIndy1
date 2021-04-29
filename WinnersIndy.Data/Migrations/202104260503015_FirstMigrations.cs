namespace WinnersIndy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigrations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MemberAddress", "Ownerid", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MemberAddress", "Ownerid");
        }
    }
}
