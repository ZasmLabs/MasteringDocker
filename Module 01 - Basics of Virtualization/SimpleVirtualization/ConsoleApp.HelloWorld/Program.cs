using System;
using System.Threading.Tasks;

namespace ConsoleApp.HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name: ");
            var name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}");
            Task.Delay(5000).Wait();
            Console.WriteLine("Delay complete");
        }
    }
}
