using ConSty;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PrintFileStruct
{
    public class PrintFile
    {
        private List<FileStruct.File> files;
        private int conHeight;
        private bool NoMoreElem;

        // Конструктор
        public PrintFile()
        {
            files = new List<FileStruct.File>();
            conHeight = Console.WindowHeight - 8;
            NoMoreElem = false;
        }

        // Геттер для работы со списком
        public List<FileStruct.File> GetFiles()
        {
            return files;
        }

        // Метод для добавления файлов
        public void AddFile(FileStruct.File file)
        {
            files.Add(file);
        }

        public void Print1stHalfOfConsole(int leftBorder, int rightBorder)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Cyan;

            int maxLengthOfExt = files.Any() ? files.Max(item => item.GetType().Length) : 0;
            int gapLenght = rightBorder - leftBorder - 1 - maxLengthOfExt;

            if (NoMoreElem)
            {
                /*Console.Write(" ".PadRight(gapLenght + 1 + maxLengthOfExt, ' ') + "\u2502" +
                    " ".PadRight(gapLenght + 1 + maxLengthOfExt, ' ') + "\u2502" +
                    " ".PadRight(gapLenght + 1 + maxLengthOfExt, ' ') + "\u2502");
                Console.Write("\u2551");*/
                //continue;
                //return "";
            }

            string result = "";
            int maxCols = 3;

            for (int i = 0; i < conHeight; i++)
            {
                result += "\u2551";
                for (int j = 0; j < maxCols; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        result += "..".PadRight(gapLenght + maxLengthOfExt, ' ');
                        result += "\u2502";
                        continue;
                    }

                    int posToPrint = j * conHeight + i;

                    if (posToPrint >= files.Count())
                    {
                        NoMoreElem = true;
                        break;
                    }

                    if (gapLenght < files[posToPrint].GetName().Length)
                    {
                        string w = files[posToPrint].GetName().Substring(0, gapLenght);
                        w = w.Remove(w.Length - 1) + "~";
                        result += w + " " + files[posToPrint].GetType().PadRight(gapLenght - 1, ' ') +
                            (j == maxCols - 1 ? "\u2551" : "\u2502");
                    }
                    else
                    {
                        result += files[posToPrint].GetName().PadRight(gapLenght - 1, ' ') + " " +
                            files[posToPrint].GetType() + (j == 2 ? "\u2551" : "\u2502");
                    }
                }
                Console.WriteLine(result);
                result = "";
            }
        }


    }
}
