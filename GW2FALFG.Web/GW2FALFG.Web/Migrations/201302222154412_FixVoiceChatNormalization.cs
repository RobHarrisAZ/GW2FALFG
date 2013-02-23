namespace GW2FALFG.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixVoiceChatNormalization : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VoiceChatGroupRequests", "VoiceChat_VoiceChatId", "dbo.VoiceChats");
            DropForeignKey("dbo.VoiceChatGroupRequests", "GroupRequest_GroupRequestId", "dbo.GroupRequests");
            DropIndex("dbo.VoiceChatGroupRequests", new[] { "VoiceChat_VoiceChatId" });
            DropIndex("dbo.VoiceChatGroupRequests", new[] { "GroupRequest_GroupRequestId" });
            CreateTable(
                "dbo.GroupVoiceChats",
                c => new
                    {
                        GroupVoiceChatId = c.Int(nullable: false, identity: true),
                        GroupRequestId = c.Int(nullable: false),
                        VoiceChatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupVoiceChatId)
                .ForeignKey("dbo.GroupRequests", t => t.GroupRequestId, cascadeDelete: true)
                .ForeignKey("dbo.VoiceChats", t => t.VoiceChatId, cascadeDelete: true)
                .Index(t => t.GroupRequestId)
                .Index(t => t.VoiceChatId);
            
            DropTable("dbo.VoiceChatGroupRequests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VoiceChatGroupRequests",
                c => new
                    {
                        VoiceChat_VoiceChatId = c.Int(nullable: false),
                        GroupRequest_GroupRequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VoiceChat_VoiceChatId, t.GroupRequest_GroupRequestId });
            
            DropIndex("dbo.GroupVoiceChats", new[] { "VoiceChatId" });
            DropIndex("dbo.GroupVoiceChats", new[] { "GroupRequestId" });
            DropForeignKey("dbo.GroupVoiceChats", "VoiceChatId", "dbo.VoiceChats");
            DropForeignKey("dbo.GroupVoiceChats", "GroupRequestId", "dbo.GroupRequests");
            DropTable("dbo.GroupVoiceChats");
            CreateIndex("dbo.VoiceChatGroupRequests", "GroupRequest_GroupRequestId");
            CreateIndex("dbo.VoiceChatGroupRequests", "VoiceChat_VoiceChatId");
            AddForeignKey("dbo.VoiceChatGroupRequests", "GroupRequest_GroupRequestId", "dbo.GroupRequests", "GroupRequestId", cascadeDelete: true);
            AddForeignKey("dbo.VoiceChatGroupRequests", "VoiceChat_VoiceChatId", "dbo.VoiceChats", "VoiceChatId", cascadeDelete: true);
        }
    }
}
