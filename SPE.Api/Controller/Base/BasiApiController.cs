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
        public virtual async Task<IEnumerable<TD>> Get()
        {
            var models = await _db.GetAll();
            return _mapper.Map<IEnumerable<TD>>(models);
        }

        [HttpGet("{key}")]
        public virtual async Task<ActionResult<TD>> Get(int key)
        {
            if (key < 1) return BadRequest();

            var result = await _db.GetById(key);

            if (result == null) return NotFound();

            return Ok(_mapper.Map<TD>(result));
        }

        [HttpPost]
        public virtual async Task<ActionResult<T>> Post(TD value)
        {
            if (value == null) return BadRequest();

            var model = _mapper.Map<T>(value);
            await _db.Add(model);

            var resultSave = await _db.SaveAsync();
            if (!resultSave.Success) return BadRequest(value);

            return Ok(value);
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<T>> Put(int id, [FromBody] TD dto)
        {
            if (dto == null || id < 1)
            {
                return BadRequest();
            }

            var find = _db.GetById(id);
            if (find == null) return NotFound();

            var model = _mapper.Map<T>(dto);
            _db.Update(model);
            var result = await _db.SaveAsync();
            if (!result.Success) return BadRequest(dto);

            return NoContent();

        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<T>> Delete(int id)
        {
            if (id < 1) return BadRequest();

            var model = await _db.GetById(id);
            if (model == null) return NotFound();

            var result = _db.Delete(model);
            if (!result.Success) return BadRequest(model);

            var resultSave = await _db.SaveAsync();
            if (!resultSave.Success) return BadRequest(model);

            return NoContent();
        }
    }
}
