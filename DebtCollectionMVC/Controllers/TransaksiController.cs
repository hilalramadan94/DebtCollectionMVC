using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DebtCollectionMVC.Models;
using DebtCollectionMVC.ViewModels;

namespace DebtCollectionMVC.Controllers
{
    public class TransaksiController : Controller
    {
        //Context
        private ApplicationDbContext _context;

        //Ctor
        public TransaksiController()
        {
            _context = new ApplicationDbContext();
        }

        //Dispose
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Transaksi
        public ActionResult Index()
        {

            return View("SetorAO");
        }

        public ActionResult SetorAO()
        {
            //return HttpNotFound();
            return View("SetorAO");
        }

        public ActionResult DetailPenagihan(int id)
        {
            var homeVisitinDB = _context.HomeVisits
                .Include(x => x.Debt)
                .Include(x => x.ApplicationUser)
                .SingleOrDefault(x => x.Id == id);

            var viewModel = new DetailPenagihanViewModel
            {
                HomeVisit = homeVisitinDB
            };

            return View(viewModel);
        }

        public ActionResult HistoriPenagihan()
        {
            var viewModel = new ReportViewModel()
            {
                DateTimeStart = DateTime.Today,
                DateTimeEnd = DateTime.Today
            };

            return View(viewModel);
        }
        
    }
}