using SPE.BL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SPE.BL.Dtos
{
    public class PermissionTypeDto : IBaseEntityDto
    {
        public PermissionTypeDto()
        {
            Permission = new HashSet<PermissionDto>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public ICollection<PermissionDto> Permission { get; set; }

    }
}
