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
        public string SetCommand(string setCommand)
        {
            return command[setCommand];
        }

        private static string help = Alias.help;
        private static string add = Alias.add;
        private static string delete = Alias.delete;
        private static string done = Alias.done;
        private static string uppdate = Alias.uppdate;
        private static string vievCurrent = Alias.vievCurrent;
        private static string vievPlanned = Alias.vievPlanned;
        private static string vievCompleted = Alias.vievCompleted;
        private static string all = Alias.all;            

        private Dictionary<string, string> command = new Dictionary<string, string>()
        {
            {help, "-help"},
            {add, "-add"},
            {delete, "-delete"},
            {done, "-done"},
            {uppdate, "-uppdate"},
            {vievCurrent, "-vcurrent"},
            {vievPlanned,"-vplanned"},
            {vievCompleted,"-vcompleted"},
            {all, "-all" }                      
        };
        

    }
}
