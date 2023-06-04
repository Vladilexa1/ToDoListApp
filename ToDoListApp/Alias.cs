using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp
{
    public class Alias
    {
        //public static string help = "-help";
        public static string add = "-add";
        public static string delete = "-delete";
        public static string done = "-done";
        private static string uppdate = "-uppdate";
        private static string vievCurrent = "-vcurent";
        private static string vievPlanned = "-vplaned";
        private static string vievCompleted = "-vcompleted";
        public static string help { get; private set; } = "-help";

        public void setHelp(string alias)
        {
           
        }


    }
}
