using AutoMapper;
using GigHub.Models;
using GigHub.Models.DTOs;
using GigHub.Models.Notification;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext _context;
        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<NotificationDTO> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();


            var notifications = _context.UserNotifications.Where(un => un.UserId == userId && !un.IsReaded)
                    .Select(un => un.Notification)
                    //.Select(un => new NotificationDTO { 
                    //    Gig = new GigDTO { 
                    //        DateTime = un.Notification.Gig.DateTime,
                    //        Artist = new UserDTO {
                    //          Id =  un.Notification.Gig.Artist.Id,
                    //          Name = un.Notification.Gig.Artist.Name
                    //        },
                    //        Id = un.Notification.Gig.Id,
                    //        Genre = new GenreDTO
                    //        {
                    //            Id = un.Notification.Gig.Genre.Id,
                    //            Name = un.Notification.Gig.Genre.Name
                    //        },
                    //        IsCanceled = un.Notification.Gig.IsCanceled,
                    //        Venue = un.Notification.Gig.Venue
                    //    },
                    //    NotificationType = un.Notification.NotificationType,
                    //    DateTime = un.Notification.DateTime,
                    //    OriginalDateTime = un.Notification.OriginalDateTime,
                    //    OriginalVenue = un.Notification.OriginalVenue
                    //})
                    .Include(un => un.Gig.Artist)
                    .ToList();


            return notifications.Select(Mapper.Map<Notification, NotificationDTO>);
        }
    }
}
