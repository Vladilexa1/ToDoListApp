using System.Text.Json;

namespace ToDoListApp
{
    public class Db
    {
        const string FILENAME = "DbJSON.json";
        private string json;

        public Db()
        {
            CreateDbJSONFile();
        }
        
        private void CreateDbJSONFile()
        {
            if (!File.Exists(FILENAME))
            {
                File.Create(FILENAME).Close();
            }
        }
        private void WriteSerializeTaskToDb(List<ToDoModel> toDos)
        {
            json = JsonSerializer.Serialize(toDos);

            File.WriteAllText(FILENAME, json);
        }
        public List<ToDoModel> DeserializeTaskInDb()
        {
            var reader = File.ReadAllText(FILENAME);
            if (reader != "")
            {
                return JsonSerializer.Deserialize<List<ToDoModel>>(reader);
            }
            return null;
        }
        
        public int GetNextId()
        {
            List<ToDoModel> toDos = DeserializeTaskInDb();
            return toDos.Count + 1;
        }
       
        public void AddTaskToDb(ToDoModel toDoModel) 
        {
            try
            {
                List<ToDoModel> toDos = DeserializeTaskInDb();
                toDos.Add(toDoModel);
                WriteSerializeTaskToDb(toDos);
                Console.WriteLine("Your task add");
            }
            catch (Exception)
            {
                Console.WriteLine("Exeption add task");
            }
            
        }
        public void DeleteTaskInDb(int id)  
        {
           List<ToDoModel> toDos = DeserializeTaskInDb();

            for (int i = 0; i < toDos.Count; i++)
            {
                if (toDos[i].Id == id)
                {
                    toDos.Remove(toDos[i]);
                    break;
                }
            }
            for (int i = 0; i < toDos.Count; i++)
            {
                toDos[i].Id = i+1;
            }
            WriteSerializeTaskToDb(toDos);
            Console.WriteLine("Your task delete");
        }
        public void EditingTaskStatus(int id, bool taskStatus)
        {
            List<ToDoModel> toDos = DeserializeTaskInDb();

            for (int i = 0; i < toDos.Count; i++)
            {
                if (toDos[i].Id == id)
                {
                    toDos[i].TaskStatus = taskStatus;
                    WriteSerializeTaskToDb(toDos);
                    break;
                }
            }
            Console.WriteLine("Your task done");
        }
        public void UppdateTaskInDb(int id, string task, bool taskStatus, DateTime date)
        {
            List<ToDoModel> toDos = DeserializeTaskInDb();

            for (int i = 0; i < toDos.Count; i++)
            {
                if (toDos[i].Id == id)
                {
                    toDos[i] = new ToDoModel(id, task, taskStatus, date);
                    WriteSerializeTaskToDb(toDos);
                    break;
                }
            }
            Console.WriteLine("Your task uppdate");
        }
       
       
    }
}
