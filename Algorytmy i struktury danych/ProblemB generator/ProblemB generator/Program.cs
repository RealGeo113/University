using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemB_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 1000; j++)
                {
                    Console.WriteLine(random.Next(-100, 100) + " " + random.Next(-100, 100));
                }
                Console.WriteLine("----");
            }
        }
    }
}
