using System;

namespace IndependExecution.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var df = new DataFlowRunner();
            df.Run();

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
