using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonSingletonDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start(); // Start the stopwatch
            Method1();
            Method2();
            stopwatch.Stop(); // Stop the stopwatch

                Console.WriteLine($"The total time spend to complete Method1 and Method2 under non singleton " +
                    $"pattern are: {stopwatch.Elapsed.TotalSeconds} seconds");
            Console.ReadLine();
        }

        static void Method1()
        {
            NonSingletonLogger nonSingletonLogger = new NonSingletonLogger();
            nonSingletonLogger.LogMessage("Some text...");
        }

        static void Method2()
        {
            NonSingletonLogger nonSingletonLogger = new NonSingletonLogger();
            nonSingletonLogger.LogMessage("Some text...");
        }
    }
}
