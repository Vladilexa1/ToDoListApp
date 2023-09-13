
using System;

namespace ToDoListApp
{
    public class CommandSpliter
    {
        private string _input;
        public CommandSpliter(string input)
        {
            _input = input;
        }
        private string[] splitCommandAndAction()
        {
            string[] comandAndAction = _input.Split(" ", 2);
            return comandAndAction;
        }
        public string GetSplitCommand()
        {
            string comand = splitCommandAndAction()[0];
            return comand;
        }
        public string[] GetArrayAction() 
        {
            if (splitCommandAndAction().Length > 1)  
            {
                string[] action = splitCommandAndAction()[1].Split("--");
                return action;
            }
            else
            {
                return null;
            }
        }
    }
}
