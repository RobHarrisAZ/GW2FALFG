using System;
using System.ComponentModel.DataAnnotations;

namespace GW2FALFG.Web.Models
{
    public class CharacterClass
    {
        [Required]
        public int CharacterClassId { get; set; }
        [StringLength(80)]
        public string CharacterClassName { get; set; }
    }
}