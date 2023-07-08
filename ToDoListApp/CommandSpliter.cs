using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ToDoListApp
{
    public class CommandSpliter
    {
        private string _input;
        private string[] _comadnAndAction;
        private string[] _action;
        public CommandSpliter(string input)
        {
            _input = input;
        }
        public string command() // сплитит строку на команду и действие
        {
            _comadnAndAction = _input.Split(" ", 2); // 2 kol-vo strok split
            return _comadnAndAction[0]; 
        }
        public string[] action() // сплит действия
        {
            if (_comadnAndAction.Length > 1)  
            {
                _action = _comadnAndAction[1].Split("--", 4);
            }
            return _action;
        }
    }
}
