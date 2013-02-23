using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GW2FALFG.Web.Models
{
    public class GroupRequest
    {
        [Required]
        public int GroupRequestId { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [Required]
        public int EventId { get; set; }
        public int? Level { get; set; }
        [Required]
        [StringLength(64)]
        public string PlayerName { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        [Required]
        [StringLength(40)]
        public string UserGuid { get; set; }
        [Required]
        public int CharacterClassId { get; set; }

        public virtual Event Event { get; set; }
        public virtual CharacterClass CharacterClass { get; set; }
        public virtual ICollection<GroupVoiceChat> GroupVoiceChats { get; set; }
    }
}