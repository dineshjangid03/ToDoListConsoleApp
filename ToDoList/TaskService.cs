using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ToDoList
{

    public class TaskService
    {
        private readonly TaskRepo _repo = new TaskRepo();
        private readonly View _view = new View();

        /// <summary>
        /// Prompts the user to enter a task title and adds the new task into file by calling repo.
        /// Allows cancellation by entering 'c' or 'C'.
        /// </summary>
        public void AddTask()
        {

            while (true)
            {
                Console.WriteLine(Configuration.C_FOR_CANCEL);
                Console.Write("Enter task title: ");
                string title = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(title))
                {
                    Console.WriteLine(Configuration.ENTER_VALID_INPUT);
                    continue;
                }

                if (title.ToLower() == "c") return;

                Task newTask = new Task
                {
                    Title = title,
                    IsCompleted = false
                };

                _repo.AddTask(newTask);
                Console.WriteLine(Configuration.GREEN_BOLD + Configuration.TASK_ADDED_SUCCESS + Configuration.ANSI_RESET);
                Thread.Sleep(100);
                break;
            }
        }

        /// <summary>
        /// Deletes a task from the provided list based on user selection.
        /// Shows the list if <paramref name="showTask"/> is true.
        /// initally <paramref name="showTask"/> this will be true so we will show list
        /// if we are recursive calling due to invalid input than no need ro show list sgain
        /// </summary>
        /// <param name="tasks">List of tasks to choose from.</param>
        /// <param name="showTask">Whether to display tasks before prompting.</param>
        public void DeleteTask(List<Task> tasks, bool showTask)
        {
            if (tasks.Count > 0)
            {
                if (showTask)
                {
                    _view.ViewTask(tasks);
                    Console.Write(Configuration.ENTER_TASK_NUMBER);
                }

                string input = Console.ReadLine();

                if(input == "c" || input == "C")
                {
                    return;
                }

                if (int.TryParse(input, out int index) && index <= tasks.Count)
                {
                    _repo.DeleteTask(index);
                    Console.WriteLine( Configuration.RED_BOLD + Configuration.TASK_DELETED_SUCCESS + Configuration.ANSI_RESET);
                    Thread.Sleep(100);
                }
                else
                {
                    Thread.Sleep(100);
                    Console.WriteLine(Configuration.C_FOR_CANCEL);
                    Console.Write(Configuration.ENTER_VALID_INPUT);
                    DeleteTask(tasks, false);
                }
            }
            else
            {
                Console.WriteLine(Configuration.NO_TASK_FOUND);
            }
        }

        /// <summary>
        /// Loads all tasks and initiates deletion flow with UI prompt.
        /// calling another method with list and true for showing data at initial
        /// added another method because need to recall in case of wrong input or any error
        /// </summary>
        public void DeleteTask()
        {
            List<Task> tasks = _repo.AllTask();
            DeleteTask(tasks, true);
        }

        /// <summary>
        /// Displays all tasks filtered by completion status.
        /// </summary>
        /// <param name="filter">True to show completed tasks; false for pending.</param>
        public void ViewAllTask(bool filter)
        {
            List<Task> tasks = _repo.AllTask();
            tasks = tasks.Where(t => t.IsCompleted == filter).ToList();
            _view.ViewTask(tasks);
            Console.Write(Configuration.ENTER_FOR_BACK);
            Console.ReadLine();
        }

        /// <summary>
        /// Displays all tasks without filtering.
        /// </summary>
        public void ViewAllTask()
        {
            List<Task> tasks = _repo.AllTask();
            _view.ViewTask(tasks);
            Console.Write(Configuration.ENTER_FOR_BACK);
            Console.ReadLine();
        }

        /// <summary>
        /// Allows the user to update a task from the provided list.
        /// Options include marking as completed/pending, editing the title,
        /// deleting the task, going back to the main menu, or updating another task.
        /// </summary>
        /// <param name="tasks">List of existing tasks to choose from.</param>
        /// <param name="showTask">If true, tasks will be displayed before prompting user input.</param>
        public void UpdateTask(List<Task> tasks, bool showTask)
        {
            if (tasks.Count > 0)
            {
                if (showTask)
                {
                    _view.ViewTask(tasks);
                    Console.Write(Configuration.ENTER_TASK_NUMBER);
                }

                string input = Console.ReadLine();

                if (int.TryParse(input, out int index) && index <= tasks.Count)
                {
                    string statusStr;
                    _view.EditTask();
                    Console.Write(Configuration.YOUR_CHOICE);
                    while (true)
                    {
                        statusStr = Console.ReadLine();
                        if (statusStr == "1" || statusStr == "2")
                        {
                            _repo.UpdateTask(index, (statusStr == "1"));
                            Console.WriteLine( Configuration.GREEN_BOLD + Configuration.TASK_UPDATED_SUCCESS + Configuration.ANSI_RESET);
                            Thread.Sleep(100);
                            break;
                        }
                        else if (statusStr == "3")
                        {

                            while (true)
                            {
                                Console.WriteLine(Configuration.C_FOR_CANCEL);
                                Console.Write("Enter task title: ");
                                string title = Console.ReadLine();

                                if (string.IsNullOrWhiteSpace(title))
                                {
                                    Console.WriteLine(Configuration.ENTER_VALID_INPUT);
                                    continue;
                                }

                                if (title.ToLower() == "c") return;

                                _repo.UpdateTask(index, title);
                                Console.WriteLine(  Configuration.GREEN_BOLD + Configuration.TASK_UPDATED_SUCCESS + Configuration.ANSI_RESET);
                                Thread.Sleep(100);
                                break;
                            }
                            break;
                        }
                        else if (statusStr == "4")
                        {
                            _repo.DeleteTask(index);
                            Console.WriteLine( Configuration.RED_BOLD + Configuration.TASK_DELETED_SUCCESS + Configuration.ANSI_RESET);
                            Thread.Sleep(100);
                            break;
                        }
                        else if (statusStr == "5" || statusStr == "6")
                        {
                            break;
                        }
                        Console.WriteLine(Configuration.INVALID_INPUT);
                        Console.Write(Configuration.ENTER_VALID_INPUT);
                    }
                    if(statusStr == "6")
                    {
                        return;
                    }
                    else if (statusStr == "5")
                    {
                        UpdateTask(tasks, true);
                    }
                }
                else
                {
                    Thread.Sleep(100);
                    Console.Write(Configuration.ENTER_VALID_INPUT);
                    UpdateTask(tasks, false);
                }
            }
            else
            {
                Console.WriteLine(Configuration.NO_TASK_FOUND);
            }
        }

        /// <summary>
        /// Loads all tasks and starts the update flow with UI prompt.
        /// </summary>
        public void UpdateTask()
        {
            List<Task> tasks = _repo.AllTask();
            UpdateTask(tasks, true);
        }
    }

}
