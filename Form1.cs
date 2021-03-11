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
    /*
     * Predstavuje triedu, ktorá má na starosti GUI. Obsahuje graficke prvky a spravuje eventy. Tiež sa v nej nachádza BackgroundWorker, ktorý sa stará o vykresľovanie grafu
     * podľa nastavených parametrov.
     */
    public partial class AppGUI : Form
    {
        // Referencia na kontroler, ktorý sprostredkuje komunikáciu medzi
        private Controller.Controller _controller;
        // Referencia na triedu SimulationResultView, ktorá sa stará o zobrazovanie výsledkov simuláacie.
        private View.SimulationResultsView SimResultView;
        // Referencia na triedu SimulationOptionsView, ktorá v sebe zahŕňa grafické vstupy pre nastavenia simulácie.
        private View.SimulationOptionsView SimOptionsView;
        // Konštruktor triedy. V ňom dochádza k vytvoreniu inštancii SimulationResultsView a SimulationOptionsView, kde sú ako parametre zaslané grafické prvky.
        public AppGUI()
        {
            InitializeComponent();
            this.SimResultView = new View.SimulationResultsView(new OxyPlot.WindowsForms.PlotView[] {SimulationGraph,
                                                                ProbabilityGraph }, new Label[] {
                                                                MeanValueLabel,
                                                                MinValueLabel,
                                                                MaxValueLabel,
                                                                ProbabilityLabel,
                                                                StrategyMovesLabel});

            this.SimOptionsView = new View.SimulationOptionsView(new Label[] { XSizeLabel, 
                                                                               YSizeLabel,
                                                                               XStartLabel,
                                                                               YStartLabel,
                                                                               TresholdLabel,
                                                                               ReplicationsLabel,
                                                                               SeedLabel,
                                                                               PreheatingLabel,
                                                                               RecordIntervalLabel},
                                                                 new TextBox[] { XSizeInput,
                                                                                 YSizeInput,
                                                                                 XStartInput,
                                                                                 YStartInput,
                                                                                 TresholdInput,
                                                                                 ReplicationsInput,
                                                                                 SeedInput,
                                                                                 PreheatingInput,
                                                                                 RecordIntervalInput},
                                                                                 AutoSeedCheck);
            this._controller = new Controller.Controller(this);
        }
        // Metóda ktorú vykonáva BackgroundWorker po jeho vytvorení.
        private void SimulationWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Najskôr dôjde k inicializácii simulácie.
            this._controller.InitilizeSimulation(SimResultView);
            // Nasleduje zavolanie metódy na spustenie simulácie v kontrolery, kde je ako parameter zaslaná referencia na backgroundworkera, aby bolo možné zistiť,
            // či je požadované predčasné ukončenie simulácie.
            this._controller.RunSimulation(this.simulationWorker);
            // Po skončení simulácie sa z kontrolera získajú posledne inicializované dáta a výsledok je zobrazený na výstupe.
            var lastData = new DataForUpdate(this._controller.lastDataForUpdate);
            lastData.redrawGraphs = true;
            this.simulationWorker.ReportProgress(0, lastData);
            
            // Vyhodnocuje sa, či došlo k predčasnému skončeniu simulácie.
            if(this.simulationWorker.CancellationPending)
            {
                // V prípade, že došlo k predčasnému ukončeniu simulácie, zisťuje sa či došlo k jej úplnému zastaveniu alebo len k jej pozastaveniu.
                if (this._controller.SimulationStatus != Model.Simulation.SimulationStatus.FINISHED)
                    e.Cancel = true;
            }
        }
        // Metóda, ktorú vykonáva backgroundworker po nahlásení zmeny stavu. Obsahuje dáta, ktoré sa majú zobraziť na výstupe.
        private void SimulationWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            DataForUpdate data = (DataForUpdate)e.UserState;
            this.SimResultView.Update(data);
        }
        // Metóda, ktorá sa zavolá po ukončení úlohy background workera.
        private void SimulationWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Testuje sa, či bola simulácia ukončená prirodzene, alebo došlo k prerušeniu jej behu.
            if(e.Cancelled)
            {
                // Ak bola simulácia len pozastavená, pozmení sa text tlačidla z paused na continue.
                if (this._controller.SimulationStatus == Model.Simulation.SimulationStatus.PAUSED)
                    this.RunPauseButton.Text= "Continue";
                else
                {
                    // V prípade ak došlo k úplnému stopnutiu simulácie, tak sa prepíše tlačidlo na štart a kontroler zabepečí vyresetovanie simulácie a seba samého.
                    this.RunPauseButton.Text = "Start";
                    this._controller.ResetSimulation();
                    this.StopButton.Enabled = false;
                }
            } 
            else
            {
                // Ak simulácia nebola násilne zrušená, dochádza k nastaveniu hodnôt tlačidiel na základnú hodnotu.
                this.SetButtonToDefault();
            }
            
        }
        // Metóda, ktorá sa spustí po kliknutí na tlačidlo slúžiace na spúšťanie alebo pozastavenie simulácie.
        private void RunPauseButton_Click(object sender, EventArgs e)
        {
            // Testuje sa, či už beží nejaká simulácia.
            if(!simulationWorker.IsBusy)
            {
                // Ak žiadna simulácia nebeží, jej zastavenia a vykonajú sa úkony potrebné pre to, aby bolo možné zaznamenať žiadosť o pozastavenie simulácie
                // a spustí sa backgroundworker, ktorý sa stará o simuláciu.
                RunPauseButton.Text = "Pause";
                StopButton.Enabled = true;
                this._controller.SetPauseClicked(false);
                simulationWorker.RunWorkerAsync();
            } else
            {
                // Ak nejaká simulácia beží, nastavia sa hodnoty na grafických komponentoch a taktiež premenné v kontrolery, ktoré slúžia na to, aby bolo neskôr
                // možné pokračovať v simulácii. Na záver dôjde k žiadosti o zastavenie simulácie.
                this._controller.SetPauseClicked(true);
                RunPauseButton.Text = "Continue";
                this.simulationWorker.CancelAsync();
            }
        }
        // Metóda, ktorá získa zadané vstupy z panela nastavení símulácie.
        public OptionsInput GetSettingsInput()
        {
            return SimOptionsView.GetOptionsInput();
        }
        // Metóda, ktorá sa spustí po kliknutí na tlačidlo Confirm. V rámci nej dôjde k získaniu vstupov pre nastavenie simulácie a ak boli zadané správne údaje,
        // tak dôjde k ich použitiu v simulácii. Ak došlo k nejakej chybe pri parsovaní, je chybová hláška vypísaná do jednotlivých polí nastavení, v ktorých
        // došlko k chybe.
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
        // Metóda, ktorá nastaví zobrazované hodnoty v paneli nastavení na základe aktuálnych nastavení simulácie.
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
                preheating = settings.Preheating.ToString(),
                recordInterval = settings.RecordInterval.ToString(),
                errorOccured = false
            };
            SimOptionsView.SetOptionsInputText(data);
            SimOptionsView.SetOptionsLablesText(data);
        }
        // Metóda, ktorá sa spustí po kliknutí na tlačidlo stop. V nej sa zisťuje, či nejaká simulácia beží a ak beží je vynútené jej zastavenie a je nastavený príznak
        // pre požadovanie jej ukončenia.
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
            this._controller.SimulationStatus = Model.Simulation.SimulationStatus.CANCELED;
        }
        // Nastaví pôvodnú hodnotu tlačidiel a ich atribútov.
        private void SetButtonToDefault()
        {
            this.RunPauseButton.Text = "Start";
            this.StopButton.Enabled = false;
            this._controller.SetPauseClicked(false);
        }
        // Metóda, ktorá sa vykoná po zmene hodnoty checkboxu hovoriaceho o použití random seedu pre beh simulácie.
        private void AutoSeedCheck_CheckedChanged(object sender, EventArgs e)
        {
            SimOptionsView.RandomSeedCheckboxToggle();
        }
    }
}
