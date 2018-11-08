using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace DebtCollectionMVC.Models
{
    public class HomeVisit
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Id Tagihan")]
        public int DebtId { get; set; }

        public Debt Debt { get; set; }

        [Required]
        [Display(Name = "Tagihan Pokok")]
        public decimal PrincipalBill { get; set; }

        [Required]
        [Display(Name = "Margin")]
        public decimal Margin { get; set; }

        [Required]
        public decimal Fee { get; set; }

        [Required]
        [Display(Name = "Denda")]
        public decimal Penalty { get; set; }

        [Required]
        [Display(Name = "Jatuh Tempo")]
        public DateTime DueDate { get; set; }

        [Display(Name = "Tanggal Kunjungan")]
        public DateTime? HomeVisitDate { get; set; }

        [Display(Name = "Collector")]
        public string ApplicationUserId { get; set; }

        public ApplicationUser  ApplicationUser { get; set; }

        [Display(Name = "Alasan")]
        [StringLength(255)]
        public string Reason { get; set; }

        [Display(Name = "Jumlah Bayar")]
        public decimal? AmountPaid { get; set; }

        [Display(Name = "Tanggal Janji")]
        public DateTime? PromisedDate { get; set; }

        [Required]
        [Display(Name = "Status Kunjungan")]
        public bool IsVisited { get; set; }

        [Display(Name = "URL Foto")]
        public string UrlPhoto { get; set; }

        [Display(Name = "Confirmation")]
        public bool Confirmation { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.######}")]
        public decimal? GeoLat { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.######}")]
        public decimal? GeoLng { get; set; }
    }
}
