using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DebtCollectionMVC.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [StringLength(255)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [StringLength(20)]
        [Display(Name = "Telephone")]
        public string Telephone { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Website { get; set; }
    }
}