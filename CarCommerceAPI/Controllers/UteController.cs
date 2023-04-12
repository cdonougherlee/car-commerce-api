using CarCommerceAPI.Interfaces;
using CarCommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarCommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UteController : Controller
    {
        private readonly IUteRepository _uteRepository;
        public UteController(IUteRepository uteRepository)
        {
            _uteRepository = uteRepository;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Ute>))]
        public IActionResult GetUtes()
        {
            var utes = _uteRepository.GetUtes();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(utes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400)]
        public IActionResult GetUte(int id)
        {
            var ute = _uteRepository.GetUte(id);
            if (!_uteRepository.UteExists(id))
                return NotFound();

            return Ok(ute.displayDetails());
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUte([FromBody] Ute uteCreate)
        {
            if (uteCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_uteRepository.CreateUte(uteCreate))
                return StatusCode(500, ModelState);

            return Ok("Successfully Created");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUte(int id, [FromBody] Ute updatedUte)
        {
            if (updatedUte == null)
                return BadRequest(ModelState);

            if (id != updatedUte.Id)
                return BadRequest(ModelState);

            if (!_uteRepository.UteExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_uteRepository.UpdateUte(updatedUte))
                return StatusCode(500, ModelState);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUte(int id)
        {
            if(!_uteRepository.UteExists(id))
                return NotFound();

            var uteToDelete = _uteRepository.GetUte(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_uteRepository.DeleteUte(uteToDelete))
            {
                ModelState.AddModelError("", "Error when deleting ute");
            }

            return NoContent();
        }

    }
 }

