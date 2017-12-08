using System;
using System.Collections.Generic;
using System.Linq;
using LandsberryAndJames.ConsoleEfficientRandomArrayAlgorithm.AssumeThatAvailable;

namespace LandsberryAndJames.ConsoleEfficientRandomArrayAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = GetRandoms(1, 52);

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        public static int[] GetRandoms(int min, int max)
        {
            var outpuths = new HashSet<int>();
            var elements = ((max - min) + 1);

            while (outpuths.Count < elements)
            {
                outpuths.Add(RandomProcessor.Random(min, max));
            }

            return outpuths.ToArray();
        }
    }
}