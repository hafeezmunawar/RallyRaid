using Domain.Entitties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebUI.Features.CarRaces.Services
{
    public class CarRaceService
    {
        public CarRace RunRace(CarRace carRace)
        {
            var racers = new List<Car>();
            foreach (var car in carRace.Cars)
            {
                while (car.DistanceCoveredInMiles < carRace.Distance
                    && car.RacedHours < carRace.TimeLimit)
                {

                    var random = new Random().Next(1, 101);
                    if (random <= car.MelfunctionChance)
                    {
                        car.MelfunctionsOccured++;
                    }
                    else
                    {
                        car.DistanceCoveredInMiles += car.Speed;
                    }

                    car.RacedHours++;
                }

                if (car.DistanceCoveredInMiles >= carRace.Distance)
                {
                    car.FinishedRace = true;
                }

                racers.Add(car);
            }

            carRace.Cars = racers.OrderBy(x => x.FinishedRace)
                                 .ThenByDescending(x => x.DistanceCoveredInMiles)
                                 .ThenByDescending(x => x.RacedHours)
                                 .ToList();
            return carRace;

        }
    }
}
