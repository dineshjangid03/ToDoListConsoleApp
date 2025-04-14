using System;
/*
Requirements: 
Allow users to add tasks to the to-do list. 
Allow users to view all tasks. 
Mark tasks as completed. 
Delete tasks. 
Save and load the list of tasks to/from a file. 
You can create a webapp, 
DB should be in text file.
*/
namespace ToDoList
{
    class Program
    {

        private readonly View _view = new View();
        private readonly TaskService _taskService = new TaskService();

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Options();
        }

        public void Options()
        {
            _view.Home();

            while (true)
            {
                _view.Options();
                
                Console.Write(Configuration.YOUR_CHOICE);
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            _taskService.AddTask();
                            break;
                        case 2:
                            _taskService.ViewAllTask(); 
                            break;
                        case 3:
                            _taskService.ViewAllTask(true);
                            break;
                        case 4:
                            _taskService.ViewAllTask(false);
                            break;

                        case 5:
                            _taskService.UpdateTask();
                            break;
                            
                        case 6:
                            _taskService.DeleteTask();
                            break;
                            
                        case 7:
                            _view.Thank();
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine(Configuration.YELLOW_BOLD + Configuration.INVALID_CHOICE + Configuration.ANSI_RESET);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine(Configuration.YELLOW_BOLD + Configuration.INVALID_NUMBER + Configuration.ANSI_RESET);
                }
            }
        }

    }

}