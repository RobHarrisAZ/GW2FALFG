namespace GW2FALFG.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NormalizeWithManyToManyVoiceChat : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VoiceChats", "GroupRequest_GroupRequestId", "dbo.GroupRequests");
            DropIndex("dbo.VoiceChats", new[] { "GroupRequest_GroupRequestId" });
            CreateTable(
                "dbo.VoiceChatGroupRequests",
                c => new
                    {
                        VoiceChat_VoiceChatId = c.Int(nullable: false),
                        GroupRequest_GroupRequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VoiceChat_VoiceChatId, t.GroupRequest_GroupRequestId })
                .ForeignKey("dbo.VoiceChats", t => t.VoiceChat_VoiceChatId, cascadeDelete: true)
                .ForeignKey("dbo.GroupRequests", t => t.GroupRequest_GroupRequestId, cascadeDelete: true)
                .Index(t => t.VoiceChat_VoiceChatId)
                .Index(t => t.GroupRequest_GroupRequestId);
            
            DropColumn("dbo.VoiceChats", "GroupRequest_GroupRequestId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VoiceChats", "GroupRequest_GroupRequestId", c => c.Int());
            DropIndex("dbo.VoiceChatGroupRequests", new[] { "GroupRequest_GroupRequestId" });
            DropIndex("dbo.VoiceChatGroupRequests", new[] { "VoiceChat_VoiceChatId" });
            DropForeignKey("dbo.VoiceChatGroupRequests", "GroupRequest_GroupRequestId", "dbo.GroupRequests");
            DropForeignKey("dbo.VoiceChatGroupRequests", "VoiceChat_VoiceChatId", "dbo.VoiceChats");
            DropTable("dbo.VoiceChatGroupRequests");
            CreateIndex("dbo.VoiceChats", "GroupRequest_GroupRequestId");
            AddForeignKey("dbo.VoiceChats", "GroupRequest_GroupRequestId", "dbo.GroupRequests", "GroupRequestId");
        }
    }
}
