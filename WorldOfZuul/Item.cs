using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfZuul
{
    public class Item
    {
        public string name;

        public string message;

        public Item(string name)
        {
            this.name = name;
            this.message = $"Normal {name}";
        }

        public Item(string name, string message)
        {
            this.name = name;
            this.message = message;
        }

        public void ShowMessage()
        {
            Console.WriteLine(message);
        }
    }
}
