using System;
using System.Collections.Generic;
using System.Linq;

namespace WebUI.Features.MotorbikeRace.Services
{
    public class MotorbikeRaceService
    {
        public Domain.Entitties.MotorbikeRace RunRace(Domain.Entitties.MotorbikeRace motobikeRace)
        {
            var racers = new List<Domain.Entitties.Motorbike>();
            foreach (var car in motobikeRace.Motorbikes)
            {
                while (car.DistanceCoveredInMiles < motobikeRace.Distance
                    && car.RacedHours < motobikeRace.TimeLimit)
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

                if (car.DistanceCoveredInMiles >= motobikeRace.Distance)
                {
                    car.FinishedRace = true;
                }

                racers.Add(car);
            }

            motobikeRace.Motorbikes = racers.OrderBy(x => x.FinishedRace)
                                 .ThenByDescending(x => x.DistanceCoveredInMiles)
                                 .ThenByDescending(x => x.RacedHours)
                                 .ToList();
            return motobikeRace;

        }
    }
}
