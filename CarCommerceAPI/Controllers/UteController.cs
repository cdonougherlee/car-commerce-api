using CarCommerceAPI.Interfaces;
using CarCommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarCommerceAPI.Controllers
{
    [Route("utes")]
    [ApiController]
    public class UteController : Controller
    {
        private readonly IUteRepository _uteRepository;
        public UteController(IUteRepository uteRepository)
        {
            _uteRepository = uteRepository;
        }

        [HttpGet("all")]
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

        [HttpPut("{id}/updateprice")]
        [ProducesResponseType(204)]
        public IActionResult UpdatePrice(int id, [FromBody] int price)
        {
            Ute ute = _uteRepository.GetUte(id);
            if (ute == null)
                return BadRequest(ModelState);

            if (id != ute.Id)
                return BadRequest(ModelState);

            if (!_uteRepository.UteExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_uteRepository.UpdatePrice(ute, price))
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

