using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Simulator_App.Controller;

namespace Simulator_App.Model
{
    class MonteCarloSimulation : Simulation
    {
        public double TresHold { get; set; }

        private RobotCompetition robotProblem = new RobotCompetition(5, 5, 0, 0);

        private double StrategyNumberOfMoves = -1;

        public MonteCarloSimulation(Controller.Controller controller, SimulationSettings defaultSettings)
        {
            this.Controller = controller;
            this.ApplySettings(defaultSettings);
            this.ReplicationsResult = new List<ReplicationResult>();
        }

        public override void BeforeReplication()
        {

        }

        public override bool AfterReplication()
        {
            var repResult = new ReplicationResult();
            ReplicationResult lastResult = null;

            repResult.CumulativeNumberOfMoves = ReplicationResult;
            repResult.CumulativeStrategyMoves = StrategyNumberOfMoves;
            if (ReplicationResult > SimulationSettings.TresHold)
                repResult.CumulativeMoreThanK = 1;

            if(this.ReplicationsResult.Count != 0)
            {
                lastResult = ReplicationsResult.Last();
                repResult.CumulativeNumberOfMoves += lastResult.CumulativeNumberOfMoves;
                repResult.CumulativeMoreThanK += lastResult.CumulativeMoreThanK;
                repResult.CumulativeStrategyMoves += lastResult.CumulativeStrategyMoves;
            }
            
            this.ReplicationsResult.Add(repResult);

            return this.Controller.AfterReplicationUpdate();
        }

        public override void DoReplication()
        {
            ReplicationResult = robotProblem.runTest();
            //System.Threading.Thread.Sleep(1);
        }

        public override SimulationStatus RunSimulation()
        {
            bool cancelPending = false;
            // V pripade ak pokracujeme v predchadzajucej simulacii, tak nevytvarame novu instanciu objektu.

            for (ActualReplication = ActualReplication; ActualReplication < NumberOfReplications; ActualReplication++)
            {
                BeforeReplication();
                DoReplication();
                cancelPending = AfterReplication();
                if (cancelPending)
                    break;
            }
            if (cancelPending)
                return SimulationStatus.CANCELED;

            return SimulationStatus.FINISHED;
        }

        public override void ApplySettings(SimulationSettings settings)
        {
            this.SimulationSettings = settings;
            this.NumberOfReplications = SimulationSettings.NumberOfReplications;
            this.TresHold = SimulationSettings.TresHold;
            this.ActualReplication = 0;
        }

        public override bool Reset()
        {
            this.ActualReplication = 0;
            this.ReplicationResult = 0;
            this.ReplicationsResult.Clear();
            return true;
        }

        public bool HasFinished()
        {
            return ActualReplication == NumberOfReplications;
        }

        public override void BeforeSimulation()
        {
            robotProblem.Reset(SimulationSettings.XSize, SimulationSettings.YSize,
                               SimulationSettings.XStart, SimulationSettings.YStart);
            StrategyNumberOfMoves = robotProblem.runTestWithStrategy();
        }

        public override void AfterSimulation()
        {
            throw new NotImplementedException();
        }

        public override List<ReplicationResult> GetReplicationsResult()
        {
            return this.ReplicationsResult;
        }
    }
}
