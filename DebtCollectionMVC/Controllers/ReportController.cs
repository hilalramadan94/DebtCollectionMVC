using DebtCollectionMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DebtCollectionMVC.Models;

namespace DebtCollectionMVC.Controllers
{
    public class ReportController : Controller
    {
        //context
        private ApplicationDbContext _context;

        //ctor
        public ReportController()
        {
            _context = new ApplicationDbContext();
        }

        //dispose
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TaskManagement()
        {
            var viewModel = new ReportViewModel()
            {
                DateTimeStart = DateTime.Today,
                DateTimeEnd = DateTime.Today
            };

            return View(viewModel);
        }

        public ActionResult SetorAO()
        {
            return View();
        }

        public ActionResult HistoriPenagihan()
        {
            return View();
        }
    }
}