using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Task[] tasks = new Task[3];
            for (int i = 0; i < 3; i++)
            {
                int writer = i+1;
                tasks[i] = Task.Run(() => Method1(writer));
            }

            Task.WaitAll(tasks);

            Console.WriteLine($"Program ends here");
            Console.ReadLine();
        }

     

        static void Method1(int writer)
        {
            SingletonLogger singletonLogger = SingletonLogger.GetInstance();
            singletonLogger.LogMessage($"Some text from writer {writer}...");
        }

        static void Method2()
        {
            SingletonLogger singletonLogger = SingletonLogger.GetInstance();
            singletonLogger.LogMessage("Some text...");
        }

        //static void Main(string[] args)
        //{
        //    Stopwatch stopwatch = new Stopwatch();

        //    stopwatch.Start(); // Start the stopwatch
        //    Method1();
        //    Method2();
        //    stopwatch.Stop(); // Stop the stopwatch

        //    Console.WriteLine($"The total time spend to complete Method1 and Method2 under singleton " +
        //        $"pattern are: {stopwatch.Elapsed.TotalSeconds} seconds");
        //    Console.ReadLine();
        //}


    }
}
