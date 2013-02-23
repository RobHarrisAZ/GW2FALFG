using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GW2FALFG.Web.Models;
using System.Data.Entity.Migrations;

namespace GW2FALFG.Web.Data
{
    public class GroupRequestContextInitializer : DropCreateDatabaseIfModelChanges<GroupRequestContext>
    {
        protected override void Seed(GroupRequestContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Languages.AddOrUpdate(l => l.LanguagePreference,
                                          new Language { LanguagePreference = "English" },
                                          new Language { LanguagePreference = "French" },
                                          new Language { LanguagePreference = "German" },
                                          new Language { LanguagePreference = "Spanish" });

            context.Events.AddOrUpdate(e => e.EventName,
                                       new Event { EventName = "Blue Borderlands" },
                                       new Event { EventName = "Green Borderlands" },
                                       new Event { EventName = "Red Borderlands" },
                                       new Event { EventName = "Eternal Battlegrounds" },
                                       new Event { EventName = "Structured PVP -Battle of Kyhlo" },
                                       new Event { EventName = "Structured PVP -Forest of Niflhel" },
                                       new Event { EventName = "Structured PVP -Legacy of the Foefire" },
                                       new Event { EventName = "Structured PVP -Raid on the Capricorn" },
                                       new Event { EventName = "Structured PVP -Spirit Watch" },
                                       new Event { EventName = "Structured PVP -Temple of the Silent Storm" });

            context.CharacterClasses.AddOrUpdate(c => c.CharacterClassName,
                                                 new CharacterClass { CharacterClassName = "Elementalist" },
                                                 new CharacterClass { CharacterClassName = "Engineer" },
                                                 new CharacterClass { CharacterClassName = "Guardian" },
                                                 new CharacterClass { CharacterClassName = "Mesmer" },
                                                 new CharacterClass { CharacterClassName = "Necromancer" },
                                                 new CharacterClass { CharacterClassName = "Ranger" },
                                                 new CharacterClass { CharacterClassName = "Thief" },
                                                 new CharacterClass { CharacterClassName = "Warrior" });

            context.VoiceChats.AddOrUpdate(v => v.VoiceChatName,
                                           new VoiceChat
                                           {
                                               VoiceChatName = "Ventrilo",
                                               LogoImageUrl = "/Content/images/ventrilo.png"
                                           },
                                           new VoiceChat
                                           {
                                               VoiceChatName = "Team Speak",
                                               LogoImageUrl = "/Content/images/teamspeak.png"
                                           },
                                           new VoiceChat
                                           {
                                               VoiceChatName = "Mumble",
                                               LogoImageUrl = "/Content/images/mumble.png"
                                           },
                                           new VoiceChat
                                           {
                                               VoiceChatName = "Raid Call",
                                               LogoImageUrl = "/Content/images/raidcall.png"
                                           },
                                           new VoiceChat
                                           {
                                               VoiceChatName = "Other (Use Description)",
                                               LogoImageUrl = "/Content/images/unknown.png"
                                           });
            context.SaveChanges();
        }
    }
}