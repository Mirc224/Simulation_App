using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simulator_App.Controller;

namespace Simulator_App
{
    public partial class AppGUI : Form
    {

        private Controller.Controller _controller;
        public AppGUI()
        {
            InitializeComponent();
            this.SimulationGraph.Model = new OxyPlot.PlotModel { Title = "Simulacia" };
            this._controller = new Controller.Controller(this);
        }

        private void SimulationWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this._controller.InitilizeSimulation(this.SimulationGraph);
            this._controller.RunSimulation(this.simulationWorker);
            if(this.simulationWorker.CancellationPending)
            {
                if (!this._controller.SimmulationFinished)
                    e.Cancel = true;
            }
        }

        private void SimulationWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            SimulationGraph.InvalidatePlot(true);
        }

        private void SimulationWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled)
            {
                if (this._controller.GetPauseClicked())
                    this.RunPauseButton.Text= "Continue";
                else
                {
                    this.RunPauseButton.Text = "Start";
                    this._controller.ResetSimulation();
                    this.StopButton.Enabled = false;
                }
            } 
            else
            {
                this.SetButtonToDefault();
            }
            
        }

        private void RunPauseButton_Click(object sender, EventArgs e)
        {
            if(!simulationWorker.IsBusy)
            {
                simulationWorker.RunWorkerAsync();
                RunPauseButton.Text = "Pause";
                StopButton.Enabled = true;
                this._controller.SetPauseClicked(false);
            } else
            {
                this.simulationWorker.CancelAsync();
                RunPauseButton.Text = "Continue";
                this._controller.SetPauseClicked(true);
            }
        }
        
        public OptionsInput GetSettingsInput()
        {
            var settings = new OptionsInput();
            settings.xSize = this.XSizeInput.Text;
            settings.ySize = this.YSizeInput.Text;
            settings.xStart = this.XStartInput.Text;
            settings.yStart = this.YStartInput.Text;
            settings.numberOfReplications = this.ReplicationsInput.Text;
            settings.tresHold = this.TresholdInput.Text;
            settings.errorOccured = false;
            return settings;
        }

        private void OptConfirmButton_Click(object sender, EventArgs e)
        {
            var settings = this.GetSettingsInput();
            this._controller.TryApplySimulationSetings(ref settings);
            if(settings.errorOccured)
            {
                this.SetOptionsInputText(settings);
            }
            else
            {
                this.SetOptionsLabelText(settings);
            }
        }

        private void SetOptionsInputText(OptionsInput settings)
        {
            this.XSizeInput.Text = settings.xSize;
            this.YSizeInput.Text = settings.ySize;
            this.XStartInput.Text = settings.xStart;
            this.YStartInput.Text = settings.yStart;
            this.ReplicationsInput.Text = settings.numberOfReplications;
            this.TresholdInput.Text = settings.tresHold;
        }

        private void SetOptionsLabelText(OptionsInput settings)
        {
            XSizeLabel.Text = $"X size (actual {settings.xSize}):";
            YSizeLabel.Text = $"Y size (actual {settings.ySize}):";
            XStartLabel.Text = $"X start position (actual {settings.xStart}):";
            YStartLabel.Text = $"Y start position (actual {settings.yStart}):";
            tresholdValueLabel.Text = $"Size of K (actual {settings.tresHold}):";
            replicationLabel.Text = $"Replications (actual {settings.numberOfReplications}):";
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (this.simulationWorker.IsBusy)
            {
                this.simulationWorker.CancelAsync();
            } else
            {
                this._controller.ResetSimulation();
            }
            this.SetButtonToDefault();
        }

        private void SetButtonToDefault()
        {
            this.RunPauseButton.Text = "Start";
            this.StopButton.Enabled = false;
            this._controller.SetPauseClicked(false);
        }
    }
}
