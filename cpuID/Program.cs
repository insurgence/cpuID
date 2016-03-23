using System;
using System.IO;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cpuID
{
    class Program
    {

        static void Main(string[] args)
        {
            string path = @"cpuID.ini";

            if (!File.Exists(path))
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                Environment.Exit(-1);
            }

            string[] cpuID = File.ReadAllLines(path);

            foreach(string ship in cpuID)
            {
                string pathOfShip = "./" + ship + "/StartingMode.ini";
                if(!File.Exists(pathOfShip))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Error! Folder ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(ship);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("not found!");
                    Console.ResetColor();
                    break;
                }

                List<string> replace = new List<string>();

                string[] file = File.ReadAllLines(pathOfShip);

                foreach(string line in file)
                {
                    if (!line.Contains("CPU Id"))
                        replace.Add(line);
                    else
                        replace.Add("CPU Id = CCB");
                }

                File.WriteAllLines(pathOfShip, replace);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ship + "...ok");
                Console.ResetColor();
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
