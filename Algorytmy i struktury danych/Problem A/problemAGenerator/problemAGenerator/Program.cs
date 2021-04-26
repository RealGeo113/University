using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace problemAGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            string plik = "testFile.txt";
            //int liczbaTestów = rand.Next(1, 50);
            int liczbaTestów = 50;
            using (StreamWriter streamWriter = File.AppendText(plik))
            {
                streamWriter.WriteLine(liczbaTestów);
            }
            Console.WriteLine("Liczba testów: " + liczbaTestów);
            for(int i = 0; i < liczbaTestów; i++)
            {
                //int liczbaZnajomych = rand.Next(1, 10001);
                int liczbaZnajomych = 10000;
                using (StreamWriter streamWriter = File.AppendText(plik))
                {
                    streamWriter.WriteLine(liczbaZnajomych);
                }
                for (int j = 0; j < liczbaZnajomych; j++)
                {
                    int x = rand.Next(1, 100001);
                    int y = rand.Next(1, 100001);
                    using (StreamWriter streamWriter = File.AppendText(plik))
                    {
                        streamWriter.WriteLine(x + " " + y);
                    }
                }
            }
        }
    }
}
