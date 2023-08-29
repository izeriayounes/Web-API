using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Dto;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParrainagesController : ControllerBase
    {
        private readonly IParrainageRepository _parrainageRepository;
        private readonly IMapper _mapper;

        public ParrainagesController(IParrainageRepository parrainageRepository, IMapper mapper)
        {
            _parrainageRepository = parrainageRepository;
            _mapper = mapper;
        }

        // GET: api/Parrainages
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ParrainageDto>))]
        public IActionResult GetParrainages()
        {
            var parrainages = _mapper.Map<List<ParrainageDto>>(_parrainageRepository.GetParrainages());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(parrainages);
        }

        // GET: api/Parrainages/
        [HttpGet("{EnfantId}/{ParrainId}")]
        [ProducesResponseType(200, Type = typeof(ParrainageDto))]
        [ProducesResponseType(400)]
        public IActionResult GetParrainage(int EnfantId, int ParrainId)
        {
            if (!(_parrainageRepository.ParrainageExists(EnfantId, ParrainId)))
                return NotFound();

            var parrainage = _mapper.Map<ParrainageDto>(_parrainageRepository.GetParrainage(EnfantId, ParrainId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(parrainage);
        }

        // POST: api/Parrainages
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateParrainage(ParrainageDto parrainageCreate)
        {
            if (parrainageCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var parrainage = _mapper.Map<Parrainage>(parrainageCreate);

            if (!_parrainageRepository.CreateParrainage(parrainage))
            {
                ModelState.AddModelError("", "something went wrong while saving ");
                return StatusCode(500, ModelState);
            }

            return CreatedAtAction("CreateParrainage", new { parrainage.EnfantId, parrainage.ParrainId }, parrainage);
        }

        // PUT: api/Parrainages/5
        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateParrainage([FromQuery] int EnfantId, [FromQuery] int ParrainId, ParrainageDto parrainageUpdate)
        {
            if (parrainageUpdate == null)
                return BadRequest(ModelState);

            if (!(parrainageUpdate.EnfantId == EnfantId && parrainageUpdate.ParrainId == ParrainId))
                return BadRequest(ModelState);

            if (!_parrainageRepository.ParrainageExists(EnfantId, ParrainId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var parrainage = _mapper.Map<Parrainage>(parrainageUpdate);

            if (!_parrainageRepository.UpdateParrainage(parrainage))
            {
                ModelState.AddModelError("", "something went wrong while updating famille");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        // DELETE: api/Parrainages/5
        //[HttpDelete("{id}")]
        //public IActionResult DeleteParrainage(int EnfantId, int ParrainId)
        //{
        //    return BadRequest();
        //}

    }
}
