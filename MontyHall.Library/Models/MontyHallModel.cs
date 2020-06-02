using System;
using System.Collections.Generic;
using System.Text;

namespace MontyHall.Library.Models
{
    public class MontyHallModel
    {
        public int SimulationCount { get; set; }
        public bool HasSwitched { get; set; }
        public int Wins { get; set; }
    }
}
