using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GW2FALFG.Web.Models
{
    public class GroupVoiceChat
    {
        [Required]
        public int GroupVoiceChatId { get; set; }
        [Required]
        public int GroupRequestId { get; set; }
        [Required]
        public int VoiceChatId { get; set; }

        [JsonIgnore]
        public virtual GroupRequest GroupRequest { get; set; }
        public virtual VoiceChat VoiceChat { get; set; }
    }
}