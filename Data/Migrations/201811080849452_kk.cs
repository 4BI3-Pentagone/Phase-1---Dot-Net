namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kk : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "speciality");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "speciality", c => c.Int());
        }
    }
}
