using CarCommerceAPI.Interfaces;
using CarCommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarCommerceAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VanController : Controller
    {
        private readonly IVanRepository _vanRepository;
        public VanController(IVanRepository vanRepository)
        {
            _vanRepository = vanRepository;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Van>))]
        public IActionResult GetVans()
        {
            var vans = _vanRepository.GetVans();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(vans);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400)]
        public IActionResult GetVan(int id)
        {
            var van = _vanRepository.GetVan(id);
            if (!_vanRepository.VanExists(id))
                return NotFound();

            return Ok(van.displayDetails());
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateVan([FromBody] Van vanCreate)
        {
            if (vanCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_vanRepository.CreateVan(vanCreate))
                return StatusCode(500, ModelState);

            return Ok("Successfully Created");
        }

        [HttpPut("updateprice/{id}")]
        [ProducesResponseType(204)]
        public IActionResult UpdatePrice(int id, [FromBody] int price)
        {
            Van van = _vanRepository.GetVan(id);
            if (van == null)
                return BadRequest(ModelState);

            if (id != van.Id)
                return BadRequest(ModelState);

            if (!_vanRepository.VanExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_vanRepository.UpdatePrice(van, price))
                return StatusCode(500, ModelState);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteVan(int id)
        {
            if (!_vanRepository.VanExists(id))
                return NotFound();

            var vanToDelete = _vanRepository.GetVan(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_vanRepository.DeleteVan(vanToDelete))
            {
                ModelState.AddModelError("", "Error when deleting Van");
            }

            return NoContent();
        }

    }
    
}
