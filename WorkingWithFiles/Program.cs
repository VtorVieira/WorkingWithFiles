using System;
using System.IO;
using System.Collections.Generic;

namespace WorkingWithFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            // **********************Stream Reader************************
            string path = @"C:\Users\rx190\Documents\myfolder\file1.txt";

            try
            {
                using (StreamReader sr = File.OpenText(path) )
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            
            /*string path = @"C:\Users\rx190\Documents\file1.txt";
            
            StreamReader sr = null;

            try
            {
                sr = File.OpenText(path);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Console.WriteLine(line);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (sr != null) sr.Close();
            }
            
            string sourcePath = @"C:\Users\rx190\Documents\Pasta1.xlsx";
            string targetPath = @"C:\Users\rx190\Documents\Pasta2.xlsx";

            try
            {
                FileInfo fileInfo = new FileInfo(sourcePath);
                fileInfo.CopyTo(targetPath);
                string[] lines = File.ReadAllLines(sourcePath);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            catch(IOException e)
            {
                Console.WriteLine("An erro ocrrurred");
                Console.WriteLine(e.Message);
            }*/
        }
    }
}
