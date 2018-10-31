﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DebtCollectionMVC.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DebtCollectionMVC.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string PhoneNumber { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public IEnumerable<Department> Department { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string RoleName { get; set; }

        public IEnumerable<IdentityRole> Roles { get; set; }

        public bool IsCollector { get; set; }
    }
}