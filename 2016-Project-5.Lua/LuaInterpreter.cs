using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;

namespace _2016_Project_5.Lua
{
    public class LuaInterpreter
    {
        private Script _script;

        private List<Func<string, string>> _commandsAvailable;

        public LuaInterpreter()
        {
            _commandsAvailable = new List<Func<string, string>>();

            _script = new Script();

            _script.Globals["Print"] = (Action<string>)Print;
            _script.Globals["Error"] = (Action<string>)Error;
        }

        public void AddCommandAvailable(Func<string, string> method)
        {
            try
            {
                _commandsAvailable.Add(method);
                _script.Globals[method.Method.Name] = method;
            }
            catch (Exception e)
            {
                Error(e.Message);
            }
        }

        public void Command(string command)
        {
            if (!string.IsNullOrEmpty(command))
            {
                if (command == "help")
                {
                    foreach(var c in _commandsAvailable)
                    {
                        var parameters = c.Method.GetParameters()
                            .Select(x => x.ParameterType.ToString() + " " + x.Name).ToArray();
                        Print(c.Method.Name + "<" + c.Method.ReturnType.ToString() + "," + string.Join(",", parameters) + ">");
                    }
                }
                else
                {
                    try
                    {
                        _script.DoString(command);
                    }
                    catch (Exception e)
                    {
                        Error(e.Message);
                    }
                }
            }
        }

        #region Funtions availables
        public static void Print(string line)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(line);
            Console.ResetColor();
        }

        public static void Error(string line)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(line);
            Console.ResetColor();
        }
        #endregion
    }
}
