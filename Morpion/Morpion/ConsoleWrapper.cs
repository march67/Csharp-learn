using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpion
{
    public class ConsoleWrapper : IConsoleWrapper
    {
        public void Write(string message) => Console.Write(message);
        public string? ReadLine() => Console.ReadLine();
    }
}
