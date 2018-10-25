using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DebtCollectionMVC.Dtos
{
    public class AreaDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(5)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(100)]
        public string Village { get; set; }

        [Required]
        [StringLength(100)]
        public string SubDistrict { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(100)]
        public string Province { get; set; }
    }
}