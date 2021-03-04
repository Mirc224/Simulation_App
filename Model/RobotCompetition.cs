using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator_App.Model
{
    class RobotCompetition
    {
        private int xSize { get; set; }
        private int ySize { get; set; }
        private int startX { get; set; }
        private int startY { get; set; }

        public Random Generator { get; set; }

        private bool[] PossibleDirections = new bool[] { false, false, false, false };
        public RobotCompetition(int xSize, int ySize, int startX, int startY)
        {
            this.xSize = xSize;
            this.ySize = ySize;
            this.startX = startX;
            this.startY = startY;
            this.Generator = new Random();
        }

        public double runTestWithStrategy()
        {
            var numberOfMoves = -1;
            var actualX = startX;
            var actualY = startY;
            bool[,] visitedNodes = new bool[xSize, ySize];
            for (int i = 0; i < visitedNodes.GetLength(0); i++)
            {
                for (int j = 0; j < visitedNodes.GetLength(1); j++)
                {
                    visitedNodes[i, j] = false;
                }
            }

            bool goRightIfUCan = false;
            bool goUpIfUCan = false;
            if (actualX < xSize - 1)
                goRightIfUCan = true;

            if (actualY < ySize - 1)
                goUpIfUCan = true;

            bool movedHorizontal = true;
            bool needMoveHorizontal = false;
            while(true)
            {
                if (!visitedNodes[actualX, actualY])
                {
                    visitedNodes[actualX, actualY] = true;
                    ++numberOfMoves;
                }
                else
                {
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

        public double runTest()
        {
            var numberOfMoves = 0;
            var actualX = startX;
            var actualY = startY;
            bool[,] visitedNodes = new bool[xSize, ySize];
            // Nastavime vsetky vrcholy ako este nenavstivene
            for (int i = 0; i < visitedNodes.GetLength(0); i++)
            {
                for (int j = 0; j < visitedNodes.GetLength(1); j++)
                {
                    visitedNodes[i, j] = false;
                }
            }
            visitedNodes[actualX, actualY] = true;
            int chosenIndex = -1;
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

                while(true)
                {
                    chosenIndex = Generator.Next(4);
                    if (PossibleDirections[chosenIndex])
                        break;
                }
                

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

                if (!visitedNodes[actualX, actualY])
                {
                    ++numberOfMoves;
                    visitedNodes[actualX, actualY] = true;
                }
                else
                {
                    break;
                }
            }

            return numberOfMoves;
        }

        private void ResetDirections()
        {
            for (int i = 0; i < PossibleDirections.GetLength(0); i++)
            {
                PossibleDirections[i] = false;
            }
        }

        public void Reset(int xSize, int ySize, int xStart, int yStart)
        {
            this.xSize = xSize;
            this.ySize = ySize;
            this.startX = xStart;
            this.startY = yStart;
        }
    }
}
