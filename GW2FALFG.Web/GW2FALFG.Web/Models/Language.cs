using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GW2FALFG.Web.Models
{
    public class Language
    {
        [Required]
        public int LanguageId { get; set; }
        [Required][StringLength(64)]
        public string LanguagePreference { get; set; }
    }
}