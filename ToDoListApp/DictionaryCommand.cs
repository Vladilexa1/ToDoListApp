using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp
{
    class DictionaryCommand
    {
        public string GetCommand(string setCommand)
        {
            return command[setCommand];
        }

        private static string help = "-help";
        private static string add = "-add";
        private static string delete = "-delete";
        private static string done = "-done";
        private static string uppdate = "-update";
        private static string vievCurrent = "-vcurrent";
        private static string vievPlanned = "-vplanned";
        private static string vievCompleted = "-vcompleted";
        private static string all = "-all";            

        private Dictionary<string, string> command = new Dictionary<string, string>()
        {
            {help, "-help"},
            {add, "-add"},
            {delete, "-delete"},
            {done, "-done"},
            {uppdate, "-update"},
            {vievCurrent, "-vcurrent"},
            {vievPlanned,"-vplanned"},
            {vievCompleted,"-vcompleted"},
            {all, "-all" }                      
        };
    }
}
