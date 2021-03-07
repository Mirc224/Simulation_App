using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator_App.Model
{
    /*
     * Trieda, ktorá v sebe zahŕňa výsledky jednej replikácie. Táto trieda je špecificky navrhnutá pre úlohu s robotom.
     * Obsahuje kumulatívne súčty výsledkov sledovaných javov. Ide o kumulatívne súčty, aby sme ich za každým pri vykresľovaní nemuseli sčítať.
     */
    public class ReplicationResult
    {
        // Kumulatívný súčet počtu vykonaných krokov.
        public double CumulativeNumberOfMoves { get; set; } = 0;
        // Kumulatívny súčet počtu replikácií, keď robot vykonl viac ako K krokov.
        public int CumulativeMoreThanK { get; set; } = 0;
        // Kumulatívny súčet výsledkov simulácie pri použití navrhnutej stratégie.
        public double CumulativeStrategyMoves { get; set; } = 0;
    }
}
