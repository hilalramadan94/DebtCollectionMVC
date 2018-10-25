using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;

namespace DebtCollectionMVC.ViewModels
{
    public class TaskManagementViewModel
    {
        public IEnumerable<IdentityUser> IdentityUser { get; set; }
        public SelectList SelectList { get; set; }
        public int[] listTaskId { get; set; }
        public string CollectorId { get; set; }
    }
}