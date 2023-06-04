using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp
{
    public class CommandLogger
    {
        private string _command;

        public CommandLogger(string command)
        {
            _command = command;
            logger();
        }

        private void help()
        {
            Console.WriteLine();
            Console.WriteLine("Hello i'ts help for my ToDo;");
            Console.WriteLine();
            Console.WriteLine("Write -add 'your task'--'DataTime' to add task;");
            Console.WriteLine("Write -delete 'id task' to delete your task;");
            Console.WriteLine("Write -done '+ or -' to change task status;");
            Console.WriteLine("Write -uppdate 'your task'--'id task'--'DateTime';");
            Console.WriteLine("Write -vcurent to view your current task;");
            Console.WriteLine("Write -vplaned to view your planned task;");
            Console.WriteLine("Write -vcompleted to view your completed task;");

        }
        private void add()
        {

        }
        private void delete()
        {

        }
        private void done()
        {

        }
        private void uppdate()
        {

        }
        private void vcurrent()
        {

        }
        private void vplanned()
        {

        }
        private void vcompleted()
        {

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
                case "-vcurent":
                    vcurrent();
                    break;
                case "-vplaned":
                    vplanned();
                    break;
                case "-vcompleted":
                    vcompleted();
                    break;
                default:
                    break;
            }
        }
    }
}
