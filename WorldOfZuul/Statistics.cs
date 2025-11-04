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

        public static void ShowStatus()
        {                                                         //if pina la semn ? pina la : daca eadevarat face ce e inainte de :, daca e fals face ce e dupa :   
            Console.WriteLine($"You now have {Points} point{(Points == 1 ? "" : "s")}.");//ternary opperator pentru a adauga (s) la plural, precum ar fi if else
        }


    }
}
