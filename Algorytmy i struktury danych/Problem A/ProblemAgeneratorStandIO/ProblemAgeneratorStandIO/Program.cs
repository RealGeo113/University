using System;

namespace problemAGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            //int liczbaTestów = rand.Next(1, 50);
            int liczbaTestów = 50;
            Console.WriteLine(liczbaTestów);
            for (int i = 0; i < liczbaTestów; i++)
            {
                //int liczbaZnajomych = rand.Next(1, 10001);
                int liczbaZnajomych = 10000;
                Console.WriteLine(liczbaZnajomych);
                for (int j = 0; j < liczbaZnajomych; j++)
                {
                    int x = rand.Next(1, 100001);
                    int y = rand.Next(1, 100001);
                    Console.WriteLine(x + " " + y);
                    //if (j % 2 == 0)
                    //{
                    //    int x;
                    //    if (rand.Next(1, 3) % 2 == 0)
                    //    {
                    //        x = rand.Next(1, 100);
                    //    }
                    //    else
                    //    {
                    //        x = rand.Next(99900, 100001);
                    //    }
                    //    int y = rand.Next(1, 100001);
                    //    Console.WriteLine(x + " " + y);
                    //}
                    //else
                    //{
                    //    int y;
                    //    if (rand.Next(1, 3) % 2 == 0)
                    //    {
                    //        y = rand.Next(1, 100);
                    //    }
                    //    else
                    //    {
                    //        y = rand.Next(99900, 100001);
                    //    }
                    //    int x = rand.Next(1, 100001);
                    //    Console.WriteLine(x + " " + y);
                    //}

                }
            }
        }
    }
}
