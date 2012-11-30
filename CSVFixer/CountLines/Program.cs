using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CountLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = string.Empty;
            var count = 0;
            do
            {
                line = Console.ReadLine();
                if (line == null) continue;
                if (!line.EndsWith("\""))
                {
                    line += Console.ReadLine();
                }
                count++;
            } while (line != null);
            Console.Out.WriteLine("Count: {0}", count);
        }
    }
}
