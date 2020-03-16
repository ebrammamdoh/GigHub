﻿using GigHub.Models.Notification;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GigHub.Models
{
    public class Gig
    {
        public Gig()
        {
            Attendances = new Collection<Attendance>();
            DateTime = DateTime.Now;
        }
        public int Id { get; set; }

        public ApplicationUser Artist { get; set; }

        [Required]
        public string ArtistId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }
        public bool IsCanceled { get; private set; }
        public ICollection<Attendance> Attendances { get; set; }
        public void Cancel()
        {
            IsCanceled = true;
            this.Attendances.Select(t => t.Attendee).ToList().ForEach(user =>
            {
                user.Notify(new Notification.Notification(NotificationType.GigCanceled, this));
            });
        }
    }
}