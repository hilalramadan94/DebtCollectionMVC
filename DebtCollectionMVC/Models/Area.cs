using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace DebtCollectionMVC.Models
{
    public class Area
    {
        public int Id { get; set; }

        [Required]
        [StringLength(5)]
        [Display(Name = "Kode Pos")]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Kelurahan")]
        public string Village { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Kecamatan")]
        public string SubDistrict { get; set; }

        [StringLength(100)]
        [Display(Name = "Kota")]
        public string City { get; set; }

        [StringLength(100)]
        [Display(Name = "Provinsi")]
        public string Province { get; set; }
    }
}