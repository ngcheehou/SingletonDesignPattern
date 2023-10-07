using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EagerAndLazyDemo
{
    public sealed class EagerSingletonLogger
    {

        private static readonly EagerSingletonLogger instance = new EagerSingletonLogger();
        private readonly static string path = "D:\\Log\\MyFile.txt";
        private static readonly object fileLock = new object();

        private EagerSingletonLogger()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Eager Instance Created");

        }

        public static EagerSingletonLogger Instance
        {
            get
            {
                return instance;
            }
        }

        public static string DummyEagerProperty
        {
            get
            {
                return "This is a Dummy Eager Property";
            }
        }

       

        public static void LogMessage(string message)
        {
            Console.WriteLine("proceed to LogMessage method of EagerSingletonLogger");
            lock (fileLock)
            {
                try
                {
                    // Ensure directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(path));

                    // Append text to the file
                    File.AppendAllText(path, message + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

    }
}
