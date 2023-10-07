using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EagerAndLazyDemo
{
    public sealed class LazySingletonLogger
    {
        private static readonly Lazy<LazySingletonLogger> lazyInstance = new Lazy<LazySingletonLogger>(() => new LazySingletonLogger());
        private readonly static string path = "D:\\Log\\MyFile.txt";
        private static readonly object fileLock = new object();

        public static LazySingletonLogger Instance { get { return lazyInstance.Value; } }

        private LazySingletonLogger() {
            Thread.Sleep(2000);
            Console.WriteLine("Lazy Instance Created");
        }
        public static string DummyLazyProperty
        {
            get
            {
                return "This is a Dummy Lazy Property";
            }
        }

        public static void LogMessage(string message)
        {
            Console.WriteLine("proceed to LogMessage method of LazySingletonLogger");
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
