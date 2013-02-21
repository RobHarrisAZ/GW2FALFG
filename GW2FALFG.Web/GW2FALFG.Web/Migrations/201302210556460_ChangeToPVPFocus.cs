namespace GW2FALFG.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeToPVPFocus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        LanguagePreference = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.LanguageId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.GroupRequests",
                c => new
                    {
                        GroupRequestId = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 255),
                        EventName = c.String(nullable: false, maxLength: 128),
                        Level = c.Int(),
                        PlayerName = c.String(nullable: false, maxLength: 64),
                        Timestamp = c.DateTime(nullable: false),
                        UserGuid = c.String(nullable: false, maxLength: 40),
                        CharacterClassName = c.String(maxLength: 80),
                    })
                .PrimaryKey(t => t.GroupRequestId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserPassword = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.CharacterClasses",
                c => new
                    {
                        CharacterClassId = c.Int(nullable: false, identity: true),
                        CharacterClassName = c.String(maxLength: 80),
                    })
                .PrimaryKey(t => t.CharacterClassId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CharacterClasses");
            DropTable("dbo.Users");
            DropTable("dbo.GroupRequests");
            DropTable("dbo.Events");
            DropTable("dbo.Languages");
        }
    }
}
