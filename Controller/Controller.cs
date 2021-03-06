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
        public string xSize;
        public string ySize;
        public string xStart;
        public string yStart;
        public string numberOfReplications;
        public string tresHold;
        public bool errorOccured;
    }

    public struct DataForUpdate
    {
        public double meanValue;
        public double probability;
        public double strategyMoves;
        public bool redrawGraphs;

        public DataForUpdate(DataForUpdate othr)
        {
            this.meanValue = othr.meanValue;
            this.probability = othr.probability;
            this.redrawGraphs = othr.redrawGraphs;
            this.strategyMoves = othr.strategyMoves;
        }
    }
    public class Controller
    {
        private AppGUI _applicationGUI;
        private LineSeries _lineSeriesMeanMoves;
        private LineSeries _lineSeriesProbability;
        private Simulation _simulation;
        private BackgroundWorker _simulationWorker;

        public DataForUpdate lastDataForUpdate = new DataForUpdate();

        private SimulationSettings _simulationSettings;

        public Simulation.SimulationStatus SimulationStatus { get; set; } = Simulation.SimulationStatus.FINISHED;

        private bool PauseClicked;

        public Controller(AppGUI applicationGUI)
        {
            _simulationSettings = new SimulationSettings
            {
                NumberOfReplications = 10000,
                TresHold = 1,
                XSize = 10,
                YSize = 10,
                XStart = 0,
                YStart = 0
            };

            this._applicationGUI = applicationGUI;
            this._applicationGUI.InitilaizeOptionsValues(_simulationSettings);
            this._simulation = new MonteCarloSimulation(this, _simulationSettings);
        }

        public bool InitilizeSimulation(View.SimulationResultsView simResView)
        {
            if (SimulationStatus == Simulation.SimulationStatus.FINISHED || SimulationStatus == Simulation.SimulationStatus.CANCELED)
            {
                _simulation.Reset();
                this.SetLineSeries();
                simResView.SetGraphs(_lineSeriesMeanMoves, _lineSeriesProbability);
            }
            return true;
        }

        private void SetLineSeries()
        {
            _lineSeriesMeanMoves = new LineSeries();
            _lineSeriesMeanMoves.Title = "Mean number of moves";
            _lineSeriesProbability = new LineSeries();
            _lineSeriesProbability.Title = "Probability";
            _lineSeriesProbability.Color = OxyPlot.OxyColor.FromRgb(255, 0, 0);
        }
        public bool RunSimulation(BackgroundWorker simulationWorker)
        {
            this._simulationWorker = simulationWorker;
            this._simulation.BeforeSimulation();
            this.SimulationStatus = Simulation.SimulationStatus.RUNNING;
            this.SimulationStatus = this._simulation.RunSimulation();
            if(this.SimulationStatus != Simulation.SimulationStatus.FINISHED)
            {
                if (this.PauseClicked)
                    this.SimulationStatus = Simulation.SimulationStatus.PAUSED;
            }
            else
            {
                Console.WriteLine(lastDataForUpdate.meanValue);
            }
            return true;
        }

        public bool AfterReplicationUpdate()
        {
            var replicationResultsList = this._simulation.GetReplicationsResult();
            int iterationsCount = replicationResultsList.Count;

            var lastReplication = replicationResultsList.Last();

            var meanValue = lastReplication.CumulativeNumberOfMoves / iterationsCount;
            var probability = (double)lastReplication.CumulativeMoreThanK / iterationsCount;
            var meanStrategy = lastReplication.CumulativeStrategyMoves / iterationsCount;

            if (iterationsCount >= _simulationSettings.NumberOfReplications * 0.25)
            {

                this._lineSeriesMeanMoves.Points.Add(new OxyPlot.DataPoint(iterationsCount, meanValue));
                this._lineSeriesProbability.Points.Add(new OxyPlot.DataPoint(iterationsCount, probability));
            }

            this.lastDataForUpdate.meanValue = meanValue;
            this.lastDataForUpdate.probability = probability;
            this.lastDataForUpdate.strategyMoves = meanStrategy;
            this.lastDataForUpdate.redrawGraphs = false;
            if(iterationsCount % (int)(_simulationSettings.NumberOfReplications * 0.05) == 0)
                this._simulationWorker.ReportProgress(iterationsCount, lastDataForUpdate);
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
            int xSize = -1;
            int ySize = -1;
            int xStart = -1;
            int yStart = -1;
            double tresHold = -1;
            if (!Int32.TryParse(input.xSize, out xSize))
            {
                input.errorOccured = true;
                input.xSize = "Error";
            }

            if (!Int32.TryParse(input.ySize, out ySize))
            {
                input.errorOccured = true;
                input.ySize = "Error";
            }

            if (!Int32.TryParse(input.xStart, out xStart))
            {
                input.errorOccured = true;
                input.xStart = "Error";
            }

            if (!Int32.TryParse(input.yStart, out yStart))
            {
                input.errorOccured = true;
                input.yStart = "Error";
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

            return new SimulationSettings { XSize = xSize,
                                            YSize = ySize,
                                            XStart = xStart, 
                                            YStart = yStart,
                                            NumberOfReplications = numberOfReplications,
                                            TresHold = tresHold};
        }
        
        private void SetSimulationSettings(SimulationSettings simSettings) 
        {
            this._simulationSettings = simSettings;
            this._simulation.ApplySettings(_simulationSettings);
        }

        public void ResetSimulation()
        {
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
