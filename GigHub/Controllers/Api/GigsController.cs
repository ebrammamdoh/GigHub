using GigHub.Models;
using GigHub.Models.Notification;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        private ApplicationDbContext _context;
        public GigsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _context.Gigs.FirstOrDefault(g => g.Id == id && g.ArtistId == userId);
            if (gig.IsCanceled)
                return NotFound();
            gig.IsCanceled = true;
            var notication = new Notification
            {
                DateTime = DateTime.Now,
                Gig = gig,
                NotificationType = NotificationType.GigCanceled,
                OriginalDateTime = gig.DateTime,
                OriginalVenue = gig.Venue
            };
            _context.Notifications.Add(notication);
            var attendee = _context.Attendances.Where(t => t.GigId == gig.Id).Select(t => t.Attendee).ToList();
            attendee.ForEach(user =>
               {
                   var userNotification = new UserNotification
                   {
                       Notification = notication,
                       User = user
                   };
                   _context.UserNotifications.Add(userNotification);
               });


            _context.SaveChanges();

            return Ok();
        }
    }
}
