using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp
{
    public static class PrintTask
    {
        public static void PrintCurrentTask(List<ToDoModel> toDos)
        {
            for (int i = 0; i < toDos.Count; i++)
            {
                if (toDos[i].Datetime == DateTime.Now.Date)
                {
                    ConsolePrintTask(toDos, i);
                }
            }
        }
        public static void PrintPlannedTask(List<ToDoModel> toDos)
        {
            for (int i = 0; i < toDos.Count; i++)
            {
                if (toDos[i].Datetime > DateTime.Now.Date)
                {
                    ConsolePrintTask(toDos, i);
                }
            }
        }
        public static void PrintCompletedTask(List<ToDoModel> toDos)
        {
            for (int i = 0; i < toDos.Count; i++)
            {
                if (toDos[i].TaskStatus)
                {
                    ConsolePrintTask(toDos, i);
                }
            }
        }
        public static void PrintAllTask(List<ToDoModel> toDos)
        {
            for (int i = 0; i < toDos.Count; i++)
            {
                ConsolePrintTask(toDos, i);
            }
        }
        private static void ConsolePrintTask(List<ToDoModel> toDos, int i)
        {
            Console.WriteLine(toDos[i].Id + " " + toDos[i].Task + " " + toDos[i].TaskStatus + " " + toDos[i].Datetime.Date.ToShortDateString());
        }
    }
}
