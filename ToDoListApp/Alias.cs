using System;
using System.Collections.Generic;

namespace ToDoListApp
{
    public class Alias
    {
        public static string help { get; private set; } = "-help";
        public static string add { get; private set; } = "-add";
        public static string delete { get; private set; } = "-delete";
        public static string done { get; private set; } = "-done";
        public static string uppdate { get; private set; } = "-uppdate";
        public static string vievCurrent { get; private set; } = "-vcurrent";
        public static string vievPlanned { get; private set; } = "-vplanned";
        public static string vievCompleted { get; private set; } = "-vcompleted";
        public static string all { get; private set; } = "-all";
    }
}
