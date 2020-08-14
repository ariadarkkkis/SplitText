using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitTextByDelimiter
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName;
            string delimiter = ";";

            if (args.Length == 0)
            {
                Console.Write("Enter file name: ");
                fileName = Console.ReadLine();
            }
            else
            {
                fileName = args[0];
            }

            string[] file = File.ReadAllLines(fileName);

            if (args.Length == 2 && !string.IsNullOrEmpty(args[1]))
            {
                Splitter(file, args[1]);
            }
            else
            {
                Console.Write("Do you want to split?(y/n) ");
                var useSplit = Console.ReadLine().ToLower();
                if (useSplit == "y")
                {
                    Splitter(file, delimiter);
                }
                else
                {
                    File.WriteAllText("file1.txt", String.Join(Environment.NewLine, file.Distinct()));
                }
                
            }
        }
        public static void Splitter(string[] file, string delimiter)
        {
            var list1 = new List<string>();
            var list2 = new List<string>();

            foreach (string line in file)
            {
                var splited = line.Split(delimiter, 2);
                if (splited.Length > 0 && !string.IsNullOrWhiteSpace(splited[0]))
                    list1.Add(splited[0]);

                if (splited.Length > 1 && !string.IsNullOrWhiteSpace(splited[1]))
                    list2.Add(splited[1]);
            }

            File.WriteAllText("file1.txt", String.Join(Environment.NewLine, list1.Distinct()));
            File.WriteAllText("file2.txt", String.Join(Environment.NewLine, list2.Distinct()));
        }
    }
}