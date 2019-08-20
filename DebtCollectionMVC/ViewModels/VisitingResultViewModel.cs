using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DebtCollectionMVC.ViewModels
{
    public class VisitingResultViewModel
    {
        public int Id { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsDebtorFound { get; set; }
        public string Reason { get; set; }
        public decimal? AmountPaid { get; set; }
        public DateTime PromisedDate { get; set; }
        public decimal GeoLat { get; set; }
        public decimal GeoLng { get; set; }
    }
}