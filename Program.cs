//using System;
using ConSty;
using PrintFileStruct;
using System.Runtime.Serialization.Formatters;
//using FileStruct;
//using PrintFileStruct;

namespace Практическое_занятие__1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleStyle k = new ConsoleStyle(50, 120);
            k.WriteTopLine();
            k.DrawTopCurve();
            k.WriteSecLine();
            PrintFile files = new PrintFile();

            for (int i = 0; i < 70; i++)
            {
                FileStruct.File F1 = new FileStruct.File($"Abbadon{i} ic", "18:33", "13.02.2002", "exe");
                files.AddFile(F1);
            }
            for (int i = 0; i < Console.WindowHeight - 8; i++)
            {
                string line = files.Print1stHalfOfConsoleLine(k.GetSep1stHalf(), i, true);
                Console.WriteLine(line);
            }

            Console.WriteLine();
            k.DrawBottomCurve();
            Console.ReadKey();
        }
    }
}
