using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Json
{
    class MainProgram
    {
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length == 1)
            {
                Console.WriteLine("Please enter text file location:");
                Array.Resize(ref args, args.Length + 1);
                args[^1] = Console.ReadLine();
            }

            var text = File.ReadAllText(args[1]);
            var value = new Value();
            var match = value.Match(text);

            if (match.Success() && match.RemainingText() == "")
            {
                Console.WriteLine(true);
            }
            else
                Console.WriteLine(false);

            Console.Read();
        }
    }
}
