using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebUI.Features.MotorbikeRace.Models;
using WebUI.Features.MotorbikeRace.Services;

namespace WebUI.Features.MotorbikeRace
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorbikeRacesController : ControllerBase
    {
        #region ApplicationDbContext

        private readonly ApplicationDbContext _context;
        public MotorbikeRacesController(ApplicationDbContext context)
        {
            _context = context;
        }


        #endregion
        public MotorbikeRaceService motorbikeRaceService { get; set; } = new MotorbikeRaceService();

        //Get list of Car Races
        [HttpGet]
        public ActionResult<List<Domain.Entitties.MotorbikeRace>> GeMotorbikeRaces()
        {
            var carRaces = _context.MotorbikeRaces.Include(x => x.Motorbikes).ToList();
            return Ok(carRaces);
        }

        [HttpGet]
        [Route("{Id}")]
        public ActionResult GetMotorbikeRace(int Id)
        {
            var carRace = _context.MotorbikeRaces
                .Include(x => x.Motorbikes)
                .FirstOrDefault(x => x.Id == Id);

            if (carRace == null)
            {
                return NotFound($"Motorbike Race with Id {Id} not found");
            }

            return Ok(carRace);
        }

        [HttpPost]
        public ActionResult CreateMotorbikeRace(MotorbikeRaceCreateModel motorBikeRaceModel)
        {
            var newRace = new Domain.Entitties.MotorbikeRace
            {
                Name = motorBikeRaceModel.Name,
                Location = motorBikeRaceModel.Location,
                Distance = motorBikeRaceModel.Distance,
                TimeLimit = motorBikeRaceModel.TimeLimit

            };

            _context.MotorbikeRaces.Add(newRace);
            _context.SaveChanges();

            return Ok(newRace);
        }

        [HttpPut]
        [Route("{motorbikeRaceId}/addmotorbike/{motorbikeId}")]
        public ActionResult AddMotorbikeToMotorbikeRace(int motorbikeRaceId, int motorbikeId)
        {
            var dbMotorbikeRace = _context
                  .MotorbikeRaces
                  .Include(x => x.Motorbikes)
                  .FirstOrDefault(x => x.Id == motorbikeRaceId);
            if (dbMotorbikeRace == null)
            {
                return NotFound($"Motorbike Race with Id {motorbikeRaceId} not found");
            }

            var dbMotorbike = _context.Motorbikes.SingleOrDefault(c => c.Id == motorbikeId);
            if (dbMotorbike == null)
            {
                return NotFound($"Car with Id {motorbikeId} not found");
            }


            dbMotorbikeRace.Motorbikes.Add(dbMotorbike);
            _context.SaveChanges();

            return Ok(dbMotorbikeRace);
        }

        [HttpPut]
        [Route("{Id}/start")]
        public ActionResult StartMotorbikeRace(int Id)
        {
            var motorBikeRace = _context.MotorbikeRaces
                .Include(x => x.Motorbikes)
                .FirstOrDefault(x => x.Id == Id);

            if (motorBikeRace == null)
            {
                return NotFound($"motorBike Race with Id {Id} not found");
            }

            motorBikeRace.Status = "Started";
            var finishedRace = motorbikeRaceService.RunRace(motorBikeRace);
            _context.SaveChanges();

            return Ok(motorBikeRace);
        }

        [HttpPut]
        public ActionResult UpdateMotorbikeRace(MotorbikeRaceUpdateModel motorBikeRaceModel)
        {
            var dbMotorbikeRace = _context.MotorbikeRaces
                  .Include(x => x.Motorbikes)
                  .FirstOrDefault(x => x.Id == motorBikeRaceModel.Id);
            if (dbMotorbikeRace == null)
            {
                return NotFound($"Car Race with Id {motorBikeRaceModel.Id} not found");
            }


            dbMotorbikeRace.Name = motorBikeRaceModel.Name;
            dbMotorbikeRace.Location = motorBikeRaceModel.Location;
            dbMotorbikeRace.Distance = motorBikeRaceModel.Distance;
            dbMotorbikeRace.TimeLimit = motorBikeRaceModel.TimeLimit;


            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteMotorbikeRace(int id)
        {
            var dbMotorbikeRace = _context.MotorbikeRaces
                    .Include(x => x.Motorbikes)
                    .FirstOrDefault(x => x.Id == id);
            if (dbMotorbikeRace == null)
            {
                return NotFound($"Motorbike Race with Id {id} not found");
            }

            _context.MotorbikeRaces.Remove(dbMotorbikeRace);
            _context.SaveChanges();

            return Ok($"Motorbike Race with Id {id} successfully deleted");
        }
    }
}
