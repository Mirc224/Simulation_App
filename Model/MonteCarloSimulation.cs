using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Simulator_App.Controller;

namespace Simulator_App.Model
{
    // Trieda je potomkom triedy simulácia a ide triedu, ktorá sa stará o vykonanie statickej simulácie Monte Carlo.
    class MonteCarloSimulation : Simulation
    {
        // Atribút, ktorý udáva hraničnú hodnotu, po prekročení ktorej dôjde k nejakej udalosti.
        public double TresHold { get; set; }
        // Inštancia triedy robotCompetition, ktorá obsahuje implementáciu problému.
        private RobotCompetition _robotProblem = new RobotCompetition(5, 5, 0, 0);
        // Atribút v sebe drží hodnotu o počte vykonaných krokov pri použití stratégie. Stratégia je exaktná, takže sa nebude
        // počas replikácií meniť a preto je zbytočné ju za každým počítať nanovo.
        private double _strategyNumberOfMoves = -1;


        public MonteCarloSimulation(Controller.Controller controller, SimulationSettings defaultSettings)
        {
            this.Controller = controller;
            this.ApplySettings(defaultSettings);
            this.ReplicationsResult = new List<ReplicationResult>(20000001);
        }
        // Metóda, ktorá sa vykoná pred každou replikáciou.
        public override void BeforeReplication()
        {
            this._robotProblem.ActualIteration = ActualReplication + 1;
        }
        // Metóda, ktorá sa vykoná po každej replikácií.
        public override bool AfterReplication()
        {
            var repResult = new ReplicationResult();
            ReplicationResult lastResult = null;
            // Nastavia sa výsledky poslednej replikácie.
            repResult.CumulativeNumberOfMoves = ReplicationResult;
            repResult.CumulativeStrategyMoves = _strategyNumberOfMoves;
            if (ReplicationResult > SimulationSettings.TresHold)
                repResult.CumulativeMoreThanK = 1;

            if (ReplicationResult < MinReplicationResult)
                MinReplicationResult = ReplicationResult;
            if (ReplicationResult > MaxReplicationResult)
                MaxReplicationResult = ReplicationResult;
            // Testuje sa, či už nejaká replikácia prebehla.
            if(this.ReplicationsResult.Count != 0)
            {
                // Ak už nejaká replikácia prebehla, tak sa akumuluje súčet pozoroaných premenných.
                lastResult = ReplicationsResult.Last();
                repResult.CumulativeNumberOfMoves += lastResult.CumulativeNumberOfMoves;
                repResult.CumulativeMoreThanK += lastResult.CumulativeMoreThanK;
                repResult.CumulativeStrategyMoves += lastResult.CumulativeStrategyMoves;
            }
            // Akumulovaný výsledok poslednej replikácie je vložený do Listu.
            this.ReplicationsResult.Add(repResult);

            // V kontrolery sú vykonané po replikačné procedúry.
            return this.Controller.AfterReplicationUpdate();
        }
        // Metóda obsahuje procedúry, ktoré sa majú vykonať počas replikácie.
        public override void DoReplication()
        {
            // Vykoná sa jeden beh náhodného pokusu.
            ReplicationResult = _robotProblem.runTest();
            //System.Threading.Thread.Sleep(1);
        }
        // Metóda predstavujúca beh simulácie.
        public override SimulationStatus RunSimulation()
        {
            var stopW = new System.Diagnostics.Stopwatch();
            bool cancelPending = false;
            // Vykonávanie replikácií, kym nedosiahneme ich požadovaný počet.
            //stopW.Start();
            while(ActualReplication < NumberOfReplications)
            {
                ++ActualReplication;
                BeforeReplication();
                DoReplication();
                cancelPending = AfterReplication();
                if (cancelPending)
                    break;
            }
            // Ak bolo signalizované prerušenie simulácie, tak sa kontroluje, či náhodou už simulácia neskončila poslednú replikáciu.
            if (cancelPending)
                return ActualReplication != NumberOfReplications ? SimulationStatus.CANCELED : SimulationStatus.FINISHED;
            //stopW.Stop();
            //Console.WriteLine(stopW.Elapsed);
            return SimulationStatus.FINISHED;
        }
        // Metóda, v ktorej dôjde k aplikovaniu simulačných nastavení.
        public override void ApplySettings(SimulationSettings settings)
        {
            this.SimulationSettings = settings;
            this.NumberOfReplications = SimulationSettings.NumberOfReplications;
            this.TresHold = SimulationSettings.TresHold;
            this.ActualReplication = 0;
            if (settings.AutoSeed)
                this._robotProblem.Generator = new Random();
            else
                this._robotProblem.Generator = new Random(settings.Seed);
        }
        // Metóda zabezpečí vyrsetovanie simulácie pre jej prípadný ďalsí beh.
        public override bool Reset()
        {
            this.ActualReplication = 0;
            this.ReplicationResult = 0;
            this.MinReplicationResult = double.MaxValue;
            this.MaxReplicationResult = double.MinValue;
            if (SimulationSettings.AutoSeed)
            {
                this._robotProblem.Generator = new Random();
                //Console.WriteLine("Nastaveny random seed");
            }
            else
            {
                //Console.WriteLine($"Nastaveny seed {SimulationSettings.Seed}");
                this._robotProblem.Generator = new Random(SimulationSettings.Seed);
            }
            this.ReplicationsResult.Clear();
            return true;
        }
        // Vracia hodnotu, či už bola vykonaná posledná replikácia a teda simulácia skončila.
        public bool HasFinished()
        {
            return ActualReplication == NumberOfReplications;
        }
        // Metóda obsahujúca procedúry, ktoré majú byť vykonané pred začiatkom simulácie.
        public override void BeforeSimulation()
        {
            _robotProblem.Reset(SimulationSettings.XSize, SimulationSettings.YSize,
                               SimulationSettings.XStart, SimulationSettings.YStart);
            _strategyNumberOfMoves = _robotProblem.runTestWithStrategy();
        }
        // Metóda obsahuje procedúry, ktoré majú byť vykonané po skončení simulácie.
        public override void AfterSimulation()
        {
            throw new NotImplementedException();
        }
        // Getter na List obashujúci výsledné hodnoty predošlých replikácií.
        public override List<ReplicationResult> GetReplicationsResult()
        {
            return this.ReplicationsResult;
        }
    }
}
