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
    }
}
