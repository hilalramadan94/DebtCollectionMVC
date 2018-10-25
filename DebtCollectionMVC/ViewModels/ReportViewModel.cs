using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DebtCollectionMVC.ViewModels
{
    public class ReportViewModel
    {
        [Display(Name = "Tanggal Mulai")]
        public DateTime DateTimeStart { get; set; }

        [Display(Name = "Tanggal Akhir")]
        public DateTime DateTimeEnd { get; set; }
    }
}