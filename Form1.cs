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
        private View.SimulationResultsView SimResultView;
        private View.SimulationOptionsView SimOptionsView;
        public AppGUI()
        {
            InitializeComponent();
            this.SimResultView = new View.SimulationResultsView(SimulationGraph,
                                                                ProbabilityGraph,
                                                                MeanValueLabel,
                                                                ProbabilityLabel,
                                                                StrategyMovesLabel);

            this.SimOptionsView = new View.SimulationOptionsView(new Label[] { XSizeLabel, 
                                                                               YSizeLabel,
                                                                               XStartLabel,
                                                                               YStartLabel,
                                                                               TresholdLabel,
                                                                               ReplicationsLabel,
                                                                               SeedLabel},
                                                                 new TextBox[] { XSizeInput,
                                                                                 YSizeInput,
                                                                                 XStartInput,
                                                                                 YStartInput,
                                                                                 TresholdInput,
                                                                                 ReplicationsInput,
                                                                                 SeedInput},
                                                                                 AutoSeedCheck);
            this._controller = new Controller.Controller(this);
        }

        private void SimulationWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this._controller.InitilizeSimulation(SimResultView);
            this._controller.RunSimulation(this.simulationWorker);
            var lastData = new Controller.DataForUpdate(this._controller.lastDataForUpdate);
            lastData.redrawGraphs = true;
            this.simulationWorker.ReportProgress(0, lastData);
            
            if(this.simulationWorker.CancellationPending)
            {
                if (this._controller.SimulationStatus != Model.MonteCarloSimulation.SimulationStatus.FINISHED)
                    e.Cancel = true;
            }
        }

        private void SimulationWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            DataForUpdate data = (DataForUpdate)e.UserState;
            this.SimResultView.Update(data);
        }

        private void SimulationWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled)
            {
                if (this._controller.SimulationStatus == Model.MonteCarloSimulation.SimulationStatus.PAUSED)
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
                this._controller.SetPauseClicked(true);
                this.simulationWorker.CancelAsync();
                RunPauseButton.Text = "Continue";
            }
        }
        
        public OptionsInput GetSettingsInput()
        {
            return SimOptionsView.GetOptionsInput();
        }

        private void OptConfirmButton_Click(object sender, EventArgs e)
        {
            var settings = this.GetSettingsInput();
            this._controller.TryApplySimulationSetings(ref settings);
            if(settings.errorOccured)
            {
                this.SimOptionsView.SetOptionsInputText(settings);
            }
            else
            {
                this.SimOptionsView.SetOptionsLablesText(settings);
            }
        }

        public void InitilaizeOptionsValues(Model.SimulationSettings settings)
        {
            var data = new OptionsInput
            {
                xSize = settings.XSize.ToString(),
                ySize = settings.YSize.ToString(),
                xStart = settings.XStart.ToString(),
                yStart = settings.YStart.ToString(),
                numberOfReplications = settings.NumberOfReplications.ToString(),
                tresHold = settings.TresHold.ToString(),
                errorOccured = false
            };
            SimOptionsView.SetOptionsInputText(data);
            SimOptionsView.SetOptionsLablesText(data);
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
            this._controller.SimulationStatus = Model.MonteCarloSimulation.SimulationStatus.CANCELED;
        }

        private void SetButtonToDefault()
        {
            this.RunPauseButton.Text = "Start";
            this.StopButton.Enabled = false;
            this._controller.SetPauseClicked(false);
        }

        private void AutoSeedCheck_CheckedChanged(object sender, EventArgs e)
        {
            SimOptionsView.RandomSeedCheckboxToggle();
        }
    }
}
