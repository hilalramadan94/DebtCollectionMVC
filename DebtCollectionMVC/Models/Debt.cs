using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DebtCollectionMVC.Models
{
    public class Debt
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Id Perusahaan")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [StringLength(255)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [StringLength(20)]
        [Display(Name = "Telephone")]
        public string Telephone { get; set; }

        [Required]
        [Display(Name = "Id Area")]
        public int AreaId { get; set; }

        public Area Area { get; set; }

        [Required]
        [Display(Name = "Tanggal Bergabung")]
        public DateTime JoinDate { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }
    }
}
