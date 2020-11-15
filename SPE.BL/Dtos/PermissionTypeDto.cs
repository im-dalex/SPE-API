using SPE.BL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

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

        public ICollection<PermissionDto> Permission { get; set; }

    }
}
