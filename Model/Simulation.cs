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
        public int ActualReplication { get; set; } = 0;
        public int NumberOfReplications { get; set; } = 100;
        public double TresHold { get; set; }
        public double ReplicationResult { get; set; } = 0;
        public List<double> _iterationsResult { get; set; }

        public Controller.Controller _controller { get; set; }

        public SimulationSettings SimulationSettings { get; set; } = new SimulationSettings();

        private RobotCompetition robotProblem = new RobotCompetition(5, 5, 0, 0);

        public int MoreThanK { get; set; } = 0;

        public Simulation(Controller.Controller controller)
        {
            this._controller = controller;
            this._iterationsResult = new List<double>();
        }

        public void BeforeReplication()
        {

        }

        public bool AfterReplication()
        {
            this._iterationsResult.Add(ReplicationResult);
            if (ReplicationResult > SimulationSettings.TresHold)
                ++MoreThanK;

            return this._controller.AfterReplicationUpdate();
        }

        public void DoReplication()
        {
            ReplicationResult = robotProblem.runTest();
            System.Threading.Thread.Sleep(25);
        }

        public bool RunSimulation()
        {
            bool cancelPending = false;
            robotProblem = new RobotCompetition(SimulationSettings.XSize, SimulationSettings.YSize,
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
                return false;

            return true;
        }

        public void ApplySettings(SimulationSettings settings)
        {
            this.SimulationSettings = settings;
            this.NumberOfReplications = SimulationSettings.NumberOfReplications;
            this.TresHold = SimulationSettings.TresHold;
        }

        public List<double> GetIterationsResult() { return this._iterationsResult; }

        public bool Reset()
        {
            this.ActualReplication = 0;
            this.MoreThanK = 0;
            this.ReplicationResult = 0;
            this._iterationsResult.Clear();
            return true;
        }
    }
}
