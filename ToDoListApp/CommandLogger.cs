
namespace ToDoListApp
{
    public class CommandLogger
    {
        private string _command;
        private ToDoModel todo;
        private int Id;
        private string Task;
        private bool TaskStatus;
        private DateTime dateTime;
        private string[] _action;

        public CommandLogger(string command, string[] action)
        {
            _command = command;
            _action = action;
            
            var db = new Db();
            Id = db.nextID;
            logger();
        }
        private void todoInitialization()
        {
            todo = new ToDoModel(Id, Task, TaskStatus, dateTime);
        }
        private void parseId(string id)
        {
            Id = int.Parse(id);
        }
        private void parseTask(string task)
        {
            this.Task = task;
        }
        private void parseTStatus(string taskStatus)
        {
            this.TaskStatus = bool.Parse(taskStatus);
        }
        private void parseDateTime(string dateTime)
        {
            this.dateTime = DateTime.Parse(dateTime);
        }

        private void help()
        {
            Console.WriteLine();
            Console.WriteLine("Hello i'ts help for my ToDo;");
            Console.WriteLine();
            Console.WriteLine($"Write {Alias.add} 'your task'--'DataTime' to add task;");
            Console.WriteLine($"Write {Alias.delete} 'id task' to delete your task;");
            Console.WriteLine($"Write {Alias.done} 'id task'--'true or false' to change task status;");
            Console.WriteLine($"Write {Alias.uppdate} 'id task'--'your task'--'true or false'--'DateTime';");
            Console.WriteLine($"Write {Alias.vievCurrent} to view your current task;");
            Console.WriteLine($"Write {Alias.vievPlanned} to view your planned task;");
            Console.WriteLine($"Write {Alias.vievCompleted} to view your completed task;");

        }
        private void add()
        {
            parseTask(_action[0]);
            parseDateTime(_action[1]);
            todoInitialization();

            var db = new Db(todo);
            db.add();
        }
        private void delete()
        {
            parseId(_action[0]);
            todoInitialization();

            var db = new Db(todo);
            db.delete(Id);
        }
        private void done()
        {
            parseId(_action[0]);
            parseTStatus(_action[1]);
            todoInitialization();
            var db = new Db(todo);
            db.done(Id, TaskStatus);
        }
        private void uppdate()
        {
            parseId(_action[0]);
            parseTask(_action[1]);
            parseTStatus(_action[2]);
            parseDateTime(_action[3]);
            todoInitialization();

            var db = new Db(todo);
            db.uppdate(Id, Task, TaskStatus, dateTime);
        }
        private void vcurrent()
        {
            var db = new Db();
            db.vcurrent();
        }
        private void vplanned()
        {
            var db = new Db();
            db.vplanned();
        }
        private void vcompleted()
        {
            var db = new Db();
            db.vcompleted();
        }
        private void all()
        {
            var db = new Db();
            db.all();
        }

        private void logger()
        {
            switch (_command)
            {
                case "-help":
                    help();
                    break;
                case "-add":
                    add();
                    break;
                case "-delete":
                    delete();
                    break;
                case "-done":
                    done();
                    break;
                case "-uppdate":
                    uppdate();
                    break;
                case "-vcurrent":
                    vcurrent();
                    break;
                case "-vplanned":
                    vplanned();
                    break;
                case "-vcompleted":
                    vcompleted();
                    break;
                case "-all":
                    all();
                    break;
                default:
                    break;
            }
        }
    }
}
