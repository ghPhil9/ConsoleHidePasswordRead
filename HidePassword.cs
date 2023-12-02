using System;
using System.Text;

namespace ConsoleApp1
{
    internal class HidePassword
    {
        internal static string Read()
        {
            StringBuilder sb = new StringBuilder();
            Console.Write("Введите пароль: ");

            while (true)
            {
                char key = Console.ReadKey(true).KeyChar;

                // Удаление символа
                if (key == (char)ConsoleKey.Backspace)
                {
                    if (sb.Length != 0) sb.Remove(sb.Length - 1, 1);
                    else continue;

                    // Смещение каретки с очисткой символа
                    RemoveSymbol();

                    continue;
                }

                // Сохранение пароля
                if (key == (char)ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }

                // Скрываем символ и сохраняем его
                Console.Write("*");
                sb.Append(key);
            }

            string password = sb.ToString();
            // Показываем считанный пароль. Нужно убрать для анонимности
            Console.WriteLine($"Ваш пароль: {password}");
            return password;
        }

        private static void RemoveSymbol()
        {
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            Console.Write(' ');
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }
    }
}
