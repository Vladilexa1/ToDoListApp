using System.Text.Json;

namespace ToDoListApp
{
    public class Db
    {
        const string FILENAME = "DbJSON.json";
        private string json;
        private List<ToDoModel> todoListWrite = new List<ToDoModel>();
        private ToDoModel toDoModel;

        public int nextID { get; private set; }
       
        public Db() // конструктор для присвоенияы следующего ID
        {
            existsFile();
            nextId();  
        }
        public Db(ToDoModel todoModel)
        {
            this.toDoModel = todoModel;
            existsFile();
            setId();
        }
        private void setId()
        {
            reader();
            int ID = 1;
            foreach (var item in todoListWrite)
            {
                item.Id = ID;
                ID++;
            }
            writeSerialize();
        }

        private void nextId()
        {
            reader();
            nextID = todoListWrite.Count + 1;
        }
        private void existsFile()
        {
            if (File.Exists(FILENAME))
            {
                return;
            }
            else
            {
                File.Create(FILENAME);
            }
        }






        private void writeSerialize()
        {
            json = JsonSerializer.Serialize(todoListWrite);

            File.WriteAllText(FILENAME, json);
        }
        private void reader()
        {
            var reader = File.ReadAllText(FILENAME);
            if (reader != "")
            {
                todoListWrite = JsonSerializer.Deserialize<List<ToDoModel>>(reader);
            }
        }
        private void writeTask(int i)
        {
           Console.WriteLine(todoListWrite[i].Id + " " + todoListWrite[i].Task + " " + todoListWrite[i].TaskStatus + " " + todoListWrite[i].Datetime.Date.ToShortDateString());
        }





        public void add() // читаем данные с json, если он пустой, записываем текущие значения
        {
            reader();

            todoListWrite.Add(toDoModel);

            writeSerialize();
            Console.WriteLine("Your task add");
        }

        public void delete(int id)  // читаем, ищем наш id, удаляем со списка, заново сериализируем
        {
            reader();

            for (int i = 0; i < todoListWrite.Count; i++)
            {
                if (todoListWrite[i].Id == id)
                {
                    todoListWrite.Remove(todoListWrite[i]);
                    writeSerialize();
                   
                    Console.WriteLine("Your task delete");
                   
                    break;
                }
            }
        }
        public void done(int id, bool taskStatus)
        {
            reader();

            for (int i = 0; i < todoListWrite.Count; i++)
            {
                if (todoListWrite[i].Id == id)
                {
                    todoListWrite[i].TaskStatus = taskStatus;

                    writeSerialize();

                    Console.WriteLine("Your task done");

                    break;
                }
            }
        }
        public void uppdate(int id, string task, bool taskStatus, DateTime date)
        {
            reader();

            for (int i = 0; i < todoListWrite.Count; i++)
            {
                if (todoListWrite[i].Id == id)
                {
                    todoListWrite[i] = new ToDoModel(id, task, taskStatus, date);
                    writeSerialize();
                    Console.WriteLine("Your task uppdate");
                    break;
                }
            }
        }
        public void vcurrent()
        {
            reader(); 

            for (int i = 0; i < todoListWrite.Count; i++)
            {
                if (todoListWrite[i].Datetime == DateTime.Now.Date)
                {
                    writeTask(i);
                }
            }
        }
        public void vplanned()
        {
            reader();

            for (int i = 0; i < todoListWrite.Count; i++)
            {
                if (todoListWrite[i].Datetime > DateTime.Now.Date)
                {
                    writeTask(i);
                }
            }
        }
        public void vcompleted()
        {
            reader();

            for (int i = 0; i < todoListWrite.Count; i++)
            {
                if (todoListWrite[i].TaskStatus)
                {
                    writeTask(i);
                }
            }
        }
        public void all()
        {
            reader();
            for (int i = 0; i < todoListWrite.Count; i++)
            {
                writeTask(i);
            }
           
        }
    }
}
