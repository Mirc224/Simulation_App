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

        public RobotCompetition(int xSize, int ySize, int startX, int startY)
        {
            this.xSize = xSize;
            this.ySize = ySize;
            this.startX = startX;
            this.startY = startY;
        }

        public double runTest()
        {
            var numberOfMoves = 0;
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
            visitedNodes[actualX, actualY] = true;
            List<char> possibleDirections = new List<char>(4);
            Random generator = new Random();
            int chosenIndex = -1;
            char chosenDir = '-';
            while (true)
            {
                possibleDirections.Clear();
                if (actualX > 0)
                {
                    possibleDirections.Add('l');
                }
                if (actualX < xSize - 1)
                {
                    possibleDirections.Add('r');
                }
                if (actualY > 0)
                {
                    possibleDirections.Add('d');
                }
                if (actualY < ySize - 1)
                {
                    possibleDirections.Add('u');
                }

                chosenIndex = generator.Next(possibleDirections.Count());
                chosenDir = possibleDirections[chosenIndex];

                switch (chosenDir)
                {
                    case 'l':
                        --actualX;
                        break;
                    case 'r':
                        ++actualX;
                        break;
                    case 'u':
                        ++actualY;
                        break;
                    case 'd':
                        --actualY;
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

    }
}
