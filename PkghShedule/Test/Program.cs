using System;
using System.Threading.Tasks;
using SheduleParser;

namespace Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var str = await Parser.Parse("ИП-18-4");
            Console.WriteLine("Hello World!");
        }
    }
}
