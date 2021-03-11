using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot.WindowsForms;
using System.Windows.Forms;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace Simulator_App.View
{
    // Trieda obsahujúca grafické komponenty a metódy pre zobrazovanie výsledkov simulácie.
    public class SimulationResultsView
    {
        public PlotView SimulationGraph { get; set; }
        public PlotView ProbabilityGraph { get; set; }
        public Label MeanValueLabel { get; set; }
        public Label ProbabilityLabel { get; set; }
        public Label StrategyLabel { get; set; }
        public Label MinValueLabel { get; set; }
        public Label MaxValueLabel { get; set; }
        public SimulationResultsView(PlotView[] plots, Label[] labels)
        {
            this.SimulationGraph = plots[0];
            this.ProbabilityGraph = plots[1];
            this.MeanValueLabel = labels[0];
            this.MinValueLabel = labels[1];
            this.MaxValueLabel = labels[2];
            this.ProbabilityLabel = labels[3];
            this.StrategyLabel = labels[4];
            this.Initialize();
        }

        public void Initialize()
        {
            this.SimulationGraph.Model = new OxyPlot.PlotModel { Title = "Mean number of moves" };
            var linearAxis1 = new LinearAxis();
            linearAxis1.MajorGridlineStyle = OxyPlot.LineStyle.Solid;
            linearAxis1.MinorGridlineStyle = OxyPlot.LineStyle.Dot;
            linearAxis1.Position = AxisPosition.Bottom;
            this.SimulationGraph.Model.Axes.Add(linearAxis1);

            var linearAxis2 = new LinearAxis();
            linearAxis2.MajorGridlineStyle = OxyPlot.LineStyle.Solid;
            linearAxis2.MinorGridlineStyle = OxyPlot.LineStyle.Dot;
            this.SimulationGraph.Model.Axes.Add(linearAxis2);

            this.ProbabilityGraph.Model = new OxyPlot.PlotModel { Title = "Probability" };
        }
        // Metóda, ktorá zavolá metódy na zobrazenie výstupov alebo prípadne vykreslenie grafov v závislosti od hodnôt v štruktúre DataForUpdate.
        public void Update(Controller.DataForUpdate data)
        {
            if(data.redrawGraphs)
                RedrawGraphs();
            UpdateValueLabels(data.meanValue, data.minValue, data.maxValue, data.probability, data.strategyMoves);
        }
        // Vykoná prekreslenie grafov.
        public void RedrawGraphs()
        {
            SimulationGraph.InvalidatePlot(true);
            ProbabilityGraph.InvalidatePlot(true);
        }
        // Aktualizuje hodnoty labelov, ktoré zorazujú aktuálnu hodnotu sledovnaých štatistík.
        private void UpdateValueLabels(double meanValue, double minValue, double maxValue, double probability, double meanStrategy)
        {
            this.MeanValueLabel.Text = $"Mean value: {meanValue}";
            this.MinValueLabel.Text = $"Min value: {minValue}";
            this.MaxValueLabel.Text = $"Max value: {maxValue}";
            this.ProbabilityLabel.Text = $"More than K: {probability}";
            this.StrategyLabel.Text = $"Strategy mean value: {meanStrategy}";
        }
        // Metóda resetuje grafy a pripraví ich na zobrazovanie údajov.
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
