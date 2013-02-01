using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GW2FALFG.Web.Models
{
    public class GroupRequest
    {
        public int GroupRequestId { get; set; }
        public string DungeonName { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public bool SpeedRunFl { get; set; }
        public bool ExperiencedOnlyFl { get; set; }
        public bool FullRunFl { get; set; }
        public bool NewToDungeonFl { get; set; }
        public int LookingForNumber { get; set; }
        public string LanguagePreference { get; set; }
        public int AgonyResistRequired { get; set; }
        public string UserGuid { get; set; }
    }
}