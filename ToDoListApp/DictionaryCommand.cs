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
        private static string help = Alias.help;
        private static string add = "-add";
        private static string delete = "-delete";
        private static string done = "-done";
        private static string uppdate = "-uppdate";
        private static string vievCurrent = "-vcurent";
        private static string vievPlanned = "-vplaned";
        private static string vievCompleted = "-vcompleted";

        

        public Dictionary<string, string> command = new Dictionary<string, string>()
        {
            {help, "-help"},
            {add, "-add"},
            {delete, "-delete"},
            {done, "-done"},
            {uppdate, "-uppdate"},
            {vievCurrent, "-vcurrent"},
            {vievPlanned,"-vplanned"},
            {vievCompleted,"-vcompleted"}
        };
        

    }
}
