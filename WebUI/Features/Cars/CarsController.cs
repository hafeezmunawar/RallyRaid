using Domain.Entitties;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebUI.Features.Cars
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Car>> GetCars()
        {
            var carList = new List<Car>
            {

                new Car { TeamName = "Team A", Speed = 100, MelfunctionChance = 0.2},
                new Car { TeamName = "Team B", Speed = 120, MelfunctionChance = 0.3},
                new Car { TeamName = "Team C", Speed = 98, MelfunctionChance = 0.1},
                new Car { TeamName = "Team D", Speed = 101, MelfunctionChance = 0.5}

            };

            return Ok(carList);
        }

        //Get one car
        [HttpGet]
        [Route("{Id}")]
        public ActionResult<Car> GetCar(int Id)
        {
            return Ok(new Car { TeamName = "Team A", Speed = 100, MelfunctionChance = 0.2 });
        }


        //Create Car
        [HttpPost]

        public ActionResult<Car> CreateCar(Car car)
        {
            var newCar = new Car
            {
                Id = car.Id,
                TeamName = car.TeamName,
                Speed = car.Speed,
                MelfunctionChance = car.MelfunctionChance
            };

            return Ok(newCar);
        }


        //Update Car

        [HttpPut]
        [Route("{Id}")]
        public ActionResult<Car> UpdateCar(Car car)
        {
            var updatedCar = new Car
            {
                Id = car.Id,
                TeamName = car.TeamName,
                Speed = car.Speed,
                MelfunctionChance = car.MelfunctionChance
            };

            return Ok(updatedCar);
        }

        //Delete Car
        [HttpDelete]
        [Route("{Id}")]
        public ActionResult DeleteCar(int Id)
        {
            return Ok($"Car with Id {Id} was successfully deleted");
        }
    }
}
