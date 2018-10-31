using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using DebtCollectionMVC.Dtos;
using DebtCollectionMVC.Models;
using DebtCollectionMVC.ViewModels;

namespace DebtCollectionMVC.Controllers.Api
{
    public class HomeVisitsController : ApiController
    {
        private ApplicationDbContext _context;

        public HomeVisitsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult GetVisistedTasks(bool? confirmation, int? debtId)
        {
            var task = _context.HomeVisits
                .Include(x => x.ApplicationUser)
                .Include(x => x.Debt)
                .Include(x => x.Debt.Area)
                .Where(x => x.IsVisited == true)
                .ToList()
                .Select(Mapper.Map<HomeVisit, HomeVisitDto>);

            if (confirmation == true)
                task = task.Where(x => x.Confirmation == true);
            else if (confirmation == false)
                task = task.Where(x => x.Confirmation == false || x.Confirmation == null);

            if (debtId != null)
                task = task.Where(x => x.DebtId == debtId);

            return Ok(task);
        }

        [HttpPost]
        public IHttpActionResult AssignTask(SetorAOViewModel model)
        {
            var homeVisitsinDB = _context.HomeVisits
                .Where(x => model.listHomeVisitId.Any(y => y == x.Id))
                .ToList();

            //save context
            for (int i = 0; i < homeVisitsinDB.Count; i++)
                homeVisitsinDB[i].Confirmation = true;

            _context.SaveChanges();

            return Ok();
        }
    }
}
