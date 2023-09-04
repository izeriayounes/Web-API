using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EnfantsController : ControllerBase
    {
        private readonly IEnfantRepository _enfantRepository;
        private readonly IMapper _mapper;

        public EnfantsController(IEnfantRepository enfantRepository,
                                IMapper mapper)
        {
            _enfantRepository = enfantRepository;
            _mapper = mapper;
        }

        // GET: api/Enfants
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<EnfantDto>))]
        public IActionResult GetEnfants()
        {
            var enfants = _mapper.Map<List<EnfantDto>>(_enfantRepository.GetEnfants());
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(enfants);
        }

        //Get: api/Enfants/5/Parrains
        [HttpGet("{id}/parrains")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ParrainDto>))]
        public IActionResult GetParrainsByEnfant(int id)
        {
            if (!_enfantRepository.EnfantExists(id))
                return NotFound();

            var parrains = _mapper.Map<List<ParrainDto>>(_enfantRepository.GetParrainsByEnfant(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(parrains);
        }

        // GET: api/Enfants/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(EnfantDto))]
        [ProducesResponseType(400)]
        public IActionResult GetEnfant(int id)
        {
            if (!_enfantRepository.EnfantExists(id))
                return NotFound();

            var enfant = _mapper.Map<EnfantDto>(_enfantRepository.GetEnfant(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(enfant);
        }

        [HttpGet("enfants-with-no-famille")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<EnfantDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetEnfantsWithNoFamille()
        {
            var enfants = _mapper.Map<List<EnfantDto>>(_enfantRepository.GetEnfantsWithNoFamille());

            return Ok(enfants);
        }

        // POST: api/Enfants
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateEnfant(EnfantDto enfantCreate)
        {
            if (enfantCreate == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var enfant = _mapper.Map<Enfant>(enfantCreate);

            if (!_enfantRepository.CreateEnfant(enfant))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Created("/api/enfants/" + enfant.Id, enfant);

        }
        //// PUT: api/Enfants/5
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateEnfant(int id, EnfantDto enfantUpdate)
        {
            if (enfantUpdate == null)
                return BadRequest(ModelState);

            if (enfantUpdate.Id != id)
                return BadRequest(ModelState);

            if (!_enfantRepository.EnfantExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var enfant = _mapper.Map<Enfant>(enfantUpdate);

            if (!_enfantRepository.UpdateEnfant(enfant))
            {
                ModelState.AddModelError("", "something went wrong while updating enfant");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        // DELETE: api/Enfants/5
        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteEnfant(int id)
        {
            if (!_enfantRepository.EnfantExists(id))
                return NotFound();

            var enfantToDelete = _enfantRepository.GetEnfant(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_enfantRepository.DeleteEnfant(enfantToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting enfant");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

    }
}
