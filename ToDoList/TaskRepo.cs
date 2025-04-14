using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ToDoList
{
    public class TaskRepo
    {
        private readonly string filePath = Configuration.FILE_PATH;

        /// <summary>
        /// Saves the given list of tasks to the JSON file with indentation.
        /// </summary>
        /// <param name="tasks">The list of tasks to save.</param>
        private void SaveTasks(List<Task> tasks)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string updatedJson = JsonSerializer.Serialize(tasks, options);
            File.WriteAllText(filePath, updatedJson);
        }

        /// <summary>
        /// Tries to convert a user-provided index (1-based) to a valid zero-based index.
        /// </summary>
        /// <param name="userIndex">The 1-based index input by the user.</param>
        /// <param name="tasks">The current list of tasks.</param>
        /// <param name="actualIndex">The resulting 0-based index if valid.</param>
        /// <returns>True if the index is valid, otherwise false.</returns>
        private bool TryGetIndex(int userIndex, List<Task> tasks, out int actualIndex)
        {
            actualIndex = userIndex - 1;
            if (actualIndex < 0 || actualIndex >= tasks.Count)
            {
                Console.WriteLine(string.Format(Configuration.INVALID_TASK_NUMBER, userIndex));
                return false;
            }
            return true;
        }

        /// <summary>
        /// Adds a new task to the list and saves it to the file.
        /// </summary>
        /// <param name="task">The task to add.</param>
        public void AddTask(Task task)
        {
            List<Task> tasks = AllTask();

            tasks.Add(task);

            SaveTasks(tasks);
        }

        /// <summary>
        /// Deletes the task at the specified user-provided index (1-based).
        /// </summary>
        /// <param name="index">The 1-based index of the task to delete.</param>
        public void DeleteTask(int index)
        {
            List<Task> tasks = AllTask();

            if (!TryGetIndex(index, tasks, out int actualIndex)) return;

            tasks.RemoveAt(actualIndex);

            SaveTasks(tasks);
        }

        /// <summary>
        /// Returns all tasks from the JSON file. If the file is missing or empty, returns an empty list.
        /// </summary>
        /// <returns>A list of all tasks.</returns>
        public List<Task> AllTask()
        {
            List<Task> tasks = new List<Task>();

            if (File.Exists(filePath))
            {
                string existingTasks = File.ReadAllText(filePath);
                if (!string.IsNullOrWhiteSpace(existingTasks))
                {
                    try
                    {
                        tasks = JsonSerializer.Deserialize<List<Task>>(existingTasks) ?? new List<Task>();
                    }
                    catch { }
                }
            }
            return tasks;
        }

        /// <summary>
        /// Updates the completion status of a task at the specified user-provided index (1-based).
        /// </summary>
        /// <param name="index">The 1-based index of the task to update.</param>
        /// <param name="isCompleted">The new completion status of the task.</param>
        public void UpdateTask(int index, bool isCompleted)
        {
            List<Task> tasks = AllTask();

            if (!TryGetIndex(index, tasks, out int actualIndex)) return;

            tasks[actualIndex].IsCompleted = isCompleted;

            SaveTasks(tasks);
        }

        /// <summary>
        /// Update the title of task
        /// </summary>
        /// <param name="index">The 1-based index of task to update.</param>
        /// <param name="title">The new title</param>
        public void UpdateTask(int index, string title)
        {
            List<Task> tasks = AllTask();

            if (!TryGetIndex(index, tasks, out int actualIndex)) return;

            tasks[actualIndex].Title = title;

            SaveTasks(tasks);
        }
    }
}
