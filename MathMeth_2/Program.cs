using QueueingSystem;
using System.Collections.Generic;

namespace MathMeth_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<QueueSystem> monoChannels = new List<QueueSystem>
            {
                new QueueSystem(0.1, 2, 10),
                new QueueSystem(0.1, 5, 10),
                new QueueSystem(0.1, 9, 10),
                new QueueSystem(0.2, 1, 10),
                new QueueSystem(0.5, 1, 10),
                new QueueSystem(0.9, 1, 10),
                new QueueSystem(2, 0.1, 10),
                new QueueSystem(5, 0.1, 10),
                new QueueSystem(9, 0.1, 10)
            };

            //foreach (var mono in monoChannels)
            //  mono.PrintResults();

            List<QueueSystem> multiChannels = new List<QueueSystem>
            {
                new QueueSystem(1, 5, 20, _channels: 10),
                new QueueSystem(5, 5, 20, _channels: 10),
                new QueueSystem(100, 5, 20, _channels: 10)
            };          

            foreach (var multi in multiChannels)
                multi.PrintResults();

            System.Console.ReadLine();
        }
    }
}