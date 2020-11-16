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
    public class PermissionController : BasiApiController<Permission, PermissionDto>
    {
        public PermissionController(IPermissionRepository context, IMapper mapper)
            :base(context, mapper)
        {

        }
    }
}
