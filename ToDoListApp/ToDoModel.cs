using System;
using System.Collections.Generic;

namespace ToDoListApp
{
    public class ToDoModel
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public bool TaskStatus { get; set; }
        public DateTime Datetime { get; set; }

        public ToDoModel(int id, string task, bool taskStatus, DateTime dateTime)
        {
            this.Id = id;
            this.Task = task;
            this.TaskStatus = taskStatus;
            this.Datetime = dateTime;
        }

    }
}
