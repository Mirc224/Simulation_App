using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator_App.Model
{
    public class SimulationSettings
    {
        public int NumberOfReplications { get; set; } = 100;
        public double TresHold { get; set; } = 1;
        public int XSize { get; set; } = 5;
        public int YSize { get; set; } = 5;
        public int XStart { get; set; } = 0;
        public int YStart { get; set; } = 0;
    }
}
