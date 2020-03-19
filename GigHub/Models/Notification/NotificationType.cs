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
        private Notification(NotificationType  type, Gig gig)
        {
            if (gig == null)
                throw new ArgumentNullException("Gig");
            Gig = gig;
            NotificationType = type;
            OriginalDateTime = gig.DateTime;
            OriginalVenue = gig.Venue;
            DateTime = DateTime.Now;
        }
        public static Notification GigCreate(Gig gig)
        {
            return new Notification(NotificationType.GigCreated, gig);
        }
        public static Notification GigUpdate(Gig gig, DateTime originalDate, string originalVanue)
        {
            var notification = new Notification(NotificationType.GigUpdated, gig);
            notification.OriginalDateTime = originalDate;
            notification.OriginalVenue = originalVanue;
            return notification;
        }
        public static Notification GigCanceled(Gig gig)
        {
            return new Notification(NotificationType.GigCanceled, gig);
        }
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType NotificationType { get; private set; }
        public DateTime OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }
        [Required]
        public int GigId { get; private set; }
        public Gig Gig { get; private set; }
    }

}