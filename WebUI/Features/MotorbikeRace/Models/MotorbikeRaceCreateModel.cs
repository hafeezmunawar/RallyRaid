using System;

namespace WebUI.Features.MotorbikeRace.Models
{
    public class MotorbikeRaceCreateModel
    {
        public String Name { get; set; }
        public String Location { get; set; }
        public int Distance { get; set; }
        public int TimeLimit { get; set; }
    }
}
