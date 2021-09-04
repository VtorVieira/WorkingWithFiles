using System;
using System.IO;
using System.Globalization;
using WorkingWithFiles.Entities;

namespace WorkingWithFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            //Folder
            string path = @"C:\Users\rx190\Documents\out";
            //Arquivo de origem, onde contem os dados
            string sourcePath = @"C:\Users\rx190\Documents\fixacao.csv";
            //Arquivo de destino, que ira receber o resultado da soma
            string targetPath = @"C:\Users\rx190\Documents\out\summary.csv";

            try
            {
                string[] lines = File.ReadAllLines(sourcePath);

                //Verificando se existe o folder, se não, será criado.
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (StreamWriter sw = File.AppendText(targetPath))
                {
                    foreach (string line in lines)
                    {
                        //Criando um array do campos do arquivo com o separador ;
                        string[] fields = line.Split(';');
                        //campo 0 contendo o nome
                        string name = fields[0];
                        //campo 1 o valor do produto
                        double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        //campo 2 a quantidade
                        int quantity = int.Parse(fields[2]);

                        //criando o objeto da class Product
                        Product prod = new Product(name, price, quantity);

                        //Gravando o resultado no destino arquivo summary.csv, 
                        //apenas com o nome e o resultado da soma da função Total da class Product
                        sw.WriteLine(prod.Name + "," + prod.Total().ToString("F2", CultureInfo.InvariantCulture));
                    }
                }

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            // **********************Path************************
            /*string path = @"C:\Users\rx190\Documents\file1.txt";

            Console.WriteLine("DirectorySeparatorChar: " + Path.DirectorySeparatorChar);
            Console.WriteLine("PathSeparator: " + Path.PathSeparator);
            Console.WriteLine("GetDirectoryName: " + Path.GetDirectoryName(path));
            Console.WriteLine("GetFileName: " + Path.GetFileName(path));
            Console.WriteLine("GetFileNameWithoutExtension: " + Path.GetFileNameWithoutExtension(path));
            Console.WriteLine("GetExtension: " + Path.GetExtension(path));
            Console.WriteLine("GetFullPath: " + Path.GetFullPath(path));
            Console.WriteLine("GetTempPath: " + Path.GetTempPath());

            // **********************Directory************************
            /*string path = @"C:\Users\rx190\Documents\myfolder";

            try
            {
                IEnumerable<string> folders = Directory.EnumerateDirectories(path, "*.*", SearchOption.AllDirectories);
                Console.WriteLine("FOLDERS: ");
                foreach (string s in folders)
                {
                    Console.WriteLine(s);
                }
                
                Console.WriteLine();
                IEnumerable<string> files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
                Console.WriteLine("FILES: ");
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }

                Directory.CreateDirectory(path + @"\newfolder");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            /*
            // **********************Stream Writer************************
            string sourcePath = @"C:\Users\rx190\Documents\file1.txt";
            string targetPath = @"C:\Users\rx190\Documents\file2.txt";

            try
            {
                string[] lines = File.ReadAllLines(sourcePath);

                using (StreamWriter sw = File.AppendText(targetPath))
                {
                    foreach(string line in lines)
                    {
                        sw.WriteLine(line.ToUpper());
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            // **********************Stream Reader************************
            /*string path = @"C:\Users\rx190\Documents\myfolder\file1.txt";

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
