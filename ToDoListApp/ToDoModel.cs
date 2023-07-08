using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp
{
    public class ToDoModel
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public bool TaskStatus { get; set; }
        public DateTime Datatime { get; set; }

        public ToDoModel(int id, string task, bool taskStatus, DateTime dataTime)
        {
            this.Id = id;
            this.Task = task;
            this.TaskStatus = taskStatus;
            this.Datatime = dataTime;
        }

    }
}
