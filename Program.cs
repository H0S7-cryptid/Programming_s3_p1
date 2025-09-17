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
            ConsoleStyle k = new ConsoleStyle(60, 120);
            k.WriteTopLine();
            k.DrawTopCurve();
            k.WriteSecLine();
            PrintFile files = new PrintFile();

            for (int i = 0; i < 70; i++)
            {
                FileStruct.File F1 = new FileStruct.File($"Abbadon{i} ic", "18:33", "13.02.2002", "exe");
                files.AddFile(F1);
            }
            //files.Print1stHalfOfConsole(k.GetSep1stHalf()[0], k.GetSep1stHalf()[1]);

            Console.WriteLine();
            k.DrawBottomCurve();
            Console.ReadKey();
        }
    }
}
