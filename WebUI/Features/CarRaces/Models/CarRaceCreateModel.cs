using System;

namespace WebUI.Features.CarRaces.Models
{
    public class CarRaceCreateModel
    {
        public String Name { get; set; }
        public String Location { get; set; }
        public int Distance { get; set; }
        public int TimeLimit { get; set; }
    }
}
