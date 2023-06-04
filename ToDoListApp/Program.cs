using System.Collections.Specialized;
using System.ComponentModel;

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

            CommandSpliter commandSpliter = new CommandSpliter(input); // spliter dlya command and action
            
            
                try
                {
                    CommandLogger commandLogger = new CommandLogger(DCommand.command[commandSpliter.command()]);
                }
                catch (Exception)
                {

                    Console.WriteLine("Command not found, write '-help', to see command");
                }
            }

            //Console.WriteLine(DCommand.command[commandSpliter.command()]); 

            int a = 1;





        

        }
    }
}