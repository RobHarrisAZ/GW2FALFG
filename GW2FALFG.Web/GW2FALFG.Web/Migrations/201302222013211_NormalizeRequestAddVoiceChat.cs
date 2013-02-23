namespace GW2FALFG.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NormalizeRequestAddVoiceChat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VoiceChats",
                c => new
                    {
                        VoiceChatId = c.Int(nullable: false, identity: true),
                        VoiceChatName = c.String(nullable: false, maxLength: 50),
                        LogoImageUrl = c.String(maxLength: 128),
                        GroupRequest_GroupRequestId = c.Int(),
                    })
                .PrimaryKey(t => t.VoiceChatId)
                .ForeignKey("dbo.GroupRequests", t => t.GroupRequest_GroupRequestId)
                .Index(t => t.GroupRequest_GroupRequestId);
            
            AddColumn("dbo.GroupRequests", "EventId", c => c.Int(nullable: false));
            AddColumn("dbo.GroupRequests", "CharacterClassId", c => c.Int(nullable: false));
            AddForeignKey("dbo.GroupRequests", "EventId", "dbo.Events", "EventId", cascadeDelete: true);
            AddForeignKey("dbo.GroupRequests", "CharacterClassId", "dbo.CharacterClasses", "CharacterClassId", cascadeDelete: true);
            CreateIndex("dbo.GroupRequests", "EventId");
            CreateIndex("dbo.GroupRequests", "CharacterClassId");
            DropColumn("dbo.GroupRequests", "EventName");
            DropColumn("dbo.GroupRequests", "CharacterClassName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GroupRequests", "CharacterClassName", c => c.String(maxLength: 80));
            AddColumn("dbo.GroupRequests", "EventName", c => c.String(nullable: false, maxLength: 128));
            DropIndex("dbo.VoiceChats", new[] { "GroupRequest_GroupRequestId" });
            DropIndex("dbo.GroupRequests", new[] { "CharacterClassId" });
            DropIndex("dbo.GroupRequests", new[] { "EventId" });
            DropForeignKey("dbo.VoiceChats", "GroupRequest_GroupRequestId", "dbo.GroupRequests");
            DropForeignKey("dbo.GroupRequests", "CharacterClassId", "dbo.CharacterClasses");
            DropForeignKey("dbo.GroupRequests", "EventId", "dbo.Events");
            DropColumn("dbo.GroupRequests", "CharacterClassId");
            DropColumn("dbo.GroupRequests", "EventId");
            DropTable("dbo.VoiceChats");
        }
    }
}
