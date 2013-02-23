using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;


namespace GW2FALFG.Web.Models
{
    public class VoiceChat
    {
        [Required]
        public int VoiceChatId { get; set; }
        [Required]
        [StringLength(50)]
        public string VoiceChatName { get; set; }
        [StringLength(128)]
        public string LogoImageUrl { get; set; }
        [JsonIgnore]
        public virtual ICollection<GroupVoiceChat> GroupVoiceChats { get; set; }
    }
}