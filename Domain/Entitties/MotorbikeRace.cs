using System;
using System.Collections.Generic;

namespace Domain.Entitties
{
    public class MotorbikeRace
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Location { get; set; }
        public int Distance { get; set; }
        public int TimeLimit { get; set; }
        public String Status { get; set; }
        public List<Motorbike> Motorbikes { get; set; }
    }
}
