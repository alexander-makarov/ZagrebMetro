using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroNetwork;

namespace MetroNetworkReader
{
    class MetroNetworkReaderProgram
    {
        private static void Main(string[] args)
        {
            if (CheckTheArguments(args))
            {
                var filePath = args.First();
                var metroNetwork = ReadMetroNetworkFromAFile(filePath);
                if (metroNetwork != null)
                {
                    Console.WriteLine("Metro network has been read:");
                    Console.Write(metroNetwork.ToString());
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        public static MetroNetworkGraph ReadMetroNetworkFromAFile(string filePath)
        {
            try
            {
                var metroNetworkString = File.ReadAllText(filePath);

                var metroNetwork = new MetroNetworkGraph();
                metroNetwork.ReadFromString(metroNetworkString);

                return metroNetwork;
            }
            catch (Exception exc)
            {
                Console.WriteLine("Can't read data from '{0}' - {1}: {2}!", filePath, exc.GetType(), exc.Message);
                return null;
            }
        }

        private static bool CheckTheArguments(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("You must specify a file with data about metro network <metroNetworkFile>!");
                return false;
            }
            else if (args.Length > 1)
            {
                Console.WriteLine("You specified more than one argument. If you input a filepath that contains whitespaces use \"<metroNetworkFile>\"!");
                return false;
            }

            return true;
        }
    }


}
