﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigHub.Models.Notification
{
    public enum NotificationType
    {
        GigCanceled = 1,
        GigUpdated = 2,
        GigCreated = 3
    }

    public class Notification
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public NotificationType NotificationType { get; set; }
        public DateTime OriginalDateTime { get; set; }
        public string OriginalVenue { get; set; }
        [Required]
        public int GigId { get; set; }
        public Gig Gig { get; set; }
    }

}