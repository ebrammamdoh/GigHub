using GigHub.Models.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.Models.DTOs
{
    public class NotificationDTO
    {
        public DateTime DateTime { get; set; }
        public NotificationType NotificationType { get; set; }
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalVenue { get; set; }
        public GigDTO Gig { get; set; }
    }
}