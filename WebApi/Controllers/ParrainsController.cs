using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Dto;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParrainsController : ControllerBase
    {
        private readonly IParrainRepository _parrainRepository;
        private readonly IMapper _mapper;

        public ParrainsController(IParrainRepository parrainRepository, IMapper mapper)
        {
            _parrainRepository = parrainRepository;
            _mapper = mapper;
        }

        // GET: api/Parrains
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ParrainDto>))]
        public IActionResult GetParrains()
        {
            var parrains = _mapper.Map<List<ParrainDto>>(_parrainRepository.GetParrains());
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(parrains);
        }

        // Get: api/Parrains/5/Enfants
        [HttpGet("{id}/enfants")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<EnfantDto>))]
        public IActionResult GetEnfantsByParrain(int id)
        {
            if (!_parrainRepository.ParrainExists(id))
                return NotFound();

            var enfants = _mapper.Map<List<EnfantDto>>(_parrainRepository.GetEnfantsByParrain(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(enfants);
        }

        // GET: api/Parrains/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ParrainDto))]
        [ProducesResponseType(400)]
        public IActionResult GetParrain(int id)
        {
            if (!_parrainRepository.ParrainExists(id))
                return NotFound();

            var parrain = _mapper.Map<ParrainDto>(_parrainRepository.GetParrain(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(parrain);
        }

        // POST: api/Parrains
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateParrain( ParrainDto parrainCreate)
        {
            if (parrainCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var parrain = _mapper.Map<Parrain>(parrainCreate);

            if (!_parrainRepository.CreateParrain(parrain))
            {
                ModelState.AddModelError("", "something went wrong while saving ");
                return StatusCode(500, ModelState);
            }

            return CreatedAtAction("CreateParrain", new { id = parrain.Id }, parrain);

        }


        // PUT: api/Parrains/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateParrain(int id, ParrainDto parrainUpdate)
        {
            if (parrainUpdate == null)
                return BadRequest(ModelState);

            if (parrainUpdate.Id != id)
                return BadRequest(ModelState);

            if (!_parrainRepository.ParrainExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var parrain = _mapper.Map<Parrain>(parrainUpdate);

            if (!_parrainRepository.UpdateParrain(parrain))
            {
                ModelState.AddModelError("", "something went wrong while updating parrain");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        // DELETE: api/Parrains/5
        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteParrain(int id)
        {
            if (!_parrainRepository.ParrainExists(id))
                return NotFound();

            var parrainToDelete = _parrainRepository.GetParrain(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_parrainRepository.DeleteParrain(parrainToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting parrain");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

    }
}
