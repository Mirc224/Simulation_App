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
        public int ActualIteration { get; set; }
        public int NumberOfIterations { get; set; }
        public int NumberOfReplications { get; set; }
        public double TresHold { get; set; }
        private double _replicationSum;
        private List<double> _iterationsResult;

        private Controller.Controller _controller;

        public Simulation(Controller.Controller controller)
        {
            this._controller = controller;
            this._iterationsResult = new List<double>();
            NumberOfIterations = 1000;
            NumberOfReplications = 10;
        }

        public bool RunSimulation()
        {
            Random generator = new Random();
            bool cancelPending = false;
            for (ActualIteration = ActualIteration; ActualIteration < NumberOfIterations; ActualIteration++)
            {
                _replicationSum = 0;
                for (int replicaton = 0; replicaton < NumberOfReplications; replicaton++)
                {
                    _replicationSum += generator.NextDouble() * 5;
                }
                System.Threading.Thread.Sleep(25);
                cancelPending = this.AfterSimulationRun();
                if (cancelPending)
                    break;
            }
            if (cancelPending)
                return false;

            return true;
        }

        private bool AfterSimulationRun()
        {
            this._iterationsResult.Add(_replicationSum);
            
            return this._controller.AfterIterationUpdate();
        }

        public void ApplySettings(SimulationSettings settings)
        {
            this.NumberOfIterations = settings.NumberOfIterations;
            this.NumberOfReplications = settings.NumberOfReplications;
            this.TresHold = settings.TresHold;
        }

        public List<double> GetIterationsResult() { return this._iterationsResult; }

        public bool Reset()
        {
            this.ActualIteration = 0;
            this._iterationsResult.Clear();
            return true;
        }
    }
}
