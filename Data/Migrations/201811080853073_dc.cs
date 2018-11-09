namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Specialities",
                c => new
                    {
                        SpecialityId = c.Int(nullable: false, identity: true),
                        nomSpeciality = c.String(),
                    })
                .PrimaryKey(t => t.SpecialityId);
            
            AddColumn("dbo.AspNetUsers", "speciality_SpecialityId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "speciality_SpecialityId");
            AddForeignKey("dbo.AspNetUsers", "speciality_SpecialityId", "dbo.Specialities", "SpecialityId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "speciality_SpecialityId", "dbo.Specialities");
            DropIndex("dbo.AspNetUsers", new[] { "speciality_SpecialityId" });
            DropColumn("dbo.AspNetUsers", "speciality_SpecialityId");
            DropTable("dbo.Specialities");
        }
    }
}
