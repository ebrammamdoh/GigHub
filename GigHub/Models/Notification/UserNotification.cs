﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GigHub.Models.Notification
{
    public class UserNotification
    {
        protected UserNotification()
        {
        }
        public UserNotification(ApplicationUser user, Notification notification)
        {
            if (user == null)
                throw new ArgumentNullException("User");
            if (notification == null)
                throw new ArgumentNullException("Notification");

            User = user;
            Notification = notification;
        }
        [Key]
        [Column(Order = 1)]
        public string UserId { get; private set; }
        public ApplicationUser User { get; private set; }
        [Key]
        [Column(Order = 2)]
        public int NotificationId { get; private set; }
        public Notification Notification { get; private set; }
        public bool IsReaded { get; set; }
    }
}