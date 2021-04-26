using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProgramA_AveragePoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int iloscTestow;
            int iloscElementow;
            iloscTestow = int.Parse(Console.ReadLine());
            for (int i = 0; i < iloscTestow; i++)
            {
                iloscElementow = int.Parse(Console.ReadLine());
                string[] elementy = new string[iloscElementow];
                int[][] lokacje = new int[iloscElementow][];
                int x = 0;
                int y = 0;
                int zakres;
                for (int j = 0; j < iloscElementow; j++)
                {
                    elementy[j] = Console.ReadLine();
                }
                for (int j = 0; j < elementy.GetLength(0); j++)
                {
                    int[] lokacja = Array.ConvertAll(elementy[j].Split(new char[] { ' ' }), s => int.Parse(s));
                    lokacje[j] = lokacja;
                    x += lokacja[0];
                    y += lokacja[1];
                }
                int avgx = x / iloscElementow;
                int avgy = y / iloscElementow;
                int tmpZakres = 10000000 / lokacje.Length;
                int minOdlegloscOdSredniej = MinOdlegloscOdSredniej(lokacje, avgx, avgy);
                if (tmpZakres < minOdlegloscOdSredniej)
                {
                    zakres = minOdlegloscOdSredniej + tmpZakres;
                }
                else
                {
                    zakres = tmpZakres;
                }
                var punktywZasiegu = PunktywZasiegu(lokacje, zakres, avgx, avgy);
                Console.WriteLine(ObliczMinOdleglosc(lokacje, punktywZasiegu));
            }
            stopWatch.Stop();
            Console.WriteLine("\n\n" + stopWatch.ElapsedMilliseconds.ToString());
        }
        static int ObliczMinOdleglosc(int[][] lokacje, int[][] punktywZasiegu)
        {
            int liczbaLokacji = lokacje.GetLength(0);
            int liczbaPunktow = punktywZasiegu.GetLength(0);
            int minOdleglosc = 0;
            for (int i = 0; i < liczbaPunktow; i++)
            {
                int odleglosc = 0;
                for (int j = 0; j < liczbaLokacji; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        odleglosc += Math.Abs(punktywZasiegu[i][k] - lokacje[j][k]);
                    }
                }
                if (i == 0)
                {
                    minOdleglosc = odleglosc;
                }
                if (minOdleglosc > odleglosc)
                {
                    minOdleglosc = odleglosc;
                }
            }
            return minOdleglosc;
        }
        static int[][] PunktywZasiegu(int[][] lokacje, int zakres, int avgx, int avgy)
        {
            List<int[]> punkty = new List<int[]>();
            foreach (int[] lokacja in lokacje)
            {
                //if(max(abs(lokacja[0]-avgx),abs(lokacja[1]-avgy)) < zakres{}
                if (avgx - zakres < lokacja[0] && lokacja[0] < avgx + zakres && avgy - zakres < lokacja[1] && lokacja[1] < avgy + zakres)
                {
                    punkty.Add(lokacja);
                }
            }
            int[][] punktywZasiegu = punkty.ToArray();
            if (punktywZasiegu.Length < lokacje.GetLength(0) * 0.05)
            {
                punktywZasiegu = PunktywZasiegu(lokacje, zakres *= 2, avgx, avgy);
            }
            return punktywZasiegu;
        }
        static int MinOdlegloscOdSredniej(int[][] lokacje, int avgx, int avgy)
        {
            int minOdlegloscOdSredniej = 0;
            foreach (int[] lokacja in lokacje)
            {
                int x = Math.Abs(lokacja[0] - avgx);
                int y = Math.Abs(lokacja[1] - avgy);
                if (x < y)
                {
                    minOdlegloscOdSredniej = x;
                }
                else
                {
                    minOdlegloscOdSredniej = y;
                }
            }
            return minOdlegloscOdSredniej;
        }
    }
}