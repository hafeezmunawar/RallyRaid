using Domain.Entitties;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebUI.Features.MotorBikes
{
    [Route("api/motorbikes")]
    [ApiController]
    public class MotorbikesController : ControllerBase
    {


        #region DbContext
        private readonly ApplicationDbContext _context;

        public MotorbikesController(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        //Get list of motorBikes
        [HttpGet]
        public ActionResult<List<Motorbike>> GetMotorbikes()
        {
            var motorbikeList = _context.Motorbikes.ToList();
            return Ok(motorbikeList);
        }


        //Get one motorBike
        [HttpGet]
        [Route("{Id}")]
        public ActionResult<Motorbike> GetMotorbike(int Id)
        {
            var motorbike = _context.Motorbikes.FirstOrDefault(c => c.Id == Id);
            if (motorbike == null)
                return NotFound($"motorbike with Id {Id} not found");

            return Ok(motorbike);
        }


        //Create Car
        [HttpPost]

        public ActionResult<Motorbike> CreateCar(Motorbike bike)
        {
            _context.Motorbikes.Add(bike);
            _context.SaveChanges();
            return Ok(bike);
        }


        //Update Car

        [HttpPut]
        [Route("{Id}")]
        public ActionResult<Motorbike> UpdateMotorbike(Motorbike bike, int Id)
        {
            var dbMotorBike = _context.Motorbikes.FirstOrDefault(m => m.Id == Id);
            if (dbMotorBike == null)
                return NotFound($"Bike with Id {Id} not found");

            dbMotorBike.TeamName = bike.TeamName;
            dbMotorBike.Speed = bike.Speed;
            dbMotorBike.MelfunctionChance = bike.MelfunctionChance;
            _context.SaveChanges();

            return Ok(dbMotorBike);
        }

        //Delete Car
        [HttpDelete]
        [Route("{Id}")]
        public ActionResult DeleteMotorbike(int Id)
        {
            var dbMotorBike = _context.Motorbikes.FirstOrDefault(m => m.Id == Id);
            if (dbMotorBike == null)
                return NotFound($"Motorbike with Id {Id} not found");

            _context.Remove(dbMotorBike);
            _context.SaveChanges();

            return Ok($"Motorbike with Id {Id} deleted");
        }
    }

}
