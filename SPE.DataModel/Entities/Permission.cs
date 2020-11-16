using SPE.DataModel.Abstract;
using System;

namespace SPE.DataModel.Entities
{
    public class Permission : IBaseEntity
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public int PermissionTypeId { get; set; }
        public DateTime PermissionDate { get; set; }

        public PermissionType PermissionType { get; set; }
    }
}
