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

        // Конструктор
        public PrintFile()
        {
            files = new List<FileStruct.File>();
            conHeight = Console.WindowHeight - 8;
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

        // Теперь вместо правой и левой границы функция работает сразу с шириной столбца
        // Также функция возвращает строку в соответствии с вертикальной координатой относительно положения в консоли
        public string Print1stHalfOfConsoleLine(ConsoleStyle CONS, int NegativeHeightPos, bool partOfConsole)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Cyan;

            int maxLengthOfExt = files.Any() ? files.Max(item => item.GetType().Length) : 0;

            string result = "";

            // Количество столбцов расчитывается как выбор между true и false:
            // количество столбцов будет 3, если передано true, а если false - 4
            // Следовательно и сами значения представляют собой обрабатываемые части консоли
            int maxCols = partOfConsole ? 3: 4;
            result += "\u2551";

            int[] gaps = CONS.GetSep1stHalf();
            for (int j = 0; j < maxCols; j++)
            {
                int gapLenght = gaps[j];
                if (NegativeHeightPos == 0 && j == 0)
                {
                    result += "..".PadRight(gapLenght, ' ');
                    result += (j == maxCols - 1 ? "\u2551" : "\u2502");
                    continue;
                }

                int posToPrint = j * conHeight + NegativeHeightPos;

                // Если нам нечего вставить в столбец имён и расширений, мы пропускаем этот момент, заполняя пропуск пробелами
                // и выставляя, в зависимости от места заполнения, нужный разделитель
                if (posToPrint >= files.Count())
                {
                    result += " ".PadRight(gapLenght, ' ');
                    result += (j == maxCols - 1 ? "\u2551" : "\u2502");
                    continue;
                }
                if (gapLenght < files[posToPrint].GetName().Length + maxLengthOfExt + 1)
                {
                    //Обрезаем имя
                    string w = files[posToPrint].GetName().Substring(0, gapLenght - maxLengthOfExt - 1);
                    w = w.Remove(w.Length - 1) + "~";

                    result += w + " ";
                    result += files[posToPrint].GetType().PadLeft(gapLenght - w.Length - 1, ' ');
                    result += (j == maxCols - 1 ? "\u2551" : "\u2502");
                }
                else
                {
                    result += files[posToPrint].GetName().PadRight(gapLenght - maxLengthOfExt, ' ') + " " +
                        files[posToPrint].GetType() + (j == 2 ? "\u2551" : "\u2502");
                }
            }
            return result;
        }


    }
}
