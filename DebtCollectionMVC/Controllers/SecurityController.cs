using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using DebtCollectionMVC.Models;
using DebtCollectionMVC.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace DebtCollectionMVC.Controllers
{
    //[Authorize(Roles = RoleName.CanManageMovies)]
    public class SecurityController : Controller
    {
        private ApplicationDbContext _context;

        //Ctor
        public SecurityController()
        {
            _context = new ApplicationDbContext();
        }

        //Dispose
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Security
        public ActionResult Index()
        {
            return View("User");
        }

        public ActionResult UserList()
        {
            return View();
        }

        public PartialViewResult UserListForm()
        {
            var viewModel = new RegisterViewModel()
            {
                IsCollector = false,
                Department = _context.Departments.ToList(),
                Roles = _context.Roles
                        .Where(x => x.Id != "99" && x.Id != "00")
                        .ToList()
            };

            return PartialView(viewModel);
        }

        public ActionResult RoleAkses(string roleId, string errorMessage)
        {
            //Get
            var rolesInDB = _context.Roles
                    .Where(x => x.Id != "99" && x .Id != "00") //Except Collector (99) and Admin (00)
                    .ToList();

            var viewModel = new RoleMenuViewModel
            {
                SelectList = new SelectList(rolesInDB.OrderBy(m => m.Id), "Id", "Name", roleId),
                IdentityRole = _context.Roles.ToList(),
                
            };

            if (errorMessage == "exist")
                    viewModel.ErrorMessage = "Menu untuk role yang dipilih sudah ada";

            return View(viewModel);
        }

        public PartialViewResult RoleAksesForm(string id)
        {
            var roleMenu = new RoleMenu
            {
                RoleId = id
            };

            var viewModel  = new RoleMenuFormViewModel()
            {
                RoleMenu = roleMenu,
                Menus = _context.Menus.ToList(),
                IdentityRole = _context.Roles.SingleOrDefault(m => m.Id == id)
            };

            return PartialView(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewRole(string roleName)
        {
            var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            await roleManager.CreateAsync(new IdentityRole(roleName));

            return RedirectToAction("RoleAkses", "Security");
        }

        [HttpPost]
        public ActionResult DeleteRole(string roleName)
        {
            var thisRole = _context.Roles
                .Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase))
                .FirstOrDefault();

            _context.Roles.Remove(thisRole);
            _context.SaveChanges();
            return RedirectToAction("RoleAkses","Security");
        }

        [HttpPost]
        public ActionResult CreateRoleMenu(RoleMenu roleMenu)
        {
            //if model not valid
            if (!ModelState.IsValid)
            {
                return RedirectToAction("RoleAkses", "Security");
            }

            //if exist
            var roleMenuInDB = _context.RoleMenus
                .SingleOrDefault(m => (m.RoleId == roleMenu.RoleId) && (m.MenuId == roleMenu.MenuId));
            if (roleMenuInDB == null)
            {
                //add context and save
                _context.RoleMenus.Add(roleMenu);
                _context.SaveChanges();

                return RedirectToAction("RoleAkses", "Security", new { roleId = roleMenu.RoleId });
            }
            else
            {
                var strMessage = "exist";
                return RedirectToAction("RoleAkses", "Security", new {errorMessage = strMessage});
            }
        }
    }
}