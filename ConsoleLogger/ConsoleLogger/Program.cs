using System;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleLogger
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var starter = new Starter();
            await starter.Run();
            Console.WriteLine("Logger is finished");
            Console.ReadLine();
        }
    }
}
