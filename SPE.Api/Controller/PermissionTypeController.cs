using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPE.Api.Controller.Base;
using SPE.BL.Abstract.IRepositories;
using SPE.BL.Dtos;
using SPE.DataModel.Entities;

namespace SPE.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypeController : BasiApiController<PermissionType, PermissionTypeDto>
    {
        public PermissionTypeController(IPermissionTypeRepository context, IMapper mapper)
            :base(context, mapper)
        {

        }
    }
}
