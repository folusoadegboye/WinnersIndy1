namespace WinnersIndy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MemberAddress", "Ownerid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MemberAddress", "Ownerid", c => c.Guid(nullable: false));
        }
    }
}
