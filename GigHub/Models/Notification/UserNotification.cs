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
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [Key]
        [Column(Order = 2)]
        public int NotificationId { get; set; }
        public Notification Notification { get; set; }
        public bool IsReaded { get; set; }
    }
}