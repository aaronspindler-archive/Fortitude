using System;
using System.Threading;

namespace Fortitude
{
    internal class Program
    {
        private char[] allCharacters =
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q',
                'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
                'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '1', '2', '3', '4', '5', '6', '7',
                '8', '9', '0', '!', '@', '#', '$', '%', '^', '&', '*', '<', '>', '?'
            };

        private static void Main()
        {
            InitializeProgram();
            string realPass = "password123";

            Console.ReadLine();
        }

        public static void MakePassword()
        {
            
        }

        public static void CheckPassword()
        {
        }

        public static void InitializeProgram()
        {
            Console.Title = ("Fortitude");
            DrawSeparator();
            Console.WriteLine("Welcome to Fortitude!");
            DrawSeparator();
        }

        public static void DrawSeparator()
        {
            var worker = new Thread(DrawSeparatorWork);
            worker.Start();
            worker.Join();
        }

        private static void DrawSeparatorWork()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("=");
            }
        }
    }
}