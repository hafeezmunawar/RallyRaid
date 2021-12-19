using Domain.Entitties;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebUI.Features.MotorBikes
{
    [Route("api/motorbikes")]
    [ApiController]
    public class MotorbikesController : ControllerBase
    {
        //Get list of motorBikes
        [HttpGet]
        public ActionResult<List<Motorbike>> GetMotorbikes()
        {
            var motorbikeList = new List<Motorbike>
            {

                new Motorbike { TeamName = "Team A", Speed = 100, MelfunctionChance = 0.2},
                new Motorbike { TeamName = "Team B", Speed = 120, MelfunctionChance = 0.3},
                new Motorbike { TeamName = "Team C", Speed = 98, MelfunctionChance = 0.1},
                new Motorbike { TeamName = "Team D", Speed = 101, MelfunctionChance = 0.5}

            };

            return Ok(motorbikeList);
        }


        //Get one motorBike
        [HttpGet]
        [Route("{Id}")]
        public ActionResult<Motorbike> GetMotorbike(int Id)
        {
            return Ok(new Motorbike { TeamName = "Team A", Speed = 100, MelfunctionChance = 0.2 });
        }


        //Create Car
        [HttpPost]

        public ActionResult<Motorbike> CreateCar(Motorbike bike)
        {
            var newMotorBike = new Motorbike
            {
                Id = bike.Id,
                TeamName = bike.TeamName,
                Speed = bike.Speed,
                MelfunctionChance = bike.MelfunctionChance
            };

            return Ok(newMotorBike);
        }


        //Update Car

        [HttpPut]
        [Route("{Id}")]
        public ActionResult<Motorbike> UpdateMotorbike(Motorbike bike)
        {
            var updatedBike = new Car
            {
                Id = bike.Id,
                TeamName = bike.TeamName,
                Speed = bike.Speed,
                MelfunctionChance = bike.MelfunctionChance
            };

            return Ok(updatedBike);
        }

        //Delete Car
        [HttpDelete]
        [Route("{Id}")]
        public ActionResult DeleteMotorbike(int Id)
        {
            return Ok($"Motorbike with Id {Id} was successfully deleted");
        }
    }

}
