using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DebtCollectionMVC.Models;
using System.Data.Entity;

namespace DebtCollectionMVC.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var userRoleId = "";
            var roleInDB = _context.Roles.ToList();
            for (int i = 0; i < roleInDB.Count; i++)
                if (User.IsInRole(roleInDB[i].Name))
                {
                    userRoleId = roleInDB[i].Id;
                    break;
                }
            var menuInDB = _context.RoleMenus
                .Where(m => m.RoleId == userRoleId)
                .Include(x => x.Menu).ToList();
            var data = new List<string>();
            foreach (var item in menuInDB)
                data.Add(item.Menu.Name);
            
            this.Session["MenuAllowed"] = data;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}