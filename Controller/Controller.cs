using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot.WindowsForms;
using OxyPlot.Series;
using System.ComponentModel;
using Simulator_App.Model;

namespace Simulator_App.Controller
{
    public struct OptionsInput
    {
        public string numberOfIterations;
        public string numberOfReplications;
        public string tresHold;
        public bool errorOccured;
    }
    class Controller
    {
        private AppGUI _applicationGUI;
        private LineSeries _lineSeries;
        private Simulation _simulation;
        private BackgroundWorker _simulationWorker;

        public bool SimmulationFinished { get; set; }
        private bool PauseClicked;

        public Controller(AppGUI applicationGUI)
        {
            this._applicationGUI = applicationGUI;
            this._simulation = new Simulation(this);
            SimmulationFinished = true;
        }

        public bool InitilizeSimulation(PlotView graph)
        {
            if (SimmulationFinished)
            {
                _simulation.Reset();
                _lineSeries = new LineSeries();
                graph.Model.Series.Clear();
                graph.Model.Series.Add(_lineSeries);
                graph.InvalidatePlot(true);
            }
            return true;
        }
        public bool RunSimulation(BackgroundWorker simulationWorker)
        {
            this.SimmulationFinished = true;
            this._simulationWorker = simulationWorker;
            this.SimmulationFinished = this._simulation.RunSimulation();
            return true;
        }

        public bool AfterIterationUpdate()
        {
            var iterationResults = this._simulation.GetIterationsResult();
            double iterationsSum = iterationResults.Sum();
            int iterationsCount = iterationResults.Count;
            this._lineSeries.Points.Add(new OxyPlot.DataPoint(iterationsCount, iterationsSum/iterationsCount));
            this._simulationWorker.ReportProgress(iterationsCount);
            if (this._simulationWorker.CancellationPending)
                return true;

            return false;
        }

        public bool TryApplySimulationSetings(ref OptionsInput input)
        {
            var parsedSettings = this.ParseSimulationSettings(ref input);

            if (parsedSettings == null)
                return false;

            this.SetSimulationSettings(parsedSettings);
            return true;
        }
        private SimulationSettings ParseSimulationSettings(ref OptionsInput input)
        {
            int numberOfIterations = -1;
            int numberOfReplications = -1;
            double tresHold = -1;
            if (!Int32.TryParse(input.numberOfIterations, out numberOfIterations))
            {
                input.errorOccured = true;
                input.numberOfIterations = "Error";
            }

            if (!Int32.TryParse(input.numberOfReplications, out numberOfReplications))
            {
                input.errorOccured = true;
                input.numberOfReplications = "Error";
            }

            if (!Double.TryParse(input.tresHold, out tresHold))
            {
                input.errorOccured = true;
                input.tresHold = "Error";
            }

            if(input.errorOccured)
            {
                return null;
            }

            return new SimulationSettings { NumberOfIterations = numberOfIterations,
                                            NumberOfReplications = numberOfReplications,
                                            TresHold = tresHold};
        }
        
        private void SetSimulationSettings(SimulationSettings simSettings) 
        {
            this._simulation.ApplySettings(simSettings);
        }

        public void ResetSimulation()
        {
            this.SimmulationFinished = true;
            this._simulation.Reset();
            this.PauseClicked = false;
        }

        public void SetPauseClicked(bool value)
        {
            this.PauseClicked = value;
        }

        public bool GetPauseClicked()
        {
            return this.PauseClicked;
        }
    }
}
