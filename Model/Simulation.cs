using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Simulator_App.Controller;

namespace Simulator_App.Model
{
    class Simulation
    {
        public enum SimulationStatus
        {
            FINISHED,
            CANCELED,
            PAUSED,
            RUNNING
        }

        public int ActualReplication { get; set; } = 0;
        public int NumberOfReplications { get; set; } = 100;
        public double TresHold { get; set; }
        public double ReplicationResult { get; set; } = 0;
        public List<double> ReplicationsResult { get; set; }

        public Controller.Controller _controller { get; set; }

        public SimulationSettings SimulationSettings { get; set; }

        private RobotCompetition robotProblem = new RobotCompetition(5, 5, 0, 0);

        public int MoreThanK { get; set; } = 0;

        public Simulation(Controller.Controller controller, SimulationSettings defaultSettings)
        {
            this._controller = controller;
            this.ApplySettings(defaultSettings);
            this.ReplicationsResult = new List<double>();
        }

        public void BeforeReplication()
        {

        }

        public bool AfterReplication()
        {
            this.ReplicationsResult.Add(ReplicationResult);
            if (ReplicationResult > SimulationSettings.TresHold)
                ++MoreThanK;

            return this._controller.AfterReplicationUpdate();
        }

        public void DoReplication()
        {
            ReplicationResult = robotProblem.runTest();
            //System.Threading.Thread.Sleep(1);
        }

        public SimulationStatus RunSimulation()
        {
            bool cancelPending = false;
            // V pripade ak pokracujeme v predchadzajucej simulacii, tak nevytvarame novu instanciu objektu.
            if(ActualReplication == 0)
                robotProblem.Reset(SimulationSettings.XSize, SimulationSettings.YSize,
                                                    SimulationSettings.XStart, SimulationSettings.YStart);

            for (ActualReplication = ActualReplication; ActualReplication < NumberOfReplications; ActualReplication++)
            {
                BeforeReplication();
                DoReplication();
                cancelPending = AfterReplication();
                if (cancelPending)
                    break;
            }
            if (cancelPending)
                return SimulationStatus.CANCELED;

            return SimulationStatus.FINISHED;
        }

        public void ApplySettings(SimulationSettings settings)
        {
            this.SimulationSettings = settings;
            this.NumberOfReplications = SimulationSettings.NumberOfReplications;
            this.TresHold = SimulationSettings.TresHold;
            this.ActualReplication = 0;
        }

        public List<double> GetIterationsResult() { return this.ReplicationsResult; }

        public bool Reset()
        {
            this.ActualReplication = 0;
            this.MoreThanK = 0;
            this.ReplicationResult = 0;
            this.ReplicationsResult.Clear();
            return true;
        }

        public bool HasFinished()
        {
            return ActualReplication == NumberOfReplications;
        }
    }
}
