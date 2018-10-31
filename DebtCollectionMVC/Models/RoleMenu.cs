using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DebtCollectionMVC.Models
{
    public class RoleMenu
    {
        public int Id { get; set; }

        [Required]
        public string RoleId { get; set; }

        public IdentityRole IdentityRole { get; set; }

        [Required]
        [Display(Name = "Pilih Menu")]
        public int MenuId { get; set; }

        public Menu Menu { get; set; }
    }
}