﻿using System;
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
        [StringLength(128)]
        public string EventName { get; set; }
        public int? Level { get; set; }
        [Required]
        [StringLength(64)]
        public string PlayerName { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        [Required]
        [StringLength(40)]
        public string UserGuid { get; set; }
        [StringLength(80)]
        public string CharacterClassName { get; set; }
    }
}