using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Fortitude
{
    internal class Program
    {
        private const string realPass = "123";
        private static readonly DateTime timeStarted = DateTime.Now;
        private static string foundPassword;
        private static Boolean passFound = false;



        private static readonly string[] allCharacters =
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q",
            "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L",
            "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7",
            "8", "9", "0", "!", "@", "#", "$", "%", "^", "&", "*", "<", ">", "?"
        };

        private static readonly List<Thread> threads = new List<Thread>();
        private static readonly List<string> threadStartChar = new List<string>(); 

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
                var newThread = new Thread(FindPasswordMask);
                newThread.Name = i.ToString();
                threads.Add(newThread);
                threadStartChar.Add(allCharacters[i]);
                threads[i].Start();
            }
        }

        public static void FindPasswordMask()
        {
            string x = allCharacters[Convert.ToInt32(Thread.CurrentThread.Name)];
            FindPasswordWork(x);
        }

        public static void FindPasswordWork(string x)
        {
            if (CheckPassword(x))
            {
                Console.WriteLine("Time to Find: " + DateTime.Now.Subtract(timeStarted) + " seconds");
                Console.WriteLine("Password = " + x);
                passFound = true;
            }
            else if(passFound == false)
            {
                for (int i = 0; i < allCharacters.Count(); i++)
                {
                    string temp = x + allCharacters[i];
                    FindPasswordWork(temp);
                }
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