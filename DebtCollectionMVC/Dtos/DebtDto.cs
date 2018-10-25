using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DebtCollectionMVC.Dtos
{
    public class DebtDto
    {
        public int Id { get; set; }

        public int DepartmentId { get; set; }

        public DepartmentDto Department { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public int AreaId { get; set; }

        public AreaDto Area { get; set; }

        public DateTime JoinDate { get; set; }
    }
}