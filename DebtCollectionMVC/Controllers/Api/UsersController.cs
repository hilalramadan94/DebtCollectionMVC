using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity; //digunakan untuk include
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DebtCollectionMVC.Dtos;
using DebtCollectionMVC.Models;
using System.Web.Mvc;

namespace DebtCollectionMVC.Controllers.Api
{
    public class UsersController : ApiController
    {
        //Context
        private ApplicationDbContext _context;

        //Ctor
        public UsersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/users
        public IHttpActionResult GetUsers()
        {
            var role = _context.Roles
                .Where(x => x.Id != "99" && x.Id != "00")
                .FirstOrDefault();
            var thisUser = User.Identity.Name;

            //Get
            if (role != null)
            {
                var User = _context.Users
                    .Include(c => c.Department)
                    .Where(x => (x.UserName != thisUser) && ((x.Roles.Count == 0) ||                             //Role IsNull
                                x.Roles.Select(y => y.RoleId).Contains(role.Id)))    //Role Not Collector
                    .ToList()
                    .Select(Mapper.Map<ApplicationUser, UserDto>);

                return Ok(User);
            }
            else
            {
                var User = _context.Users
                    .Include(c => c.Department)
                    .Where(x => (x.UserName != thisUser) && (x.Roles.Count == 0))
                    .ToList()
                    .Select(Mapper.Map<ApplicationUser, UserDto>);

                return Ok(User);
            }
        }

        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public IHttpActionResult Aktivasi(string Id)
        {
            //get customer
            var UserInDB = _context.Users.SingleOrDefault(c => c.Id == Id);
            //if customer not found
            if (UserInDB == null)
                return BadRequest();
            //update customer in db
            if (UserInDB.IsActive == true)
                UserInDB.IsActive = false; //ChangeStatus to Active
            else
                UserInDB.IsActive = true; //ChangeStatus to Blocked

            //save context
            _context.SaveChanges();

            return Ok();
        }
    }
}
