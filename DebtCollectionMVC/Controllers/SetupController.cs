using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DebtCollectionMVC.Models;
using DebtCollectionMVC.ViewModels;

namespace DebtCollectionMVC.Controllers
{
    public class SetupController : Controller
    {
        private ApplicationDbContext _context;

        public SetupController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Setup
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TaskManagement()
        {
            var userInDB = _context.Users
                .Where(x => x.Roles.Select(y => y.RoleId).Contains("99") && x.IsActive == true)
                .ToList();

            var viewModel = new TaskManagementViewModel()
            {
                SelectList = new SelectList((userInDB), "Id", "Name", null)
            };

            return View(viewModel);
        }

        public ActionResult Collector()
        {
            return View();
        }

        public ActionResult CollectorForm()
        {
            var viewModel = new RegisterViewModel()
            {
                IsCollector = true,
                Department = _context.Departments.ToList(),
                RoleName = "Collector"
            };

            return PartialView(viewModel);
        }

        public ActionResult Area()
        {
            return View();
        }
    }
}