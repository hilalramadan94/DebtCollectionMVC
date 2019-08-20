using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using DebtCollectionMVC.Models;
using AutoMapper;
using DebtCollectionMVC.Dtos;
using DebtCollectionMVC.ViewModels;
using System.Web;
using System.Threading.Tasks;

namespace DebtCollectionMVC.Controllers.Api
{
    public class BillsController : ApiController
    {
        private ApplicationDbContext _context;

        public BillsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Mobile : Halaman "Tagihan"
        public IHttpActionResult GetBillDetail(int id)
        {
            var task = _context.HomeVisits
                .Include(x => x.ApplicationUser)
                .Include(x => x.Debt)
                .Include(x => x.Debt.Area)
                .SingleOrDefault(x => x.Id == id);

            return Ok(Mapper.Map<HomeVisit, HomeVisitDto>(task));
        }

        //Mobile : Halaman "Tagihan"
        [HttpPost]
        public IHttpActionResult VisitingResult(VisitingResultViewModel model)
        {
            //Get from DB
            var homeVisitInDB = _context.HomeVisits
                                .SingleOrDefault(x => x.Id == model.Id);

            //update
            homeVisitInDB.IsVisited = true;
            if (model.IsDebtorFound)
            {
                homeVisitInDB.AmountPaid = model.AmountPaid;
                homeVisitInDB.PromisedDate = model.PromisedDate;
            }
            homeVisitInDB.Reason = model.Reason;
            homeVisitInDB.GeoLat = model.GeoLat;
            homeVisitInDB.GeoLng = model.GeoLng;

            //Save context
            _context.SaveChanges();
            
            return Ok("success");
        }
    }
}

