using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagerAndLazyDemo
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Eager demo starts here");

            EagerSingletonLogger.LogMessage("some text...");//First, access method of eager singleton

            Console.WriteLine(EagerSingletonLogger.DummyEagerProperty);//Second, access property of eager singleton

            EagerSingletonLogger eagerInstance = EagerSingletonLogger.Instance;//Finally, create eager singleton instance

            Console.WriteLine("Eager demo ends here");

            Console.WriteLine("\n\n\n");
            

            Console.WriteLine("Lazy demo starts here");

            LazySingletonLogger.LogMessage("some text...");//First, access method of lazy singleton

            Console.WriteLine(LazySingletonLogger.DummyLazyProperty);//Second, access property of lazy singleton

            LazySingletonLogger lazyInstance = LazySingletonLogger.Instance;//Third, create lazy singleton instance

            Console.WriteLine("Lazy demo ends here");



            Console.ReadLine();

             
        }
    }
}
