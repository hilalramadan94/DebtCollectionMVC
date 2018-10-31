using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DebtCollectionMVC.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DebtCollectionMVC.ViewModels
{
    public class RoleMenuViewModel
    {
        public IEnumerable<IdentityRole> IdentityRole { get; set; }
        public SelectList SelectList { get; set; }
        public string SelectedValue { get; set; }
        public string ErrorMessage { get; set; }
    }
}