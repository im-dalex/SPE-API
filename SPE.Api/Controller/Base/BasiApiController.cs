using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPE.BL.Abstract;
using SPE.DataModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPE.Api.Controller.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BasiApiController<T, TD> : ControllerBase where T: class, IBaseEntity, new()
                                                        where TD : class, IBaseEntityDto, new()
    {
        protected readonly IBaseRepository<T> _db;
        protected readonly IMapper _mapper;
        public BasiApiController(IBaseRepository<T> db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<IEnumerable<T>> Get()
        {
            return await _db.GetAll();
        }

        [HttpGet("{key}")]
        public virtual async Task<ActionResult<T>> Get(int key)
        {
            if (key < 1) return BadRequest();

            var result = await _db.GetById(key);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public virtual async Task<ActionResult<T>> Post(T value)
        {
            if (value == null) return BadRequest();

            await _db.Add(value);
            var result = await _db.SaveAsync();
            if (!result.Success) return BadRequest(value);

            return Ok(value);
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<T>> Put(int id, [FromBody] T entity)
        {
            if (entity == null || id < 1)
            {
                return BadRequest();
            }

            var find = _db.GetById(id);
            if (find == null) return NotFound();

            _db.Update(entity);
            var result = await _db.SaveAsync();
            if (!result.Success) return BadRequest(entity);

            return NoContent();

        }
    }
}
