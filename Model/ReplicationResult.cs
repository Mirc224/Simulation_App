using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator_App.Model
{
    public class ReplicationResult
    {
        public double CumulativeNumberOfMoves { get; set; } = 0;
        public int CumulativeMoreThanK { get; set; } = 0;
        public double CumulativeStrategyMoves { get; set; } = 0;
    }
}
