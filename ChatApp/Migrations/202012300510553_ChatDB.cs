namespace ChatApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChatDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        CreatedOn = c.DateTime(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        CreatedOn = c.DateTime(),
                        UserId = c.Int(nullable: false),
                        CommentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comments", t => t.CommentId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.CommentId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 8000, unicode: false),
                        ImageUrl = c.String(),
                        CreatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true)
                .Index(t => t.Email, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Replies", "UserId", "dbo.Users");
            DropForeignKey("dbo.Replies", "CommentId", "dbo.Comments");
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.Replies", new[] { "CommentId" });
            DropIndex("dbo.Replies", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Replies");
            DropTable("dbo.Comments");
        }
    }
}
