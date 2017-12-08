using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandsberryAndJames.ConsoleEfficientRandomArrayAlgorithm.AssumeThatAvailable
{
    public static class RandomProcessor
    {
        private static readonly Random Rand = new Random();

        public static int Random(int min, int max)
        {
            while (true)
            {
                var val = Rand.Next(min - 10, max + 10);

                if (val >= min && val <= max)
                    return val;
            }
        }
    }
}