using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

namespace ProgramA_AveragePoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string plik = args[0]; //args[0]
            string plikWyniki = args[1]; //args[1]
            int iloscTestow = int.Parse(File.ReadLines(plik).First());
            string[] wyniki = new string[iloscTestow];
            int n = 1;
            for (int i = 0; i < iloscTestow; i++)
            {
                int iloscElementow = int.Parse(File.ReadLines(plik).ElementAtOrDefault(n));
                int[][] lokacje = new int[iloscElementow][];
                string[] elementy = File.ReadLines(plik).Skip(n + 1).Take(iloscElementow).ToArray();
                int x = 0;
                int y = 0;
                for (int j = 0; j < elementy.GetLength(0); j++)
                {
                    string[] tmp = elementy[j].Split(new char[] { ' ' });
                    int[] tmp2 = Array.ConvertAll(tmp, s => int.Parse(s));
                    lokacje[j] = tmp2;
                    x += tmp2[0];
                    y += tmp2[1];
                }
                int avgx = x / iloscElementow;
                int avgy = y / iloscElementow;
                wyniki[i] = ObliczMinOdleglosc(lokacje, PunktywZasiegu(lokacje, avgx, avgy)).ToString();
                n += iloscElementow + 1;
            }
            File.WriteAllLines(plikWyniki, wyniki);
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
        static int[][] PunktywZasiegu(int [][] lokacje, int avgx, int avgy, int zakres = 1000)
        {
            List<int[]> punkty = new List<int[]>();
            foreach(int[] lokacja in lokacje)
            {
               if(avgx-zakres < lokacja[0] && lokacja[0] < avgx + zakres && avgy- zakres < lokacja[1] && lokacja[1] < avgy+ zakres)
               {
                  punkty.Add(lokacja);
               }
            }
            int[][] punktywZasiegu = punkty.ToArray();
            if (punktywZasiegu.Length < lokacje.Length*0.05)
            {
                punktywZasiegu=PunktywZasiegu(lokacje, avgx, avgy, zakres+=1000);
            }
            return punktywZasiegu;
        }
    }
}
