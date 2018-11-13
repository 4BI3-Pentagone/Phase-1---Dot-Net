namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Forum : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        idQuestion = c.Int(nullable: false, identity: true),
                        Titre = c.String(),
                        question = c.String(),
                        Datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.idQuestion);
            
            CreateTable(
                "dbo.Reponses",
                c => new
                    {
                        IdReponse = c.Int(nullable: false, identity: true),
                        reponse = c.String(),
                    })
                .PrimaryKey(t => t.IdReponse);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reponses");
            DropTable("dbo.Questions");
        }
    }
}
