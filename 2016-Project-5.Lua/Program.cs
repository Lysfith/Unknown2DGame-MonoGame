using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_5.Lua
{
    class Program
    {
        static void Main(string[] args)
        {
            var value = Program.CallbackTest();

            Console.WriteLine("Value : " + value);
            Console.ReadKey();
        }

        public static int Mul(int a, int b)
        {
            return a * b;
        }

        public static void Log(string line)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(line);
            Console.ResetColor();
        }


        public static double CallbackTest()
        {
            string scriptCode = @"    
            Log('test')    
            ";

            Script script = new Script();

            script.Globals["Mul"] = (Func<int, int, int>)Mul;
            script.Globals["Log"] = (Action<string>)Log;

            script.DoString(scriptCode);

            return 0;
        }

    }
}
