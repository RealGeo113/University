using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string file1 = args[0];
            string file2 = args[1];
            int numberOfLines = File.ReadLines(file1).Count();
            for(int i = 0; i < numberOfLines; i++)
            {
                Console.Write(File.ReadLines(file1).ElementAt(i) + " " + File.ReadLines(file2).ElementAt(i));
                if(File.ReadLines(file1).ElementAt(i) == File.ReadLines(file2).ElementAt(i))
                {
                    Console.WriteLine(" Wyniki sa rowne!");
                }
                else
                {
                    Console.WriteLine(" Wyniki nie sa rowne!");
                }
            }
        }
    }
}
