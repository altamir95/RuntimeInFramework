using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuntimeInFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PythonOperation pop = new PythonOperation();
            pop.Initialize();
            pop.Execute();
            Console.ReadLine();
        }
    }
}
