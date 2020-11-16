using SPE.DataModel.Abstract;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public ICollection<Permission> Permission { get; set; }
    }
}
