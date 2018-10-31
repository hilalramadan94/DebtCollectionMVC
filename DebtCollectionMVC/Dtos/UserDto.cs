using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DebtCollectionMVC.Models;

namespace DebtCollectionMVC.Dtos
{
    public class UserDto
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public bool? IsActive { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        
        public int DepartmentId { get; set; }

        public DepartmentDto Department { get; set; }

        public string Id { get; set; }

        public string UserName { get; set; }
    }
}
