using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            int answer = 0;
            do
            {
                Console.WriteLine("press 1 for auto 2 for manual");

                int.TryParse(Console.ReadLine(), out answer);

            } while (answer < 1 || answer > 2);

            int answer2 = 0;
            bool result;
            do
            {

                Console.WriteLine("choose a pattern 1-5: Random= 0, Blinker=1,Toad=2,Beacon=3,Pulsar=4,Pentadeclathon=5");
                result = int.TryParse(Console.ReadLine(), out answer2);

            } while (answer2 < 0 || answer2 > 5 || !result);

            GameOfLife g = new GameOfLife((GameOfLife.Oscillators)answer2);
            if (answer == 1)
            {
                g.TimedGeneration();
                Console.ReadLine();

            }
            else
            {
                while (true)
                {
                    g.ManualGeneration();
                    Console.ReadLine();

                }
            }


        }
    }
}
