using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DebtCollectionMVC.Models;
using DebtCollectionMVC.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace DebtCollectionMVC.Controllers.Api
{
    public class RolesController : ApiController
    {
        //Context
        private ApplicationDbContext _context;
        
        //Ctor
        public RolesController()
        {
            _context = new ApplicationDbContext();
        }

        //Dispose
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //GET /api/roles/1
        public IHttpActionResult GetRolesMenu(string id)
        {
            //get 
            var menu = _context.RoleMenus
                .Where(m => m.RoleId == id)
                .Include(x => x.Menu);

            //return
            return Ok(menu);
        }

        [HttpDelete]
        public IHttpActionResult DeleteRoleMenu(int id)
        {
            //get movie
            var roleMenuInDB = _context.RoleMenus.SingleOrDefault(m => m.Id == id);
            //if not found
            if (roleMenuInDB == null)
                return NotFound();
            //remove from context
            _context.RoleMenus.Remove(roleMenuInDB);
            //save context
            _context.SaveChanges();
            //return
            return Ok();
        }

        //[HttpPost]
        //public IHttpActionResult CreateRoleMenu(RoleMenu roleMenu)
        //{
        //    //if model not valid
        //    if (!ModelState.IsValid)
        //        //return RedirectToAction("RoleAkses", "Security");
        //        return NotFound();
        //    //if exist
        //    var roleMenuInDB = _context.RoleMenus
        //        .SingleOrDefault(m => (m.RoleName == roleMenu.RoleName) && (m.MenuId == roleMenu.MenuId));
        //    if (roleMenuInDB == null)
        //    {
        //        //add context and save
        //        _context.RoleMenus.Add(roleMenu);
        //        _context.SaveChanges();
        //    }

        //    return Ok();
        //    //return RedirectToAction("RoleAkses", "Security", new { roleId = roleMenu.RoleName });
        //}
    }
}
