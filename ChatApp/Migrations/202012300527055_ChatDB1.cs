namespace ChatApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChatDB1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Replies", "UserId", "dbo.Users");
            DropIndex("dbo.Replies", new[] { "UserId" });
            AlterColumn("dbo.Replies", "UserId", c => c.Int());
            CreateIndex("dbo.Replies", "UserId");
            AddForeignKey("dbo.Replies", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replies", "UserId", "dbo.Users");
            DropIndex("dbo.Replies", new[] { "UserId" });
            AlterColumn("dbo.Replies", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Replies", "UserId");
            AddForeignKey("dbo.Replies", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
