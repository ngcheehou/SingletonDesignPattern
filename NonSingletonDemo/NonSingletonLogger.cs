using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NonSingletonDemo
{
    public class NonSingletonLogger
    {
        private readonly string path = "D:\\Log\\MyFile.txt";

        public NonSingletonLogger()
        {
             Thread.Sleep(2000);//pretends it takes a lot of time to fetches configuration data, establishes database connections etc 

        }
        public void LogMessage(string message)
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
