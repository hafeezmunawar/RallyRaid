using Domain.Entitties;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebUI.Features.Cars.Models;

namespace WebUI.Features.Cars
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        #region ApplicationDbContext
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion


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

        public ActionResult<Car> CreateCar(CarCreateModel carModel)
        {

            var newCar = new Car
            {
                TeamName = carModel.TeamName,
                Speed = carModel.Speed,
                MelfunctionChance = carModel.MelfunctionChance
            };

            _context.Cars.Add(newCar);
            _context.SaveChanges();
            return Ok(carModel);
        }


        //Update Car

        [HttpPut]
        [Route("{Id}")]
        public ActionResult<Car> UpdateCar(CarUpdateModel carModel, int Id)
        {
            var dbCar = _context.Cars.FirstOrDefault(c => c.Id == Id);
            if (dbCar == null)
                return NotFound($"Car with Id {Id} not found");

            dbCar.TeamName = carModel.TeamName;
            dbCar.Speed = carModel.Speed;
            dbCar.MelfunctionChance = carModel.MelfunctionChance;
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
