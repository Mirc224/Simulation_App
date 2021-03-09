using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Simulator_App.Model
{
    // Trieda, ktorá v sebe zahŕňa atribúty a metódy pre riešenie úlohy Monte Carlo o počte krokov, ktoré robot na hracej ploche vykoná.
    class RobotCompetition
    {
        // Horiznontálna veľkosť plochy, na ktorej sa pohybuje robot.
        private int xSize { get; set; }
        // Vertikalna veľkosť plochy, na ktorej sa pohybuje robot.
        private int ySize { get; set; }
        // X súradnica, na ktorej robot začína.
        private int startX { get; set; }
        // Y súradnica, na ktorej robot začína.
        private int startY { get; set; }
        // Generátor náhodných čísel pre túto úlohu.
        public Random Generator { get; set; }
        // Pole bool hodnôt, v ktorom sa na pozicii udáva, či sa môže robot týmto smerom pohnúť v nasledujúcom kroku.
        private bool[] PossibleDirections = new bool[] { false, false, false, false };
        public RobotCompetition(int xSize, int ySize, int startX, int startY)
        {
            this.xSize = xSize;
            this.ySize = ySize;
            this.startX = startX;
            this.startY = startY;
            this.Generator = new Random();
        }
        // Metóda, ktorá v sebe zahŕňa stratégiu pohybu. Návratovou hodnotou je počet krokov, ktoré robot vykoná pred tým ako sa dostane do vrchola, kde už bol.
        // Jeho hlavnou stratégiou je pohnúť sa doprava a hore. V prípade ak sa zistí, že začína na mieste, kde tento je prioritný pohyb nie je možný, tak sa
        // bude pohybovať opačným smerom.
        public double runTestWithStrategy()
        {
            var numberOfMoves = -1;
            var actualX = startX;
            var actualY = startY;
            bool[,] visitedNodes = new bool[xSize, ySize];
            // Nastavenie všetkých hodnôt poľa na hodnotu false, symbolizujúcu, že robot tento vrchol ešte nenavštívil.
            /*for (int i = 0; i < visitedNodes.GetLength(0); i++)
            {
                for (int j = 0; j < visitedNodes.GetLength(1); j++)
                {
                    visitedNodes[i, j] = false;
                }
            }*/

            bool goRightIfUCan = false;
            bool goUpIfUCan = false;
            // Podľa toho, kde sa robot nachádza sa nastavia premenné určujúce, či je možné použiť jeho prioritnú stratégiu, ktrou je ísť čo najviac vpravo, kým sa dá
            // a potom jeden krok hore a potom vľavo.
            if (actualX < xSize - 1)
                goRightIfUCan = true;

            if (actualY < ySize - 1)
                goUpIfUCan = true;

            bool movedHorizontal = true;
            bool needMoveHorizontal = false;
            // V cykle beží prechod po jednotlivých vrcholoch hracej plochy.
            while(true)
            {
                if (!visitedNodes[actualX, actualY])
                {
                    // Ak ešte vo vrchole na pozícii actualX a actualY nebol, nastaví sa hodnota na true, znamenajúcu, že vrchol bol navštívený a počítadlo sa zvýši o 1.
                    visitedNodes[actualX, actualY] = true;
                    ++numberOfMoves;
                }
                else
                {
                    // Ak sa dostal do vrcholu, kde už bol, dôjde k prerušeniu nekonečnej slučky.
                    break;
                }

                if (actualX < xSize - 1 && goRightIfUCan && !needMoveHorizontal)
                {
                    ++actualX;
                    movedHorizontal = false;
                    if (actualX == xSize - 1)
                        goRightIfUCan = false;
                    continue;
                } else
                {
                    if(!goRightIfUCan && movedHorizontal && actualX > 0)
                    {
                        --actualX;
                        if (actualX == 0)
                        {
                            goRightIfUCan = true;
                            needMoveHorizontal = true;
                        }
                        continue;
                    } 
                    else
                    {
                        if (actualY < ySize - 1 && goUpIfUCan)
                        {
                            ++actualY;
                            movedHorizontal = true;
                            needMoveHorizontal = false;
                            continue;
                        }
                        else
                        {
                            if (actualY > 0)
                            {
                                --actualY;
                                movedHorizontal = true;
                                needMoveHorizontal = false;
                                continue;
                            }
                        }
                    }
                    break;
                }
            }
            return numberOfMoves;
        }
        // Metóda obsahujúca pohyb robota bez stratégie, len na zákalde náhody. Výstupom metódy je počet vykonaných krokov.
        public double runTest()
        {
            var numberOfMoves = 0;
            var actualX = startX;
            var actualY = startY;
            //bool[,] visitedNodes = new bool[xSize, ySize];
            BitArray visitedNodes = new BitArray(xSize* ySize);
            // Začinajúci vrchol sa nastaví na už navštívený.
            visitedNodes[actualX * xSize + actualY] = true;
            int chosenIndex = -1;
            // V nekonečnom cykle sa zisťujú smery, v ktorých sa robot môže pohnúť a dôjde k náhodnému výberu jedného zo smerov.
            while (true)
            {
                this.ResetDirections();
                // Je mozne ist vlavo
                if (actualX > 0)
                {
                    PossibleDirections[0] = true;
                }
                // Je mozne ist vpravo
                if (actualX < xSize - 1)
                {
                    PossibleDirections[1] = true;
                }
                // Je mozne ist dole
                if (actualY > 0)
                {
                    PossibleDirections[2] = true;
                }
                // Je mozne ist hore
                if (actualY < ySize - 1)
                {
                    PossibleDirections[3] = true;
                }

                // V rámci tohto cyklu generuje náhodný generátor od 0 po 3, kým nevygeneruje index do poľa, ktorý symbolizuje smer, ktorým je možné sa z daného
                // miesta pohnúť.
                while(true)
                {
                    chosenIndex = Generator.Next(4);
                    if (PossibleDirections[chosenIndex])
                        break;
                }
                
                // Vykonanie pohybu podľa zvoleného smeru.
                switch (chosenIndex)
                {
                    case 0:
                        --actualX;
                        break;
                    case 1:
                        ++actualX;
                        break;
                    case 2:
                        --actualY;
                        break;
                    case 3:
                        ++actualY;
                        break;
                    default:
                        break;
                }
                // Test, či už vrchol, do ktorého sme sa teraz dostali nebol navštívený.
                if (!visitedNodes[actualX * xSize + actualY])
                {
                    // Ak tento vrchol ešte nebol navštívený, tak sa zvýši počet vykonaných krokov o 1 a vrchol sa označí za navštívený.
                    ++numberOfMoves;
                    visitedNodes[actualX * xSize + actualY] = true;
                }
                else
                {
                    // Ak vrchol už navštívený bol, dôjde k prerušeniu nekonečnéhu cyklu.
                    break;
                }
            }

            return numberOfMoves;
        }
        // Metóda nastaví všetky smery na false. Používa sa vždy po vykonaní kroku.
        private void ResetDirections()
        {
            for (int i = 0; i < PossibleDirections.GetLength(0); i++)
            {
                PossibleDirections[i] = false;
            }
        }
        // Znovu nastavenie hodnôt atribútov.
        public void Reset(int xSize, int ySize, int xStart, int yStart)
        {
            this.xSize = xSize;
            this.ySize = ySize;
            this.startX = xStart;
            this.startY = yStart;
        }
    }
}
