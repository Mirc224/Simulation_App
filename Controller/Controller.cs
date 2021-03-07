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
    // Štruktúra do ktorej sú ukladané vstupy z nastavení simulácie.
    public struct OptionsInput
    {
        public string xSize;
        public string ySize;
        public string xStart;
        public string yStart;
        public string numberOfReplications;
        public string tresHold;
        public string seed;
        public bool autoSeed;
        public bool errorOccured;
    }
    // Štruktúra obsahujúca údaje, ktoré majú byť vyobrazené užívateľovi pri aktualizácii výsledkov na grafickom rozhraní.
    public struct DataForUpdate
    {
        public double meanValue;
        public double probability;
        public double strategyMoves;
        public bool redrawGraphs;
        // Kopírovací konštruktor.
        public DataForUpdate(DataForUpdate othr)
        {
            this.meanValue = othr.meanValue;
            this.probability = othr.probability;
            this.redrawGraphs = othr.redrawGraphs;
            this.strategyMoves = othr.strategyMoves;
        }
    }
    // Trieda, ktorá zabezpečuje komunikáciu medzi grafickou a logickou časťou aplikácie.
    public class Controller
    {
        // Referencia na triedu zodpovendú za grafické rozhranie.
        private AppGUI _applicationGUI;
        // Séria, ktorá obsahuje dáta, ktoré majú byť zobrazované na grafe zobrazujúceho vývoj priemerného počtu vykonaných krokov.
        private LineSeries _lineSeriesMeanMoves;
        // Séria, ktorá obsahuje dáta, ktoré majú byť zobrazované na grafe zobrazujúceho pravdepodobnosť, že počet krokov je väčší ako zadaná hodnota.
        private LineSeries _lineSeriesProbability;
        // Inštancia simulácie, ktorá má byť vykonávaná.
        private Simulation _simulation;
        // Referencia na BackgroundWorkera, pomocou ktorého je signalizovaná a spracovaná požiadavka pre prekreslenie výstupnych grafických komponentov.
        private BackgroundWorker _simulationWorker;
        // Obsahuje posledné hodnoty získané zo simulácie.
        public DataForUpdate lastDataForUpdate = new DataForUpdate();
        // Obsahuje aktuálne nastavenia simulácie.
        private SimulationSettings _simulationSettings;
        // Informácia o stave simulácie.
        public Simulation.SimulationStatus SimulationStatus { get; set; } = Simulation.SimulationStatus.FINISHED;
        // Premenná, ktorá určuje, či bolo stlačené tlačidlo pauza.
        private bool PauseClicked;

        public Controller(AppGUI applicationGUI)
        {
            // Nasstavenia, ktoré sú aplikované pri spustení simulácie.
            _simulationSettings = new SimulationSettings
            {
                NumberOfReplications = 1000000,
                TresHold = 1,
                XSize = 10,
                YSize = 10,
                XStart = 0,
                YStart = 0,
                AutoSeed = true
            };

            this._applicationGUI = applicationGUI;
            this._applicationGUI.InitilaizeOptionsValues(_simulationSettings);
            this._simulation = new MonteCarloSimulation(this, _simulationSettings);
        }
        // Inicializácia simulácie. Ak bola simulácia ukončená alebo zrušená, dôjde k jej resetovaniu a nastaveniu sérií, do ktorých budú ukladané
        // výsledky zo simulácií.
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
        // Definovanie serií pre zobrazovanie dát.
        private void SetLineSeries()
        {
            _lineSeriesMeanMoves = new LineSeries();
            _lineSeriesMeanMoves.Title = "Mean number of moves";
            _lineSeriesProbability = new LineSeries();
            _lineSeriesProbability.Title = "Probability";
            _lineSeriesProbability.Color = OxyPlot.OxyColor.FromRgb(255, 0, 0);
        }
        // Metóda, ktorá predstavuje beh simulácie.
        public bool RunSimulation(BackgroundWorker simulationWorker)
        {
            // Nastaví sa referencia na background workera, ktorý sa stará o beh simulácie.
            this._simulationWorker = simulationWorker;
            // Vykonajú sa predsimulačné procedúry a nastaví sa stav simulácie na bežiaci.
            this._simulation.BeforeSimulation();
            this.SimulationStatus = Simulation.SimulationStatus.RUNNING;
            // Spustí sa simulácia, ktorej výstupom je jej stav po ukončení.
            this.SimulationStatus = this._simulation.RunSimulation();
            // Testuje sa, aký bol výsledný stav simulácie.
            if(this.SimulationStatus != Simulation.SimulationStatus.FINISHED)
            {
                // Ak nedošlo k dokončeniu simulácie ale k jej zrušeniu, tak sa testuje, či išlo len o prerušenie simulácie alebo
                // jej úplné zastavenie a podľa toho dôjde k prípadnému aktualizovaniu statusu simulácie.
                if (this.PauseClicked)
                {
                    this.SimulationStatus = Simulation.SimulationStatus.PAUSED;
                }
                    
            }
            else
            {
                Console.WriteLine(lastDataForUpdate.meanValue);
            }
            return true;
        }
        // Metóda, ktorá je volaná po vykonaní každej replikácie.
        public bool AfterReplicationUpdate()
        {
            // Zistí sa výsledok všetkých doposiaľ vykonaných replikácií.
            var replicationResultsList = this._simulation.GetReplicationsResult();
            int iterationsCount = replicationResultsList.Count;

            var lastReplication = replicationResultsList.Last();
            // Pre poslednú vykonanú replikáciu sa vypočíta priemerná hodnota a pravdepodobnosť.
            var meanValue = lastReplication.CumulativeNumberOfMoves / iterationsCount;
            var probability = (double)lastReplication.CumulativeMoreThanK / iterationsCount;
            var meanStrategy = lastReplication.CumulativeStrategyMoves / iterationsCount;

            // Testuje sa, či už bolo vykonaných 25% replikácií a ak áno, začnú sa zbierať dáta, ktoré buú zobrazené v grafoch.
            if (iterationsCount >= _simulationSettings.NumberOfReplications * 0.25)
            {
                this._lineSeriesMeanMoves.Points.Add(new OxyPlot.DataPoint(iterationsCount, meanValue));
                this._lineSeriesProbability.Points.Add(new OxyPlot.DataPoint(iterationsCount, probability));
            }
            // Nastavenie hodnôt pre šturkúru držiacu posledne vypočítané požadované štatistiky.
            this.lastDataForUpdate.meanValue = meanValue;
            this.lastDataForUpdate.probability = probability;
            this.lastDataForUpdate.strategyMoves = meanStrategy;
            this.lastDataForUpdate.redrawGraphs = false;
            // Po každých 5% replikácií dochádza k požiadavke na aktualizáciu stavu.
            if(iterationsCount % (int)(_simulationSettings.NumberOfReplications * 0.05) == 0)
                this._simulationWorker.ReportProgress(iterationsCount, lastDataForUpdate);
            // Testuje sa, či sa neobjavila požiadavka na zastavenie simulácie.
            if (this._simulationWorker.CancellationPending)
                return true;

            return false;
        }
        // Metóda, ktorá získa údaje o nastaveniach simulácie zo vstupu, pokúsi sa ich zparsrovať a použiť v simulácií.
        public bool TryApplySimulationSetings(ref OptionsInput input)
        {
            var parsedSettings = this.ParseSimulationSettings(ref input);

            if (parsedSettings == null)
                return false;

            this.SetSimulationSettings(parsedSettings);
            return true;
        }
        // Metóda, v ktorej dochádza k parsovaniu vstupov a v prípade chyby k priradeniu chybovej hlášky.
        private SimulationSettings ParseSimulationSettings(ref OptionsInput input)
        {
            int numberOfIterations = -1;
            int numberOfReplications = -1;
            int xSize = -1;
            int ySize = -1;
            int xStart = -1;
            int yStart = -1;
            int seed = -1;
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

            if(!input.autoSeed)
            {
                if (!Int32.TryParse(input.seed, out seed))
                {
                    input.errorOccured = true;
                    input.seed = "Error";
                }
            }

            if (input.errorOccured)
            {
                return null;
            }

            return new SimulationSettings { XSize = xSize,
                                            YSize = ySize,
                                            XStart = xStart, 
                                            YStart = yStart,
                                            NumberOfReplications = numberOfReplications,
                                            TresHold = tresHold,
                                            Seed = seed,
                                            AutoSeed = input.autoSeed};
        }
        // Nastavenie nových simulačných nastavení.
        private void SetSimulationSettings(SimulationSettings simSettings) 
        {
            this._simulationSettings = simSettings;
            this._simulation.ApplySettings(_simulationSettings);
        }
        // Metóda resetuje simuláciu a hodnoty potrebné pre nový beh simulácie.
        public void ResetSimulation()
        {
            lastDataForUpdate = new DataForUpdate();
            this._simulation.Reset();
            this.PauseClicked = false;
        }
        // Setter pre atribút symbolizujúci kliknutie na tlačidlo pauza.
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
