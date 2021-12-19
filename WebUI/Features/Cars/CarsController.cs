using Domain.Entitties;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebUI.Features.Cars
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }



        //Get list of cars
        [HttpGet]
        public ActionResult<List<Car>> GetCars()
        {
            var carList = _context.Cars.ToList();
            return Ok(carList);
        }

        //Get one car
        [HttpGet]
        [Route("{Id}")]
        public ActionResult<Car> GetCar(int Id)
        {
            var car = _context.Cars.FirstOrDefault(c => c.Id == Id);
            if (car == null)
                return NotFound($"Car with Id {Id} not found");

            return Ok(car);
        }


        //Create Car
        [HttpPost]

        public ActionResult<Car> CreateCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
            return Ok(car);
        }


        //Update Car

        [HttpPut]
        [Route("{Id}")]
        public ActionResult<Car> UpdateCar(Car car, int Id)
        {
            var dbCar = _context.Cars.FirstOrDefault(c => c.Id == Id);
            if (dbCar == null)
                return NotFound($"Car with Id {car.Id} not found");

            dbCar.TeamName = car.TeamName;
            dbCar.Speed = car.Speed;
            dbCar.MelfunctionChance = car.MelfunctionChance;
            _context.SaveChanges();

            return Ok(dbCar);
        }

        //Delete Car
        [HttpDelete]
        [Route("{Id}")]
        public ActionResult DeleteCar(int Id)
        {
            var dbCar = _context.Cars.FirstOrDefault(c => c.Id == Id);
            if (dbCar == null)
                return NotFound($"Car with Id {Id} not found");

            _context.Remove(dbCar);
            _context.SaveChanges();

            return Ok($"Car with Id {Id} deleted");

        }
    }
}
