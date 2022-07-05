using System;

namespace IndependentExecution.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var df = new DataFlowRunner();
            df.Run();

            Console.ReadLine();
        }
    }
}
