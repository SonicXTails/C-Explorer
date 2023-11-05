using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer
{
    static class Arrows
    {
        public static int Arrow(int max, int NumForArrows)
        {
            NumForArrows = NumForArrows + max - 1;

            int pos = max;                                                  // Позиция стрелки.
            int Max_pos = max;                                              // Максимальное ограничение.
            int Min_pos = NumForArrows;

            ConsoleKeyInfo key;
            do
            {
                Console.SetCursorPosition(0, pos);                          // Ставим курсор на 0,pos, где pos = положению стрелки
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("→");                                     // Стрелка
                Console.ForegroundColor = ConsoleColor.White;

                key = Console.ReadKey(true);                                // Считываем кнопку и не выводим ее на консоль

                Console.SetCursorPosition(0, pos);                          // Ставим курсор на 0,pos, где pos = положению стрелки, для удаления
                Console.WriteLine("  "); // Убираем стрелку

                if (key.Key == ConsoleKey.DownArrow && pos != Min_pos)      // Если кнопка - вниз + позиция не равна минимальной то...
                    pos++;
                else if (key.Key == ConsoleKey.UpArrow && pos != Max_pos)
                    pos--;
                else if (key.Key == ConsoleKey.Escape)
                    Program.Main();
            } while (key.Key != ConsoleKey.Enter);
            return pos;
        }

    }
}
