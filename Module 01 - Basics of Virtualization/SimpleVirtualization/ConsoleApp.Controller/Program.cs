using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ConsoleApp.Controller
{
    class Program
    {
        static void Main(string[] args)
        {
            var helloWorldStartInfo = new ProcessStartInfo
            {
                FileName = @"..\..\..\..\ConsoleApp.HelloWorld\bin\Debug\netcoreapp3.1\ConsoleApp.HelloWorld.exe",
                UseShellExecute = false,
                RedirectStandardInput = true
            };


            Console.WriteLine($"{Environment.CurrentDirectory}");

            using (var helloWorld = new Process())
            {
                helloWorld.StartInfo = helloWorldStartInfo;
                helloWorld.Start();

                Task.Run(async () =>
                {
                    await Task.Delay(3000);
                    helloWorld.Kill();
                });

                var inputStream = helloWorld.StandardInput;

                inputStream.WriteLine("Mastering Docker");
                inputStream.Close();
                helloWorld.WaitForExit();
            }

            Console.WriteLine("Press Enter to end Controller.");
            Console.ReadKey();
        }
    }
}
