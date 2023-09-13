using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace ToDoListApp
{
    class Program
    {
        private static string startingGreeting = "Hello, it's my ToDoApp, write '-help', to see command";
       
        static void Main(string[] args)
        {
            DictionaryCommand DCommand = new DictionaryCommand(); 
            
            Console.WriteLine(startingGreeting);
           
            while (true) 
            {
                string input = Input.InputStringInConsole(); 
               
                if (input == "q") 
                {
                    break;
                } 
               
                CommandSpliter commandSpliter = new CommandSpliter(input); 

                try
                { 
                    string stringCommand = commandSpliter.GetSplitCommand();

                    string command = DCommand.GetCommand(stringCommand);

                    string[] acttion = commandSpliter.GetArrayAction();
                    
                    CommandLogger commandLogger = new CommandLogger(command, acttion);
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