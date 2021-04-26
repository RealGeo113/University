using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Problem_B
{
    class Program
    {
        static void Main()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int i = 1;
            List<int[]> punkty = new List<int[]>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input != null)
                {
                    if (input.Contains("--"))
                    {
                        Console.WriteLine(i + ". " + MaxIloscPunktow(punkty));
                        i++;
                        punkty.Clear();
                        input = Console.ReadLine();
                        {
                            if (input.Contains("--"))
                            {
                                break;
                            }
                            else
                            {
                                int[] tmp = Array.ConvertAll(input.Split(new char[] { ' ' }), s => int.Parse(s));
                                punkty.Add(tmp);
                            }
                        }    
                    }
                    else
                    {
                        int[] tmp = Array.ConvertAll(input.Split(new char[] { ' ' }), s => int.Parse(s));
                        punkty.Add(tmp);
                    }
                }
                else
                {
                    watch.Stop();
                    Console.WriteLine(watch.ElapsedMilliseconds.ToString());
                    break;
                }
                
            }
        }
        static int MaxIloscPunktow(List<int[]> punkty)
        {
            int[][] punktyS = punkty.ToArray();
            int MaxIloscPunktow = 0;
            int x, y;
            int dzielnik;
            for (int i = 0; i < punktyS.Length - 1; i++)
            {
                Dictionary<string, int> pairs = new Dictionary<string, int>();
                for (int j = 0; j < punktyS.Length; j++)
                {
                    if (j == i) continue;
                    x = punktyS[j][0] - punktyS[i][0];
                    y = punktyS[j][1] - punktyS[i][1];
                    if (x == 0 && y == 0) continue;
                    dzielnik = NWD(Math.Abs(x), Math.Abs(y));
                    x /= dzielnik;
                    y /= dzielnik;
                    string klucz = x.ToString() + y.ToString();
                    if (pairs.ContainsKey(klucz))
                    {
                        pairs[klucz]++;
                    }
                    else
                    {
                        pairs.Add(klucz, 2);
                    }
                }
                foreach (int iloscPunktow in pairs.Values)
                {
                    if (iloscPunktow > MaxIloscPunktow) MaxIloscPunktow = iloscPunktow;
                }
            }
            return MaxIloscPunktow;
        }
        //Algorytm Euklidesa
        static int NWD(int a, int b)
        {
            if (b == 0) return a;
            return NWD(b, a % b);
        }
    }
}
