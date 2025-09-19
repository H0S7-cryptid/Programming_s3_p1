using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConSty
{
    public partial class ConsoleStyle
    {
        private int GapLength_1HF;
        private int GapLength_2HF;
        
        // Конструкторы
        public ConsoleStyle()
        {
            Console.WindowWidth = 100;
            Console.WindowHeight = 30;
            Console.SetBufferSize(100, 30);
        }
        public ConsoleStyle(int H, int W)
        {
            Console.WindowWidth = W;
            Console.WindowHeight = H;
            Console.SetBufferSize(W, H);
        }

        // Функции для установки основных цветов
        private void SetDefColors()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        private void SetInvColors()
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
        }

        // Функция для создания строки с равномерно распределёнными наименованиями
        // и для получаения информации о границах вывода файлов
        private string CreateRoundedStr(List<string> words, int which_part, bool whitch_half)
        {
            int width = Console.WindowWidth / which_part + 1;
            int num_of_words = words.Count;
            int words_full_len = words.Sum(w => w.Length) + num_of_words + 2;

            int num_of_separators = words_full_len + 1;

            int[] sepPos = new int[num_of_separators];
            sepPos[0] = 0;
            sepPos[num_of_separators - 1] = width;

            for (int i = 1; i < num_of_separators - 1; i++)
            {
                sepPos[i] = i * width / num_of_words;
            }

            // Вместо запоминания позиций для разделителей-палок
            // мы записываем саму "ширину" столбца, в зависимости от того,
            // какую часть консоли мы хотим заполнить равными по ширине столбцами
            //       ||
            //       \/
            if (whitch_half)
            {
                GapLength_1HF = sepPos[1] - sepPos[0] - 1;
            }
            else
            {
                GapLength_2HF = sepPos[1] - sepPos[0] - 1;
            }

            // Далее код работает как и до этого

            char[] buffer = new char[width];
            for (int i = 0; i < width; i++)
            {
                buffer[i] = ' ';
            }

            for (int i = 0; i < num_of_separators; i++)
            {
                int pos = sepPos[i];
                if (pos < width)
                {
                    buffer[pos] = '\u2502';
                }
            }
            buffer[0] = '\u2551';
            buffer[width - 1] = '\u2551';

            for (int i = 0; i < num_of_words; i++)
            {
                int leftBound = sepPos[i] + 1;
                int rightBound = (i == num_of_words - 1)
                ? sepPos[i + 1] - 1
                : sepPos[i + 1];
                int segmentLength = rightBound - leftBound;
                string word = words[i];
                if (word.Length > segmentLength)
                {
                    word = word.Substring(0, segmentLength);
                }

                int start = leftBound + (segmentLength - word.Length) / 2;

                for (int j = 0; j < word.Length; j++)
                {
                    if (start + j < width)
                    {
                        buffer[start + j] = word[j];
                    }
                }
            }
            return new string(buffer);
        }

        // Функция для создания Самой верхней строки консоли
        public void WriteTopLine()
        {
            int count = 0;
            Console.BackgroundColor = ConsoleColor.DarkCyan;

            string[] WORDS = { "Левая", "Файл", "Диск", "Команды", "Правая" };

            foreach (string word in WORDS)
            {
                Console.Write("".PadRight(Console.WindowWidth / 25, ' '));
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(word[0]);
                Console.ForegroundColor = ConsoleColor.Black;
                for (int i = 1; i < word.Length; i++)
                {
                    Console.Write(word[i]);
                }
                count += word.Length + Console.WindowWidth / 25;
            }

            Console.Write("".PadRight(Console.WindowWidth - count - 4, ' '));
            SetDefColors();
            Console.Write("8:30");
            Console.ResetColor();
            Console.WriteLine();
        }

        // Функция для создания первой внутриблочной строки с содержимым католога
        public void WriteSecLine()
        {
            SetDefColors();

            List<string> words = new();
            words.Add("C: Имя");
            words.Add("Имя");
            words.Add("Имя");

            string line = CreateRoundedStr(words, 2, true);

            Console.Write(line[0]);
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 1; i < line.Length - 1; i++)
            {
                if (line[i] == '\u2502')
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(line[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                Console.Write(line[i]);
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(line[line.Length - 1]);

            words.Clear();
            words.Add("C: Имя");
            words.Add("Размер");
            words.Add("Дата");
            words.Add("Время");

            line = CreateRoundedStr(words, 2, false);

            Console.Write(line[0]);
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 1; i < line.Length - 3; i++)
            {
                if (line[i] == '\u2502')
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(line[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                Console.Write(line[i]);
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(line[line.Length - 1]);

            Console.ResetColor();
            Console.WriteLine();
        }

        // Функции для создания очертаний снизу и сверху
        public void DrawTopCurve()
        {
            SetDefColors();
            Console.Write("\u2554");
            for (int i = 1; i < (Console.WindowWidth / 4) - 3; i++)
            {
                Console.Write("\u2550");
            }
            Console.Write(" C:\\NC ");
            for (int i = 1; i < (Console.WindowWidth / 4) - 3; i++)
            {
                Console.Write("\u2550");
            }
            Console.Write("\u2557");
            Console.Write("\u2554");
            for (int i = 1; i < (Console.WindowWidth / 4) - 3; i++)
            {
                Console.Write("\u2550");
            }
            SetInvColors();
            Console.Write(" C:\\NC ");
            SetDefColors();
            for (int i = 1; i < (Console.WindowWidth / 4) - 5; i++)
            {
                Console.Write("\u2550");
            }
            Console.Write("\u2557");
            Console.WriteLine();
            Console.ResetColor();
        }
        public void DrawBottomCurve()
        {
            SetDefColors();
            Console.Write("\u255A");
            for (int i = 0; i < (Console.WindowWidth / 2) - 1; i++)
            {
                Console.Write("═");
            }
            Console.Write("\u255D");
            Console.Write("\u255A");
            for (int i = 0; i < (Console.WindowWidth / 2) - 3; i++)
            {
                Console.Write("═");
            }
            Console.Write("\u255D");
            Console.ResetColor();
        }

        // Геттеры для работы с частями консоли (её разделителями)
        public int GetSep1stHalf()
        {
            return GapLength_1HF;
        }
        public int GetSep2ndHalf()
        {
            return GapLength_2HF;
        }
    }

}
