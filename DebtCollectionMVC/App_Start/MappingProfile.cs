using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DebtCollectionMVC.Models;
using DebtCollectionMVC.Dtos;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DebtCollectionMVC.App_Start
{
    //Class buatan untuk Api (Dto)
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Security
            Mapper.CreateMap<ApplicationUser, UserDto>();
            Mapper.CreateMap<Area, AreaDto>();
            Mapper.CreateMap<Department, DepartmentDto>();
            Mapper.CreateMap<HomeVisit, HomeVisitDto>();
            Mapper.CreateMap<HomeVisit, TaskDto>();
            Mapper.CreateMap<Debt, DebtDto>();
            
        }
    }
}