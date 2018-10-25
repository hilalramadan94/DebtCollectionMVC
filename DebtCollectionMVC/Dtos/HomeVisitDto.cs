using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DebtCollectionMVC.Dtos
{
    public class HomeVisitDto
    {
        public int Id { get; set; }

        public int DebtId { get; set; }

        public DebtDto Debt { get; set; }

        public decimal PrincipalBill { get; set; }

        public decimal Margin { get; set; }

        public decimal Fee { get; set; }

        public decimal Penalty { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime? HomeVisitDate { get; set; }

        public string ApplicationUserId { get; set; }

        public UserDto ApplicationUser { get; set; }

        public string Reason { get; set; }

        public decimal? AmountPaid { get; set; }

        public DateTime? PromisedDate { get; set; }

        public bool IsVisited { get; set; }

        public string UrlPhoto { get; set; }

        public bool Confirmation { get; set; }

        public decimal? GeoLat { get; set; }

        public decimal? GeoLng { get; set; }
    }
}