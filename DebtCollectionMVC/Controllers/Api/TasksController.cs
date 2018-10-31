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

namespace DebtCollectionMVC.Controllers.Api
{
    public class TasksController : ApiController
    {
        //Context
        private ApplicationDbContext _context;

        //Ctor
        public TasksController()
        {
            _context = new ApplicationDbContext();
        }

        //Dispose
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //GET /api/task
        public IHttpActionResult GetTasks()
        {
            var task = _context.HomeVisits
                .Include(x => x.Debt)
                .Include(x => x.Debt.Area)
                .Include(x => x.ApplicationUser)
                .Where(x => x.IsVisited != true)
                .ToList()
                .Select(Mapper.Map<HomeVisit, TaskDto>);

            //return dalam bentuk Dto
            return Ok(task);
        }

        public IHttpActionResult GetTasksByUsername(string username)
        {
            var userId = _context.Users.SingleOrDefault(x => x.UserName == username);

            var task = _context.HomeVisits
                .Include(x => x.Debt)
                .Include(x => x.Debt.Area)
                .Include(x => x.ApplicationUser)
                .Where(x => x.ApplicationUserId == userId.Id)
                .ToList()
                .Select(Mapper.Map<HomeVisit, TaskDto>);

            //return dalam bentuk Dto
            return Ok(task);
        }

        [HttpPost]
        public IHttpActionResult AssignTask(TaskManagementViewModel model)
        {
            //get user
            var collector = _context.Users
                .Where(x => x.Roles.Select(y => y.RoleId).Contains("99"))
                .SingleOrDefault(c => c.Id == model.CollectorId);
            var taskInDB = _context.HomeVisits
                .Where(x => model.listTaskId.Any(y => y == x.Id))
                .ToList();

            //if user not found
            if (collector == null)
                return BadRequest();

            //update customer in db
            for (int i = 0; i < taskInDB.Count; i++)
                taskInDB[i].ApplicationUserId = collector.Id;
            
            //save context
            _context.SaveChanges();

            return Ok();
        }

    }
}
