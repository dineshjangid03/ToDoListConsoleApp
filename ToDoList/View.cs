using System;
using System.Collections.Generic;
using System.Threading;

namespace ToDoList
{
    public class View
    {
        public void Home()
        {
            Console.WriteLine(" _____                                                _____ ");
            Console.WriteLine("( ___ )----------------------------------------------( ___ )");
            Console.WriteLine(" |   | " + Configuration.ANSI_CYAN + "  _____       ____          _     _     _     " + Configuration.ANSI_RESET + " |   | ");
            Console.WriteLine(" |   | " + Configuration.ANSI_CYAN + " |_   _|__   |  _ \\  ___   | |   (_)___| |_   " + Configuration.ANSI_RESET + " |   | ");
            Console.WriteLine(" |   | " + Configuration.ANSI_CYAN + "   | |/ _ \\  | | | |/ _ \\  | |   | / __| __|  " + Configuration.ANSI_RESET + " |   | ");
            Console.WriteLine(" |   | " + Configuration.ANSI_CYAN + "   | | (_) | | |_| | (_) | | |___| \\__ \\ |_   " + Configuration.ANSI_RESET + " |   | ");
            Console.WriteLine(" |   | " + Configuration.ANSI_CYAN + "   |_|\\___/  |____/ \\___/  |_____|_|___/\\__|  " + Configuration.ANSI_RESET + " |   | ");
            Console.WriteLine(" |___|                                                |___| ");
            Console.WriteLine("(_____)----------------------------------------------(_____)");

        }

        public void Options()
        {
            Console.WriteLine(Configuration.CYAN_BOLD);
            Console.WriteLine("╔═════════════════════════════╗");
            Thread.Sleep(30);
            Console.WriteLine("         CHOOSE OPTION");
            Thread.Sleep(30);
            Console.WriteLine("╚═════════════════════════════╝");
            Thread.Sleep(30);
            Console.WriteLine("1. Add task");
            Thread.Sleep(30);
            Console.WriteLine("2. View all task");
            Thread.Sleep(30);
            Console.WriteLine("3. View completed task");
            Thread.Sleep(30);
            Console.WriteLine("4. View pending task");
            Thread.Sleep(30);
            Console.WriteLine("5. Update Task");
            Thread.Sleep(30);
            Console.WriteLine("6. Delete tasks");
            Thread.Sleep(30);
            Console.WriteLine("7. Exit" + Configuration.ANSI_RESET);
        }

        public void Loading()
        {
            Console.WriteLine();
            Console.Write("Loading");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }
            Console.WriteLine("   Done!");
        }

        public void Thank()
        {
            Console.WriteLine();
            string str = "Thank You...!";
            foreach (char ch in str)
            {
                Console.Write(Configuration.GREEN_BOLD + ch);
                if (ch != ' ')
                {
                    Thread.Sleep(100);
                }
            }
            Console.WriteLine(Configuration.ANSI_RESET);
            Console.WriteLine();
        }

        public void ViewTask(List<Task> tasks)
        {
            Loading();

            if (tasks.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("█▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█");
                Thread.Sleep(30);
                Console.WriteLine($"{"  SR  ",-1}{"TITLE",-40}{"STATUS",10}");
                Thread.Sleep(30);
                Console.WriteLine("█════════════════════════════════════════════════════════════█");

                for (int i = 0; i < tasks.Count; i++)
                {
                    string plainStatus = tasks[i].IsCompleted ? "Completed" : "Pending";
                    string colorCode = tasks[i].IsCompleted ? Configuration.GREEN_BOLD : Configuration.RED_BOLD;
                    string status = colorCode + plainStatus.PadRight(10) + Configuration.ANSI_RESET;

                    Console.WriteLine($"  {i + 1,-3} {tasks[i].Title,-40} {status}");

                    if (i == tasks.Count - 1)
                    {
                        Thread.Sleep(30);
                        Console.WriteLine("█                                                            █");
                        Thread.Sleep(30);
                        Console.WriteLine("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
                    }
                    else
                    {
                        Thread.Sleep(30);
                        Console.WriteLine("█------------------------------------------------------------█");
                    }
                }
            }

            else
            {
                Console.WriteLine(Configuration.NO_TASK_FOUND);
            }

            Console.WriteLine();

            Thread.Sleep(100);

        }

        public void EditTask()
        {
            Console.WriteLine("1. Mark as completed");
            Thread.Sleep(30);
            Console.WriteLine("2. Mark as pending");
            Thread.Sleep(30);
            Console.WriteLine("3. Update title");
            Thread.Sleep(30);
            Console.WriteLine("4. Delete task");
            Thread.Sleep(30);
            Console.WriteLine("5. Back");
            Thread.Sleep(30);
            Console.WriteLine("6. Exit");
        }
    }
}
