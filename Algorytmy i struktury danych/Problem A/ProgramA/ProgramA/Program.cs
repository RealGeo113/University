using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

namespace ProgramA
{
    class Program
    {
        static long licznikOperacji = 0;
        static void Main(string[] args)
        {
            string plik = args[0]; //"ProblemA_2.txt"; //args[0]
            string plikWyniki = args[1]; //"wynik.txt"; //args[1]
            int iloscTestow = int.Parse(File.ReadLines(plik).First());
            string[] wyniki = new string[iloscTestow];
            int n = 1;
            for(int i = 0; i < iloscTestow; i++)
            {
                int iloscElementow = int.Parse(File.ReadLines(plik).ElementAtOrDefault(n));
                Console.WriteLine(i+1 + ". " + iloscElementow);
                int[,] lokacje = new int[iloscElementow,2];
                string [] elementy = File.ReadLines(plik).Skip(n + 1).Take(iloscElementow).ToArray();
                for (int j = 0; j < elementy.GetLength(0); j++)
                {
                    string [] tmp = elementy[j].Split(new char[] { ' ' });
                    for(int k = 0; k < tmp.GetLength(0); k++)
                    {
                        lokacje[j, k] = int.Parse(tmp[k]);
                        licznikOperacji++;
                    }
                }
                wyniki[i] = obliczMinOdleglosc(lokacje).ToString();
                n += iloscElementow + 1;
            }
            File.WriteAllLines(plikWyniki, wyniki);
            Console.WriteLine("Liczba operacji: " + licznikOperacji);
        }
        static int obliczMinOdleglosc(int[,] lokacje)
        {
            int liczbaLokacji = lokacje.GetLength(0); 
            int minOdleglosc = 0;
            for (int i = 0; i < liczbaLokacji; i++)
            {
                int odleglosc = 0;
                for (int j = 0; j < liczbaLokacji; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        odleglosc += Math.Abs(lokacje[i, k] - lokacje[j, k]);
                        licznikOperacji++;
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
    }
}
