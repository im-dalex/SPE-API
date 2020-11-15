using AutoMapper;
using SPE.BL.Dtos;
using SPE.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPE.BL.Mappers
{
    public class SPEMappingProfile : Profile
    {
        public SPEMappingProfile()
        {
            CreateMap<Permission, PermissionDto>().ReverseMap();
            CreateMap<PermissionType, PermissionTypeDto>().ReverseMap();
        }
    }
}
