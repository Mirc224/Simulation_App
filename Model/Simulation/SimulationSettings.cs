using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator_App.Model
{
    // Trieda obsahujúca nastavenia pre beh simulácie.
    public class SimulationSettings
    {
        // Atribút hovorí po požadovanom počte replikácii v simulácii.
        public int NumberOfReplications { get; set; } = 100;
        // Udáva hodnotu K, ktorá keď je prekročená, dôjde k nejakej udalosti-
        public double TresHold { get; set; } = 1;
        // Horiznontálna veľkosť plochy, na ktorej sa pohybuje robot.
        public int XSize { get; set; } = 5;
        // Vertikálna veľkosť plochy, po korej sa pohybuje robot.
        public int YSize { get; set; } = 5;
        // X súradnica, na ktorej robot začína.
        public int XStart { get; set; } = 0;
        // Y súradnica, na ktorej robot začína.
        public int YStart { get; set; } = 0;
        // Seed, ktorý je použitý v prípade, ak nie je nastavený random seed.
        public int Seed { get; set; } = 0;
        // Hovorí o tom, či má byť použitý random seed.
        public bool AutoSeed { get; set; } = true;

    }
}
