﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GW2FALFG.Web.Models;

namespace GW2FALFG.Web.Data
{
    public class GroupRequestContextInitializer : DropCreateDatabaseIfModelChanges<GroupRequestContext>
    {
        protected override void Seed(GroupRequestContext context)
        {
            var languageId = context.Languages.Add(new Language
            {
                LanguagePreference = "English"
            });
            context.Languages.Add(new Language
            {
                LanguagePreference = "Spanish"
            });
            context.Languages.Add(new Language
            {
                LanguagePreference = "French"
            });
            context.Languages.Add(new Language
            {
                LanguagePreference = "German"
            });
            context.SaveChanges();

            var eventId = context.Events.Add(new Event
            {
                EventName = "Ascalonian Catacombs (Explorable)"
            });
            context.Events.Add(new Event
            {
                EventName = "Ascalonian Catacombs (Story)"
            });
            context.Events.Add(new Event
            {
                EventName = "Caudecus' Manor (Explorable)"
            });
            context.Events.Add(new Event
            {
                EventName = "Caudecus' Manor (Story)"
            });
            context.Events.Add(new Event
            {
                EventName = "Citadel of Flame (Explorable)"
            });
            context.Events.Add(new Event
            {
                EventName = "Citadel of Flame (Story)"
            });
            context.Events.Add(new Event
            {
                EventName = "Crucible of Eternity (Explorable)"
            });
            context.Events.Add(new Event
            {
                EventName = "Crucible of Eternity (Story)"
            });
            context.Events.Add(new Event
            {
                EventName = "Fractals of the Mists"
            });
            context.Events.Add(new Event
            {
                EventName = "Honor of the Waves (Explorable)"
            });
            context.Events.Add(new Event
            {
                EventName = "Honor of the Waves (Story)"
            });
            context.Events.Add(new Event
            {
                EventName = "Other -> Use Comments"
            });
            context.Events.Add(new Event
            {
                EventName = "Sorrows Embrace (Explorable)"
            });
            context.Events.Add(new Event
            {
                EventName = "Sorrows Embrace (Story)"
            });
            context.Events.Add(new Event
            {
                EventName = "The Ruined City of Arah (Explorable)"
            });
            context.Events.Add(new Event
            {
                EventName = "The Ruined City of Arah (Story)"
            });
            context.Events.Add(new Event
            {
                EventName = "tPVP (Free)"
            });
            context.Events.Add(new Event
            {
                EventName = "tPVP (Paid)"
            });
            context.Events.Add(new Event
            {
                EventName = "Twilight Arbor (Explorable)"
            });
            context.Events.Add(new Event
            {
                EventName = "Twilight Arbor (Story)"
            });
            context.SaveChanges();

            context.GroupRequests.Add(new GroupRequest
            {
                AgonyResistRequired = 0,
                Description = "Just a test group request",
                EventName = "Citadel of Flame (Explorable)",
                ExperiencedOnlyFl = false,
                FullRunFl = false,
                LanguagePreference = null,
                Level = 80,
                LookingForNumber = 2,
                NewToDungeonFl = false,
                SpeedRunFl = true,
                UserGuid = new System.Guid().ToString(),
                PlayerName = "Hellsbain Minion"
            });
            context.SaveChanges();
        }
    }
}