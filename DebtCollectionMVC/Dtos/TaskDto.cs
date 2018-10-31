using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace DebtCollectionMVC.Dtos
{
    public class TaskDto
    {
        public int Id { get; set; }

        public int DebtId { get; set; }

        public DebtDto Debt { get; set; }
        
        public decimal PrincipalBill { get; set; }

        public decimal Margin { get; set; }

        public decimal Fee { get; set; }

        public decimal Penalty { get; set; }

        public DateTime DueDate { get; set; }
        
        public string ApplicationUserId { get; set; }

        public UserDto ApplicationUser { get; set; }

        public bool IsVisited { get; set; }
    }
}