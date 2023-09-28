using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Net.Http.Headers;

namespace ToDoListApp
{
    public class DbMSSQL
    {
        private const string CONNECTION_STRING = 
        @"Data Source=DESKTOP-59QB9VC\VLADILEXA1;Initial Catalog=ToDoDb;Integrated Security=True;TrustServerCertificate=true";
        SqlConnection connection = new SqlConnection(CONNECTION_STRING);

        private void OpenDbConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        private void CloseDbConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public void AddTaskToDb(ToDoModel toDoModel)
        {
            try
            {
                OpenDbConnection();
                
                SqlCommand addTask = new SqlCommand
                    (
                    $"INSERT INTO TaskTable (Task, TaskStatus, DataTime) " +
                    $"VALUES ( N'{toDoModel.Task}','{toDoModel.TaskStatus}', '{toDoModel.Datetime:MM/dd/yy}')", 
                    connection);

                if (addTask.ExecuteNonQuery() == 1)
                {
                    Console.WriteLine("Your task add");
                }
                CloseDbConnection();
            }
            catch (Exception)
            {
                Console.WriteLine("Exeption add task");
            }

        }
        public void DeleteTaskInDb(int id)
        {
            try
            {
                OpenDbConnection();

                SqlCommand deleteTask = new SqlCommand
                    (
                    $"DELETE FROM TaskTable " +
                    $"WHERE Id = {id}",
                    connection);
                
                if (deleteTask.ExecuteNonQuery() == 1)
                {
                    Console.WriteLine("Your task delete");
                }
                CloseDbConnection();
            }
            catch (Exception)
            {
                Console.WriteLine("Exeption delete task");
            }
        }
        public void EditingTaskStatus(int id, bool taskStatus)
        {
            try
            {
                OpenDbConnection();

                SqlCommand EditTaskStatus = new SqlCommand
                    (
                    $"UPDATE TaskTable " +
                    $"SET TaskStatus = '{taskStatus}' " +
                    $"WHERE Id = {id}",
                    connection);

                if (EditTaskStatus.ExecuteNonQuery() == 1)
                {
                    Console.WriteLine("Your task status edit");
                }
                CloseDbConnection();
            }
            catch (Exception)
            {
                Console.WriteLine("Exeption task status edit");
            }
        }
        public void UppdateTaskInDb(int id, string task, bool taskStatus, DateTime date)
        {
            try
            {
                OpenDbConnection();

                SqlCommand EditTaskStatus = new SqlCommand
                    (
                    $"UPDATE TaskTable " +
                    $"SET Task = '{task}', TaskStatus = '{taskStatus}', DataTime = '{date}' " +
                    $"WHERE Id = {id}",
                    connection);

                if (EditTaskStatus.ExecuteNonQuery() == 1)
                {
                    Console.WriteLine("Your task uppdate");
                }
                CloseDbConnection();
            }
            catch (Exception)
            {
                Console.WriteLine("Exeption task uppdate");
            }
        }

        public List<ToDoModel> SelectTodoList()
        {
            List<ToDoModel> toDoModels = new List<ToDoModel>();
            
            try
            {
                OpenDbConnection();

                SqlCommand selectTask = new SqlCommand("SELECT * FROM TaskTable", connection);

                SqlDataReader reader = selectTask.ExecuteReader();

                while (reader.Read())
                {
                    
                        toDoModels.Add(new ToDoModel
                            ((int)reader.GetValue(0), 
                            (string)reader.GetValue(1), 
                            bool.Parse(reader.GetValue(2).ToString()), 
                            (DateTime)reader.GetValue(3)));
                    
                }

                CloseDbConnection();
            }
            catch(Exception)
            {
                Console.WriteLine("Exeption");
            }
            
            return toDoModels;
        }
    }
}
