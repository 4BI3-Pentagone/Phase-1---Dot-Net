namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hr : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "speciality_SpecialityId", newName: "SpecialityId");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_speciality_SpecialityId", newName: "IX_SpecialityId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_SpecialityId", newName: "IX_speciality_SpecialityId");
            RenameColumn(table: "dbo.AspNetUsers", name: "SpecialityId", newName: "speciality_SpecialityId");
        }
    }
}
