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
        private int _xSize;
        // Vertikalna veľkosť plochy, na ktorej sa pohybuje robot.
        private int _ySize;
        // X súradnica, na ktorej robot začína.
        private int _startX;
        // Y súradnica, na ktorej robot začína.
        private int _startY;
        // Generátor náhodných čísel pre túto úlohu.
        public Random Generator { get; set; }
        // Pole bool hodnôt, v ktorom sa na pozicii udáva, či sa môže robot týmto smerom pohnúť v nasledujúcom kroku.
        //private bool[] _possibleDirections = new bool[] { false, false, false, false };
        private BitArray _possibleDirections = new BitArray(4);
        // Pamäťovo úspornejšia verzia
        //private BitArray _visitedNodes;
        // Časovo úspornejšia verzia
        private int[,] _visitedNodes;
        public int ActualIteration { get; set; } = 0;
        public RobotCompetition(int xSize, int ySize, int startX, int startY)
        {
            this._xSize = xSize;
            this._ySize = ySize;
            this._startX = startX;
            this._startY = startY;
            this.Generator = new Random();
        }
        // Metóda, ktorá v sebe zahŕňa stratégiu pohybu. Návratovou hodnotou je počet krokov, ktoré robot vykoná pred tým ako sa dostane do vrchola, kde už bol.
        // Jeho hlavnou stratégiou je pohnúť sa doprava a hore. V prípade ak sa zistí, že začína na mieste, kde tento je prioritný pohyb nie je možný, tak sa
        // bude pohybovať opačným smerom.
        public double runTestWithStrategy()
        {
            var numberOfMoves = -1;
            var actualX = _startX;
            var actualY = _startY;
            bool[,] visitedNodes = new bool[_xSize, _ySize];

            if (_xSize == 1 && _ySize == 1)
                return 0;

            bool goRightIfUCan = false;
            bool goUpIfUCan = false;
            // Podľa toho, kde sa robot nachádza sa nastavia premenné určujúce, či je možné použiť jeho prioritnú stratégiu, ktrou je ísť čo najviac vpravo, kým sa dá
            // a potom jeden krok hore a potom vľavo.
            if (actualX < _xSize - 1)
                goRightIfUCan = true;

            if (actualY < _ySize - 1)
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

                if (actualX < _xSize - 1 && goRightIfUCan && !needMoveHorizontal)
                {
                    ++actualX;
                    movedHorizontal = false;
                    if (actualX == _xSize - 1)
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
                        if (actualY < _ySize - 1 && goUpIfUCan)
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
            var actualX = _startX;
            var actualY = _startY;

            if (_xSize == 1 && _ySize == 1)
                return 0;
            // V pripade pamatovo uspornejsej verzie
            //_visitedNodes.SetAll(false);
            // Začinajúci vrchol sa nastaví na už navštívený.
            //_visitedNodes[actualY * _xSize + actualX] = true;

            // V časovo uspornejšej verzii.
            _visitedNodes[actualX, actualY] = ActualIteration;
            int chosenIndex = -1;
            // V nekonečnom cykle sa zisťujú smery, v ktorých sa robot môže pohnúť a dôjde k náhodnému výberu jedného zo smerov.
            while (true)
            {
                
                _possibleDirections.SetAll(false);
                // Je mozne ist vlavo
                if (actualX > 0)
                {
                    _possibleDirections[0] = true;
                }
                // Je mozne ist vpravo
                if (actualX < _xSize - 1)
                {
                    _possibleDirections[1] = true;
                }
                // Je mozne ist dole
                if (actualY > 0)
                {
                    _possibleDirections[2] = true;
                }
                // Je mozne ist hore
                if (actualY < _ySize - 1)
                {
                    _possibleDirections[3] = true;
                }

                // V rámci tohto cyklu generuje náhodný generátor od 0 po 3, kým nevygeneruje index do poľa, ktorý symbolizuje smer, ktorým je možné sa z daného
                // miesta pohnúť.
                while(true)
                {
                    chosenIndex = Generator.Next(4);
                    if (_possibleDirections[chosenIndex])
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
                if (_visitedNodes[actualX, actualY] != ActualIteration)
                {
                    // Ak tento vrchol ešte nebol navštívený, tak sa zvýši počet vykonaných krokov o 1 a vrchol sa označí za navštívený.
                    ++numberOfMoves;
                    _visitedNodes[actualX, actualY] = ActualIteration;
                }
                else
                {
                    // Ak vrchol už navštívený bol, dôjde k prerušeniu nekonečnéhu cyklu.
                    break;
                }
                /* // Pamatovo usporna verzia
                                if (!_visitedNodes[actualY * _xSize + actualX])
                                {
                                    // Ak tento vrchol ešte nebol navštívený, tak sa zvýši počet vykonaných krokov o 1 a vrchol sa označí za navštívený.
                                    ++numberOfMoves;
                                    _visitedNodes[actualY * _xSize + actualX] = true;
                                }
                                else
                                {
                                    // Ak vrchol už navštívený bol, dôjde k prerušeniu nekonečnéhu cyklu.
                                    break;
                                }*/
            }

            return numberOfMoves;
        }
        // Metóda nastaví všetky smery na false. Používa sa vždy po vykonaní kroku.
        private void ResetDirections()
        {
            /*for (int i = 0; i < _possibleDirections.GetLength(0); i++)
            {
                _possibleDirections[i] = false;
            }*/
        }
        // Znovu nastavenie hodnôt atribútov.
        public void Reset(int xSize, int ySize, int xStart, int yStart)
        {
            this._xSize = xSize;
            this._ySize = ySize;
            this._startX = xStart;
            this._startY = yStart;
            // Časovo úspornejšia verzia
            _visitedNodes = new int[xSize, ySize];
            // Pamäťovo úspornejšia verzia
            //_visitedNodes = new BitArray(_xSize * ySize);
        }
    }
}
