using CarCommerceAPI.Interfaces;
using CarCommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarCommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;
        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Car>))]
        public IActionResult GetCars()
        {
            var cars = _carRepository.GetCars();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cars);    
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400)]
        public IActionResult GetCar(int id)
        {
            var car = _carRepository.GetCar(id);
            if (!_carRepository.CarExists(id))
                return NotFound();

            return Ok(car.displayDetails());
        }
    }
}
