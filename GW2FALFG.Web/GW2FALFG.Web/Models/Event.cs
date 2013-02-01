using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GW2FALFG.Web.Models
{
    public class Event
    {
        [Required]
        public int EventId { get; set; }
        [Required]
        [StringLength(128)]
        public string EventName { get; set; }
    }
}