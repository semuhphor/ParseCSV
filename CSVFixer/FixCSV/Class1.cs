using System;
using System.IO;
using CSVParser;

namespace FixCSV
{
    class Class1
    {
        static void Main(string[] args)
        {
            string line = string.Empty;
            var parser = new Parser();
            using (var fo = File.CreateText("new.csv"))
            {
                do
                {
                    line = Console.ReadLine();
                    if (line == null) continue;
                    if (!line.EndsWith("\""))
                    {
                        line += Console.ReadLine();
                    }
                    var parsed = parser.ParseLine(line);
                    if (line != parsed)
                    {
                        Console.Out.WriteLine("Change:\r\nOLD:\t{0}\r\nNEW:\t{1}'\r\n\r\n", line, parsed);
                        ;
                    }
                    fo.WriteLine(parsed);
                } while (line != null);
                fo.Flush();
                fo.Close();
            }
        }
    }
}
