using Domain.Entitties;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebUI.Features.CarRaces.Models;

namespace WebUI.Features.CarRaces
{
    [Route("api/carraces")]
    [ApiController]
    public class CarRacesController : ControllerBase
    {
        #region ApplicationDbContext

        private readonly ApplicationDbContext _context;
        public CarRacesController(ApplicationDbContext context)
        {
            _context = context;
        }


        #endregion

        //Get list of Car Races
        [HttpGet]
        public ActionResult<List<CarRace>> GetCarRaces()
        {
            var carRaces = _context.CarRaces.Include(x => x.Cars).ToList();
            return Ok(carRaces);
        }

        [HttpGet]
        [Route("{Id}")]
        public ActionResult GetCarRace(int Id)
        {
            var carRace = _context.CarRaces
                .Include(x => x.Cars)
                .FirstOrDefault(x => x.Id == Id);

            if (carRace == null)
            {
                return NotFound($"Car Race with Id {Id} not found");
            }

            return Ok(carRace);
        }

        [HttpPost]
        public ActionResult CreateCarRace(CarRaceCreateModel carRaceModel)
        {
            var newRace = new CarRace
            {
                Name = carRaceModel.Name,
                Location = carRaceModel.Location,
                Distance = carRaceModel.Distance,
                TimeLimit = carRaceModel.TimeLimit

            };

            _context.CarRaces.Add(newRace);
            _context.SaveChanges();

            return Ok(newRace);
        }

        [HttpPut]
        [Route("{carRaceId}/addCar/{carId}")]
        public ActionResult AddCarToCarRace(int carRaceId, int carId)
        {
            var dbCarRace = _context
                  .CarRaces
                  .Include(x => x.Cars)
                  .FirstOrDefault(x => x.Id == carRaceId);
            if (dbCarRace == null)
            {
                return NotFound($"Car Race with Id {carRaceId} not found");
            }

            var dbCar = _context.Cars.SingleOrDefault(c => c.Id == carId);
            if (dbCar == null)
            {
                return NotFound($"Car with Id {carId} not found");
            }


            dbCarRace.Cars.Add(dbCar);
            _context.SaveChanges();

            return Ok(dbCarRace);
        }

        [HttpPut]
        [Route("{Id}/start")]
        public ActionResult StartCarRace(int Id)
        {
            var carRace = _context.CarRaces
                .Include(x => x.Cars)
                .FirstOrDefault(x => x.Id == Id);

            if (carRace == null)
            {
                return NotFound($"Car Race with Id {Id} not found");
            }

            carRace.Status = "Started";
            _context.SaveChanges();

            return Ok(carRace);
        }

        [HttpPut]
        public ActionResult UpdateCarRace(CarRaceUpdateModel carRaceModel)
        {
            var dbCarRace = _context.CarRaces
                  .Include(x => x.Cars)
                  .FirstOrDefault(x => x.Id == carRaceModel.Id);
            if (dbCarRace == null)
            {
                return NotFound($"Car Race with Id {carRaceModel.Id} not found");
            }


            dbCarRace.Name = carRaceModel.Name;
            dbCarRace.Location = carRaceModel.Location;
            dbCarRace.Distance = carRaceModel.Distance;
            dbCarRace.TimeLimit = carRaceModel.TimeLimit;


            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCarRace(int id)
        {
            var dbCarRace = _context.CarRaces
                    .Include(x => x.Cars)
                    .FirstOrDefault(x => x.Id == id);
            if (dbCarRace == null)
            {
                return NotFound($"Car Race with Id {id} not found");
            }

            _context.CarRaces.Remove(dbCarRace);
            _context.SaveChanges();

            return Ok($"Car Race with Id {id} successfully deleted");
        }

    }
}
