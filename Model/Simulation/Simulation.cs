using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator_App.Model
{
    public abstract class Simulation
    {
        public enum SimulationStatus
        {
            FINISHED,
            CANCELED,
            PAUSED,
            RUNNING
        }

        public int ActualReplication { get; set; } = 0;
        public int NumberOfReplications { get; set; } = 0;
        public double ReplicationResult { get; set; } = 0;
        public Controller.Controller Controller { get; set; }
        public SimulationSettings SimulationSettings { get; set; }
        public List<ReplicationResult> ReplicationsResult { get; set; }


        public abstract void BeforeReplication();
        public abstract bool AfterReplication();
        public abstract void DoReplication();
        public abstract void BeforeSimulation();
        public abstract SimulationStatus RunSimulation();
        public abstract void AfterSimulation();
        public abstract void ApplySettings(SimulationSettings settings);
        public abstract List<ReplicationResult> GetReplicationsResult();
        public abstract bool Reset();
    }
}
