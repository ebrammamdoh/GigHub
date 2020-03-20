using AutoMapper;
using GigHub.Models;
using GigHub.Models.DTOs;
using GigHub.Models.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            Mapper.CreateMap<ApplicationUser, UserDTO>();
            Mapper.CreateMap<Genre, GenreDTO>();
            Mapper.CreateMap<Gig, GigDTO>();
            Mapper.CreateMap<Notification, NotificationDTO>();
        }
    }
}