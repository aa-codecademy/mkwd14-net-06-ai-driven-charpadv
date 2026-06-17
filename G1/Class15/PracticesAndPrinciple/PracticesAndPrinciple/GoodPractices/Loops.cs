using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticesAndPrinciple.GoodPractices
{
    internal class Loops
    {
        public List<string> Names = new List<string> { "Alice", "Bob", "Charlie", "David", "Eve" };

        public void PrintNames()
        {
            //BAD EXAMPLE:
            for (int counter = 0; counter < Names.Count; counter++)
            {
                if (Names[counter].Length == Names.Count)
                {
                    Console.WriteLine(Names[counter]);
                }
            }

            int listCount = Names.Count;
            //GOOD EXAMPLE:
            foreach (string name in Names)
            {
                if (name.Length == listCount)
                {
                    Console.WriteLine(name);
                }
            }
        }

        public void PrintAlice()
        {
            //BAD EXAMPLE:
            foreach (string name in Names)
            {
                if (name == "Alice")
                 {
                      Console.WriteLine(name);
                }
            }

            //GOOD EXAMPLE:
            foreach (string name in Names)
            {
                if (name == "Alice")
                {
                    Console.WriteLine(name);
                        break; // Exit the loop after finding "Alice"
                }
            }
        }
    }
}
