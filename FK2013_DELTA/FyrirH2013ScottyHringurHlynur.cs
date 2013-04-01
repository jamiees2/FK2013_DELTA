using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Pie; //https://github.com/jamiees2/Pie
using Pie.Strings;
using Pie.Math;
using Pie.Math.Geometry;
using Pie.Time;
using Pie.Units;
using Pie.IO;
using Pie.FK;
using Pie.CharShapes;
using Console = Pie.PieConsole;

namespace Forritunarkeppnin_2013_Scotty
{
    class FK2013 : FKController
    {
        public FK2013(string title = null, string[] args = null) : base(title, args) { }

        [FKAction("1", "Problem 1")]
        public void Problem1()
        {
            int n;
            Console.ReadLineQ<int>(out n, "N");
            for (int i = 0; i < n+1; i++)
            {
                Console.WriteLine("2 ^ "+i+" = "+ Math.Pow(2,i));
            }
        }

        [FKAction("2", "Problem 2")]
        public void Problem2()
        {
            string s;
            
            Console.ReadLineQ(out s, "Setning");
            string[] sl = s.Split();
            for (int i = 0; i < sl.Length; i++)
            {
                Console.Write(sl[i].Reverse()+" ");
            }
        }

        [FKAction("3", "Problem 3")]
        public void Problem3()
        {
            double w, l, h;
            Console.ReadLineQ<double>(out w, "Breidd").ReadLineQ<double>(out l, "Lengd").ReadLineQ<double>(out h, "Hæð").WriteLine("Stærsta r = {0}", Math.Min(w,Math.Min(l,h))/2);
        }

        [FKAction("5", "Problem 5")]
        public void Problem5()
        {
            int opt=-1;
            while (opt!=3)
            {
                Console.ReadLineQ(out opt, "1. Breyta Kelvin í Fahrenheit\n2. Breyta Fahrenheit í Kelvin\n3. Hætta\nVal");
                switch (opt)
                {
                    case 1:
                        double k;
                        Console.ReadLineQ<double>(out k, "Kelvin").WriteLine((Fahrenheit)((Kelvin)k));
                        break;
                    case 2:
                        double f;
                        Console.ReadLineQ<double>(out f, "Fahrenheit").WriteLine((Kelvin)((Fahrenheit)f));
                        break;
                    default:
                        break;
                } 
            }
        }

        [FKAction("7", "Problem 7")]
        public void Problem7()
        {
            int f;
            Console.ReadLineQ<int>(out f, "Fjoldi lina");
            List<string> a = Console.ReadLines().Take(f).ToList();
            for (int i = 0; i < a.Select(x => x.Length).Max(); i++)
            {
                for (int n = 0; n < a.Count; n++)
                {
                    if(a[n].Length>i)
                        Console.Write(a[n][i]+" ");
                    else
                    Console.Write("  ");
                }
                Console.WriteLine();
            }
        }

        [FKAction("10", "Problem 10")]
        public void Problem10()
        {
            int m, md;
            Console.ReadLineQ<int>(out m, "Dagar í mánuðinum").ReadLineQ<int>(out md, "Fyrsti dagur mánaðarins").WriteLine("Sun Mán Þri Mið Fim Fös Lau");
            Console.Write(1.ToString().PadLeft(4 * md-1));
            if (md == 7)
            {
                Console.WriteLine();
            }
            int iA = md+1;
            for (int i = 2; i <= m; i++)
            {
                if (iA % 7 == 0)
                    Console.WriteLine(i.ToString().PadLeft(4));
                else
                    Console.Write(i.ToString().PadLeft(4));
                iA++;
            }
        }

        [FKAction("14", "Problem 14")]
        public void Problem14()
        {
            int n;
            Console.ReadLineQ<int>(out n, "n");
            if (n > 0 && n < Math.Pow(10, 8))
            {
                if (n.ProperDivisors().Sum() == n)
                    Console.WriteLine("Fullkomin");
                else
                    Console.WriteLine("Ekki fullkomin");
            }
            else
                Console.WriteLine("Vitlaus innsláttur");
        }

        [FKAction("16", "Problem 16")]
        public void Problem16()
        {
            Dictionary<string, double> d = new Dictionary<string,double>();
            int f;
            Console.ReadLineQ<int>(out f, "Fjöldi");
            for (int i = 0; i < f; i++)
            {
                string n;
                double h, t;
                Console.ReadLineQ(out n, "Nafn " + (i + 1)).ReadLineQ<double>(out h, "Hæð " + (i + 1)).ReadLineQ<double>(out t, "Þyngd " + (i + 1));
                Console.WriteLine("\n");
                d.Add(n, t / Math.Pow(h, 2));
            }
            foreach (var i in d.OrderBy(x => x.Value))
            {
                Console.WriteLine("{0} {1:0.#}" ,i.Key, i.Value);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            new FK2013FH("FK2013FH", args).Run();
            //(new FK2013("FK2013", args)).Run();
        }
    }
}
