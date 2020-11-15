using SPE.BL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPE.BL.Dtos
{
    public class PermissionDto : IBaseEntityDto
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public int PermissionTypeId { get; set; }
        public DateTime PermissionDate { get; set; }

        public PermissionTypeDto PermissionType { get; set; }
    }
}
