using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator_App.Model
{
    /*
     * Abstraktná trieda, ktorá v sebe zahŕňa predpis pre to, ako by mala vyzerať trieda simulácie.
     */
    public abstract class Simulation
    {
        /*
         * Enum, ktorý informuje o súčasnom stave simulácie.
         */
        public enum SimulationStatus
        {
            FINISHED,
            CANCELED,
            PAUSED,
            RUNNING
        }

        // Atribút nesie informáciu o tom, ktorá replikácia aktuálne beží.
        public int ActualReplication { get; set; } = 0;
        // Predstavuje počet replikácií, ktoré sa majú počas simulácie vykonať.
        public int NumberOfReplications { get; set; } = 0;
        // Obsahuje výsledok poslednej replikácie.
        public double ReplicationResult { get; set; } = 0;
        // Referencia na kontroler.
        public Controller.Controller Controller { get; set; }
        // Aktuálne nastavenia pre beh simulácie.
        public SimulationSettings SimulationSettings { get; set; }
        // List výsledkov replikácií.
        public List<ReplicationResult> ReplicationsResult { get; set; }
        // Obsahuje metódy, ktoré sa májú vykonať pred každou replikáciou.
        public abstract void BeforeReplication();
        // Obsahuje metódy, ktoré sa májú vykonať po každej replikácii.
        public abstract bool AfterReplication();
        // Obsahuje metódy, ktoré sa majú vykonať v rámci jednej replikácie.
        public abstract void DoReplication();
        // Obsahuje metódy, ktoré sa majú vykonať pred začatím simulácie.
        public abstract void BeforeSimulation();
        // Metóda, v ktorej beží cyklus simulácie. Návratová hodnota udáva stav simulácie, čiže či bola ukončená bežným spôsobom alebo bola zrušená.
        public abstract SimulationStatus RunSimulation();
        // Obsahuje metódy, ktoré sa majú vykonať po behu simulácie.
        public abstract void AfterSimulation();
        // Metóda, v rámci ktorej sa aplikujú nastavenia vložené ako parametre metódy.
        public abstract void ApplySettings(SimulationSettings settings);
        // Getter pre získanie listu s replikáciami. 
        public abstract List<ReplicationResult> GetReplicationsResult();
        // Metóda, ktorá vykoná reset simulácie.
        public abstract bool Reset();
    }
}
