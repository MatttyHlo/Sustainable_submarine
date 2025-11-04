using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfZuul
{
    public static class Statistics
    {
        public static int Points { get; private set; } = 0;
        public static void AddPoints()
        {
            Points++;
        }

        public static void Reset()
        {
            Points = 0;
        }
    }
}
