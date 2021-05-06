using System;

namespace SuperConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine($"Should be true: {"".IsEmpty()}");
            Console.WriteLine($"Should be false: {"aaa".IsEmpty()}");
        }
    }
}
