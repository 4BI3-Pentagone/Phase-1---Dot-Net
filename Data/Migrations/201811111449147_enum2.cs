namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enum2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "SpecialityId", "dbo.Specialities");
            DropIndex("dbo.AspNetUsers", new[] { "SpecialityId" });
            AddColumn("dbo.AspNetUsers", "Speciality", c => c.Int());
            DropColumn("dbo.AspNetUsers", "SpecialityId");
            DropTable("dbo.Specialities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Specialities",
                c => new
                    {
                        SpecialityId = c.Int(nullable: false, identity: true),
                        nomSpeciality = c.String(),
                    })
                .PrimaryKey(t => t.SpecialityId);
            
            AddColumn("dbo.AspNetUsers", "SpecialityId", c => c.Int());
            DropColumn("dbo.AspNetUsers", "Speciality");
            CreateIndex("dbo.AspNetUsers", "SpecialityId");
            AddForeignKey("dbo.AspNetUsers", "SpecialityId", "dbo.Specialities", "SpecialityId");
        }
    }
}
