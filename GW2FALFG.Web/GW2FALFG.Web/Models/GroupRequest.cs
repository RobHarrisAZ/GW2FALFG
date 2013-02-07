using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace GW2FALFG.Web.Models
{
    public class GroupRequest
    {
        [Required]
        public int GroupRequestId { get; set; }
        public int? AgonyResistRequired { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [Required]
        [StringLength(128)]
        public string EventName { get; set; }
        [Required]
        public bool FullRunFl { get; set; }
        [Required]
        public bool ExperiencedOnlyFl { get; set; }
        [Required]
        [StringLength(64)]
        public string LanguagePreference { get; set; }
        public int? Level { get; set; }
        [Required]
        public int LookingForNumber { get; set; }
        [Required]
        public bool NewToDungeonFl { get; set; }
        [Required]
        [StringLength(64)]
        public string PlayerName { get; set; }
        [Required]
        public bool SpeedRunFl { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        [Required]
        [StringLength(40)]
        public string UserGuid { get; set; }
    }
}