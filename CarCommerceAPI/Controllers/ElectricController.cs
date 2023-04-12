using CarCommerceAPI.Interfaces;
using CarCommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarCommerceAPI.Controllers
{
    [Route("electics")]
    [ApiController]
    public class ElectricController : Controller
    {
        private readonly IElectricRepository _electricRepository;
        public ElectricController(IElectricRepository electricRepository)
        {
            _electricRepository = electricRepository;
        }

        [HttpGet("all")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Electric>))]
        public IActionResult GetElectrics()
        {
            var electrics = _electricRepository.GetElectrics();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(electrics);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400)]
        public IActionResult GetElectric(int id)
        {
            var electric = _electricRepository.GetElectric(id);
            if (!_electricRepository.ElectricExists(id))
                return NotFound();

            return Ok(electric.displayDetails());
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateElectric([FromBody] Electric electricCreate)
        {
            if (electricCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_electricRepository.CreateElectric(electricCreate))
                return StatusCode(500, ModelState);

            return Ok("Successfully Created");
        }

        [HttpPut("{id}/updateprice")]
        [ProducesResponseType(204)]
        public IActionResult UpdatePrice(int id, [FromBody] int price)
        {
            Electric electric = _electricRepository.GetElectric(id);   
            if (electric == null)
                return BadRequest(ModelState);

            if (id != electric.Id)
                return BadRequest(ModelState);

            if (!_electricRepository.ElectricExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_electricRepository.UpdatePrice(electric, price))
                return StatusCode(500, ModelState);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteElectric(int id)
        {
            if (!_electricRepository.ElectricExists(id))
                return NotFound();

            var electricToDelete = _electricRepository.GetElectric(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_electricRepository.DeleteElectric(electricToDelete))
            {
                ModelState.AddModelError("", "Error when deleting electric");
            }

            return NoContent();
        }

    }
}
