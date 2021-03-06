using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulator_App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AppGUI());
            /*            var robComp = new Model.RobotCompetition(10, 10, 5, 5);
                        double sumOfMoves = 0;
                        int moreThanK = 0;
                        int numberOfIterations = 2000000;
                        double result = 0;
                        for (int i = 0; i < numberOfIterations; i++)
                        {
                            result = robComp.runTest();
                            sumOfMoves += result;
                            if (result > 1)
                                ++moreThanK;
                        }
                        Console.WriteLine((double)moreThanK / numberOfIterations);
                        Console.WriteLine((double)sumOfMoves / numberOfIterations);*/
        }
    }
}
