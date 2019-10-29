using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2_10005924
{
    class Algorithm
    {
        public double[] Numbers { get; set; } = new double[500];

        int rndMin = -10;
        int rndMax = 10;

        public Algorithm()
        {
            Random rnd = new Random();
            for (int i = 0; i < Numbers.Length; i++)
            {
                Numbers[i] = Math.Round(rnd.NextDouble() * (rndMax - rndMin) + rndMin, 2);
            }
        }

        //Method for displaying an array to the user
        public static void Display<T>(T[] Numbers)
        {
            int myMod = 0;
            foreach (T i in Numbers)
            {
                myMod += 1;
                Console.Write(i +"\t");
                if (myMod % 10 == 0)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
