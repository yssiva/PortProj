using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PortProj.Data;
using PortProj.Models;


namespace PortProj.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Users, UsersModel>().ReverseMap();
            CreateMap<Slot, SlotsModel>().ReverseMap();
        }
    }
}
