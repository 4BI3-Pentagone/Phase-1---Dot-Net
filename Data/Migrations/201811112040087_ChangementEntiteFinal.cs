namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangementEntiteFinal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ComID = c.Int(nullable: false, identity: true),
                        CommentMsg = c.String(),
                        CommentedDate = c.DateTime(),
                        PostID = c.Int(),
                        UserID = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ComID)
                .ForeignKey("dbo.Posts", t => t.PostID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.PostID)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        Titre = c.String(),
                        Message = c.String(),
                        PostedDate = c.DateTime(),
                        categoriePost_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.CategoriePosts", t => t.categoriePost_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.categoriePost_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.CategoriePosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubComments",
                c => new
                    {
                        SubComID = c.Int(nullable: false, identity: true),
                        CommentMsg = c.String(),
                        CommentedDate = c.DateTime(),
                        ComID = c.Int(),
                        UserID = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SubComID)
                .ForeignKey("dbo.Comments", t => t.ComID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.ComID)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubComments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SubComments", "ComID", "dbo.Comments");
            DropForeignKey("dbo.Posts", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "PostID", "dbo.Posts");
            DropForeignKey("dbo.Posts", "categoriePost_Id", "dbo.CategoriePosts");
            DropIndex("dbo.SubComments", new[] { "User_Id" });
            DropIndex("dbo.SubComments", new[] { "ComID" });
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropIndex("dbo.Posts", new[] { "categoriePost_Id" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "PostID" });
            DropTable("dbo.SubComments");
            DropTable("dbo.CategoriePosts");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}
