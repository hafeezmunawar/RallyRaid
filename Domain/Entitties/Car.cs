using System;

namespace Domain.Entitties
{
    public class Car
    {
        public int Id { get; set; }
        public String TeamName { get; set; }
        public int Speed { get; set; }
        public double MelfunctionChance { get; set; }
        public int MelfunctionsOccured { get; set; }
        public int DistanceCoveredInMiles { get; set; }
        public bool FinishedRace { get; set; }
        public int RacedHours { get; set; }
    }
}
