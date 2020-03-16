using System;
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
        protected Notification()
        {
        }
        public Notification(NotificationType  type, Gig gig)
        {
            if (gig == null)
                throw new ArgumentNullException("Gig");
            Gig = gig;
            NotificationType = type;
            OriginalDateTime = gig.DateTime;
            OriginalVenue = gig.Venue;
            DateTime = DateTime.Now;
        }
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType NotificationType { get; private set; }
        public DateTime OriginalDateTime { get; set; }
        public string OriginalVenue { get; set; }
        [Required]
        public int GigId { get; private set; }
        public Gig Gig { get; private set; }
    }

}