namespace ToDoList
{
    public class Configuration
    {
        public static readonly string FILE_PATH = "../../db.txt";
        
        public static readonly string ANSI_CYAN = "\u001b[36m";
        public static readonly string GREEN_BOLD = "\u001b[1;32m";
        public static readonly string ANSI_RESET = "\u001b[0m";
        public static readonly string CYAN_BOLD = "\u001B[1;36m";
        public static readonly string RED_BOLD = "\u001b[1;31m";
        public static readonly string YELLOW_BOLD = "\u001B[1;33m";

        public static readonly string INVALID_TASK_NUMBER = @"Invalid task number: {0}";
        public static readonly string INVALID_CHOICE = "Invalid choice, please try again.";
        public static readonly string INVALID_NUMBER = "Please enter a valid number!";

        public static readonly string C_FOR_CANCEL = "Press c for cancel";
        public static readonly string INVALID_INPUT = "Invalid input!";
        public static readonly string NO_TASK_FOUND = "No task found!";
        public static readonly string TASK_ADDED_SUCCESS = "Task added successfully!";
        public static readonly string TASK_UPDATED_SUCCESS = "Task updated successfully!";
        public static readonly string TASK_DELETED_SUCCESS = "Task deleted successfully!";
        
        public static readonly string ENTER_FOR_BACK = "Press enter for back: ";
        public static readonly string ENTER_TASK_NUMBER = "Please enter task number: ";
        public static readonly string ENTER_VALID_INPUT = "Please enter valid input: ";
        public static readonly string YOUR_CHOICE = "Enter your choice: ";
    }
}
