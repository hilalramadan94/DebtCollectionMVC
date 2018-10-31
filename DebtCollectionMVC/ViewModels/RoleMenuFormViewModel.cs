using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DebtCollectionMVC.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DebtCollectionMVC.ViewModels
{
    public class RoleMenuFormViewModel
    {
        public RoleMenu RoleMenu { get; set; }
        public IdentityRole IdentityRole { get; set; }
        public IEnumerable<Menu> Menus { get; set; }
    }
}