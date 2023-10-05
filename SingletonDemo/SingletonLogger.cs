using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public sealed class SingletonLogger
    {
        private readonly string path = "D:\\Log\\MyFile.txt";
        private static SingletonLogger instance;
        private static readonly object syncLock = new object();
        private static readonly object fileLock = new object();

        private SingletonLogger()
        {
            Thread.Sleep(2000);
            Console.WriteLine( "Instance Created");
            
        }

        public static SingletonLogger GetInstance()
        {


            if (instance == null)
            {
                lock (syncLock)
                {
                    if (instance == null)
                        instance = new SingletonLogger();
                }

            }
            return instance;
            

        }

        public void LogMessage(string message)
        {
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
