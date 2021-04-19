using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRental.DAL;
using CarRental.DAL.DBO;
using CarRental.DAL.Repositories;

namespace CarRental.Controllers //SRP and DRY applied for API Cars controller//
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IRepository<Car> _carRepo;

        public CarsController(IRepository<Car> carRepo)
        {
            _carRepo = carRepo;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            return await _carRepo.GetAllAsync();
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _carRepo.GetByIdAsync(id);

            if (car == null)
            {
                return NotFound();
            }
            return car;
        }

        // PUT: api/Cars/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _carRepo.UpdateAsync(car);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cars
        [HttpPost]
        public async Task<ActionResult> PostCar(Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _carRepo.CreateAsync(car);
            
            return CreatedAtAction("GetCar", new { id = car.Id }, car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
           
            var car = await _carRepo.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            await _carRepo.DeleteAsync(id);
            
            return NoContent();
        }

        private bool CarExists(int id)
        {
            return _carRepo.Exists(id);
        }
    }
}