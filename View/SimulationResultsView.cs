using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot.WindowsForms;
using System.Windows.Forms;
using OxyPlot.Series;

namespace Simulator_App.View
{
    public class SimulationResultsView
    {
        public PlotView SimulationGraph { get; set; }
        public PlotView ProbabilityGraph { get; set; }
        public Label MeanValueLabel { get; set; }
        public Label ProbabilityLabel { get; set; }
        public Label StrategyLabel { get; set; }
        public SimulationResultsView(PlotView smGraph, PlotView probGraph, Label meanValueL, Label probL, Label strategyL)
        {
            this.SimulationGraph = smGraph;
            this.ProbabilityGraph = probGraph;
            this.MeanValueLabel = meanValueL;
            this.ProbabilityLabel = probL;
            this.StrategyLabel = strategyL;
            this.Initialize();
        }

        public void Initialize()
        {
            this.SimulationGraph.Model = new OxyPlot.PlotModel { Title = "Mean avearage moves" };
            this.ProbabilityGraph.Model = new OxyPlot.PlotModel { Title = "Probability" };
        }

        public void Update(Controller.DataForUpdate data)
        {
            if(data.redrawGraphs)
                RedrawGraphs();
            UpdateValueLabels(data.meanValue, data.probability, data.strategyMoves);
        }

        public void RedrawGraphs()
        {
            SimulationGraph.InvalidatePlot(true);
            ProbabilityGraph.InvalidatePlot(true);
        }

        private void UpdateValueLabels(double meanValue, double probability, double meanStrategy)
        {
            this.MeanValueLabel.Text = $"Mean value: {meanValue}";
            this.ProbabilityLabel.Text = $"More than K: {probability}";
            this.StrategyLabel.Text = $"Strategy mean value: {meanStrategy}";
        }

        public void SetGraphs(LineSeries meanMovSeries, LineSeries probabilitySeries)
        {
            ProbabilityGraph.Model.ResetAllAxes();
            ProbabilityGraph.Model.Series.Clear();
            ProbabilityGraph.Model.Series.Add(probabilitySeries);
            ProbabilityGraph.InvalidatePlot(true);
            SimulationGraph.Model.Series.Clear();
            SimulationGraph.Model.Series.Add(meanMovSeries);
            SimulationGraph.Model.ResetAllAxes();
            SimulationGraph.InvalidatePlot(true);
        }
    }
}
