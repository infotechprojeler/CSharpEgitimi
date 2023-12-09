namespace WindowsFormsApp3CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserCreateDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "CreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "CreateDate");
        }
    }
}
