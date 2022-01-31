using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class TruckTour
    {
        static int _entries;
        static Queue<int[]> _pumps;
        static void Main()
        {
            _entries = int.Parse(Console.ReadLine() ?? string.Empty);
            _pumps = new Queue<int[]>();

            for (int entry = 0; entry < _entries; entry++)
                _pumps.Enqueue(Console.ReadLine()?.Split(' ').Select(int.Parse).ToArray());

            for (int entry = 0; entry < _entries; entry++)
            {
                if (IsSolution())
                {
                    Console.WriteLine(entry);
                    break;
                }
                int[] startingPump = _pumps.Dequeue();
                _pumps.Enqueue(startingPump);
            }
        }

        static bool IsSolution()
        {
            int tankFuel = 0;
            bool foundAnswer = true;

            for (int entry = 0; entry < _entries; entry++)
            {
                int[] currPump = _pumps.Dequeue();
                tankFuel += currPump[0] - currPump[1];
                if (tankFuel < 0)
                    foundAnswer = false;
                _pumps.Enqueue(currPump);
            }

            if (foundAnswer)
                return true;
            else
                return false;
        }
    }
}
