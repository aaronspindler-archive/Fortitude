using System;
using System.Collections.Generic;
using System.Threading;

namespace Fortitude
{
    internal class Program
    {
        private const string realPass = "password123";
        private static Random gen = new Random();
        private static DateTime timeStarted = DateTime.Now;
        private static string foundPassword;



        private static readonly char[] allCharacters =
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q',
            'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
            'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '1', '2', '3', '4', '5', '6', '7',
            '8', '9', '0', '!', '@', '#', '$', '%', '^', '&', '*', '<', '>', '?'
        };

        private static readonly List<Thread> threads = new List<Thread>();

        private static void Main()
        {
            InitializeProgram();
            FindPassword();
            Console.ReadLine();
        }

        public static void FindPassword()
        {
            for (int i = 0; i < allCharacters.Length; i++)
            {
                var newThread = new Thread(FindPasswordMask) {Name = Convert.ToString(i)};
                threads.Add(newThread);
                threads[i].Start();
            }
        }

        public static void FindPasswordMask()
        {
            string x = Convert.ToString(allCharacters[Convert.ToInt32(Thread.CurrentThread.Name)]);
            FindPasswordRecurse(x);
        }

        public static void FindPasswordRecurse(string x)
        {
            if (CheckPassword(x))
            {
                Console.WriteLine("Time to Find: " + DateTime.Now.Subtract(timeStarted) + " seconds");
                Console.WriteLine("Password = " + x);
            }
            else
            {
                
            }
        }


        public static bool CheckPassword(string passwordToCheck)
        {
            return passwordToCheck == realPass;
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