using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DebtCollectionMVC.Models;
using System.Data.Entity;
using AutoMapper;
using DebtCollectionMVC.Dtos;
using DebtCollectionMVC.ViewModels;
using AutoMapper;

namespace DebtCollectionMVC.Controllers.Api
{
    public class CollectorsController : ApiController
    {
        //Context
        private ApplicationDbContext _context;

        //Ctor
        public CollectorsController()
        {
            _context = new ApplicationDbContext();
        }

        //Dispose
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //GET /api/collector
        public IHttpActionResult GetCollector()
        {
            var role = _context.Roles.Where(r => r.Id == "99").FirstOrDefault();

            var users = _context.Users
                    .Include(x => x.Department)
                    .Where(x => x.Roles.Select(y => y.RoleId).Contains(role.Id))
                    .Select(Mapper.Map<ApplicationUser, UserDto>);

            //return dalam bentuk Dto
            return Ok(users);
        }
    }
}
