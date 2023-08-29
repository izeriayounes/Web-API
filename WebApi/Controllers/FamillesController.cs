using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamillesController : ControllerBase
    {
        private readonly IFamilleRepository _familleRepository;
        private readonly IMapper _mapper;

        public FamillesController(IFamilleRepository fammileRepository, IMapper mapper)
        {
            _familleRepository = fammileRepository;
            _mapper = mapper;
        }

        // GET: api/Familles
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<FamilleDto>))]
        public IActionResult GetFamilles()
        {
            var familles = _mapper.Map<List<FamilleDto>>(_familleRepository.GetFamilles());

            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            return Ok(familles);
        }

        // GET: api/Familles/5/Enfants
        [HttpGet("{id}/enfants")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<EnfantDto>))]
        public IActionResult GetEnfantsByFamille(int id)
        {
            if (!_familleRepository.FamilleExists(id))
                return NotFound();

            var enfants = _mapper.Map<List<EnfantDto>>(_familleRepository.GetEnfantsByFamille(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(enfants);
        }

        // GET: api/Familles/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(FamilleDto))]
        [ProducesResponseType(400)]
        public IActionResult GetFamille(int id) 
        {
            if (!_familleRepository.FamilleExists(id))
                return NotFound();

            var famille = _mapper.Map<FamilleDto>(_familleRepository.GetFamille(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(famille);

        }

        // POST: api/Familles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateFamille([FromQuery] int[] EnfantIds, FamilleDto familleCreate)
        {
            if (familleCreate == null)
                return BadRequest(ModelState);

            var familleByCode = _familleRepository.GetFamilleByCode(familleCreate.CodeFamille);

            if (familleByCode != null)
                return BadRequest("CodeFamille already exists");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var famille = _mapper.Map<Famille>(familleCreate);

            if (!_familleRepository.CreateFamille(EnfantIds, famille))
            {
                ModelState.AddModelError("", "something went wrong while saving ");
                return StatusCode(500, ModelState);
            }

            return CreatedAtAction("CreateFamille", new { id = famille.Id }, famille);
        }

        //// PUT: api/Familles/5
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateFamille(int id, FamilleDto familleUpdate, [FromQuery] int[] EnfantIds)
        {
            if (familleUpdate == null)
                return BadRequest(ModelState);

            if (familleUpdate.Id != id)
                return BadRequest(ModelState);

            if (!_familleRepository.FamilleExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var famille = _mapper.Map<Famille>(familleUpdate);

            if (!_familleRepository.UpdateFamille(EnfantIds, famille))
            {
                ModelState.AddModelError("", "something went wrong while updating famille");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        //// DELETE: api/Familles/5
        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletFamille(int id)
        {
            if (!_familleRepository.FamilleExists(id))
                return NotFound();

            var familleToDelete = _familleRepository.GetFamille(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_familleRepository.DeleteFamille(familleToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting enfant");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
