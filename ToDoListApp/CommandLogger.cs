
namespace ToDoListApp
{
    public class CommandLogger
    {
        private string[] _action;
        private DbJSON db = new DbJSON();
        private DbMSSQL dbMSSQL = new DbMSSQL();
        List<ToDoModel> todo = new List<ToDoModel>();
        
        public CommandLogger(string command, string[] action)
        {
            _action = action;
           
            Logger(command);
        }
        public ToDoModel GetModel(int id, string task, bool taskStatus, DateTime dateTime)
        {
            ToDoModel toDoModel = new ToDoModel(id, task, taskStatus, dateTime);
            return toDoModel;
        }
        private int parseId(string id)
        {
            return int.Parse(id);
        }
        private string parseTask(string task)
        {
            return task;
        }
        private bool ParseTaskStatus(string taskStatus)
        {
            return bool.Parse(taskStatus);
        }
        private DateTime parseDateTime(string dateTime)
        {
            return DateTime.Parse(dateTime);
        }

        private void PrintHelp()
        {
            Console.WriteLine();
            Console.WriteLine("Hello i'ts help for my ToDo;");
            Console.WriteLine();
            Console.WriteLine($"Write -add 'your task'--'Date in format MM/DD/YY' to add task;");
            Console.WriteLine($"Write -delete 'id task' to delete your task;");
            Console.WriteLine($"Write -done 'id task'--'true or false' to change task status;");
            Console.WriteLine($"Write -update 'id task'--'your task'--'true or false'--'Date in format MM/DD/YY';");
            Console.WriteLine($"Write -vcurrent to view your current task;");
            Console.WriteLine($"Write -vplanned to view your planned task;");
            Console.WriteLine($"Write -vcompleted to view your completed task;");

        }
        private ToDoModel ConverteNewTaskToToDoModel(string[] action)
        {
            return new ToDoModel(db.GetNextId(), parseTask(action[0]), false, parseDateTime(action[1]));
        }
       
        private int GetIdToDeleteTask(string[] action)
        {
           return parseId(action[0]);
        }
        private void Logger(string command)
        {
           // todo = db.DeserializeTaskInDb();
            todo = dbMSSQL.SelectTodoList();
            switch (command)
            {
                case "-help":
                    PrintHelp();
                    break;
                case "-add":
                    dbMSSQL.AddTaskToDb(ConverteNewTaskToToDoModel(_action));
                    //db.AddTaskToDb(ConverteNewTaskToToDoModel(_action));
                    break;
                case "-delete":
                    //db.DeleteTaskInDb(GetIdToDeleteTask(_action));
                    dbMSSQL.DeleteTaskInDb(GetIdToDeleteTask(_action));
                    break;
                case "-done":
                    //db.EditingTaskStatus(parseId(_action[0]), ParseTaskStatus(_action[1]));
                    dbMSSQL.EditingTaskStatus(parseId(_action[0]), ParseTaskStatus(_action[1]));
                    break;
                case "-update":
                    //db.UppdateTaskInDb(parseId(_action[0]), parseTask(_action[1]), ParseTaskStatus(_action[2]), parseDateTime(_action[3]));
                    dbMSSQL.UppdateTaskInDb(parseId(_action[0]), parseTask(_action[1]), ParseTaskStatus(_action[2]), parseDateTime(_action[3]));
                    break;
                case "-vcurrent":
                    PrintTask.PrintCurrentTask(todo);
                    break;
                case "-vplanned":
                    PrintTask.PrintPlannedTask(todo);
                    break;
                case "-vcompleted":
                    PrintTask.PrintCompletedTask(todo);
                    break;
                case "-all":
                    PrintTask.PrintAllTask(todo);
                    break;
                default:
                    Console.WriteLine("Command not found, write '-help', to see command");
                    break;
            }
        }
    }
}
