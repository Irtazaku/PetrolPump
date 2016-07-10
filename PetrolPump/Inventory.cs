using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetrolPump
{
    class Inventory
    {
        public static List<string> Name= new List<string>();
        public static List<string> Rate = new List<string>();

        public static void Add(string N, string R)
        {
            Name.Add(N);
            Rate.Add(R);
        }

        public static string GetRate(string N)
        {
            return Rate.ElementAt(Name.IndexOf(N));
        }
    }
}
