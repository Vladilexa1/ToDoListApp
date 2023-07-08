using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DictionaryCommand DCommand = new DictionaryCommand(); // slovar comand
            
            
            
            while (true) 
            {
                
                string input = Console.ReadLine(); // получаем какую либо команду для ToDo
               
                if (input == "q") 
                {
                    break;
                } 
              
                CommandSpliter commandSpliter = new CommandSpliter(input); // spliter dlya command and action

                try
                {
                    string command = commandSpliter.command();

                    CommandLogger commandLogger = new CommandLogger(DCommand.SetCommand(command), commandSpliter.action());
                    
                }
                catch (Exception)
                {
                    Console.WriteLine("Command not found, write '-help', to see command");
                    continue;     
                }
            }

            





            

        }
    }
}