using SPE.DataModel.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPE.DataModel.Entities
{
    public class PermissionType : IBaseEntity
    {
        public PermissionType()
        {
            Permission = new HashSet<Permission>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<Permission> Permission { get; set; }
    }
}
