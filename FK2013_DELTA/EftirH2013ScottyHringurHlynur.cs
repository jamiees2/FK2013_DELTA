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
    class FK2013FH : FKController
    {
        public FK2013FH(string title = null, string[] args = null) : base(title, args) { }

        [FKAction("1", "Problem 1")]
        public void Problem1()
        {
            Console.WriteLine("Hello World");
        }

        [FKAction("2", "Problem 2")]
        public void Problem2()
        {
            double d;
            Console.ReadLineQ<double>(out d, "Kommutala").WriteLine(Math.Round(d, MidpointRounding.AwayFromZero));
        }

        [FKAction("3", "Problem 3")]
        public void Problem3()
        {
            int n;
            Console.ReadLineQ<int>(out n, "Tala");
            for (int i = n; i > 0; i--)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("BOOM!!!");
        }

        [FKAction("5", "Problem 5")]
        public void Problem5()
        {
            string s;
            Console.ReadLineQ(out s, "Strengur").WriteLine("Thad eru {0} stafir i strengnum", s.Count(Char.IsLetter));//Not count integers
        }

        [FKAction("7", "Problem 7")]
        public void Problem7()
        {
            string nafn, aldur, kyn;
            Console.ReadLineQ(out nafn, "Nafn").ReadLineQ(out aldur, "Aldur").ReadLineQ(out kyn, "Kyn");
            if (kyn == "kk")
                kyn = "Hann";
            else if (kyn == "kvk")
                kyn = "Hún";
            Console.WriteLine(kyn + " á afmæli í dag,\n" + kyn + " á afmæli í dag.\n" + kyn + " á afmæli " + kyn + " " + nafn + ",\n" + kyn + " á afmæli í dag.\n\n" + kyn + " er " + aldur + " ára í dag,\n" + kyn + " er " + aldur + " ára í dag.\n" + kyn + " er " + aldur + " ára " + kyn + " " + nafn + ",\n" + kyn + " er " + aldur + " ára í dag.");
        }

        [FKAction("8", "Problem 8")]
        public void Problem8()
        {
            int f, s;
            Console.ReadLineQ<int>(out f, "Fyrri heiltala").ReadLineQ<int>(out s, "Seinni heiltala").WriteLine(s + " gengur {1} sinnum upp í {0} \n{2}", f, Math.DivRem(f, s, out f), (f != 0 ? "Afgangur er " + f : "Enginn afgangur"));
        }

        [FKAction("9", "Problem 9")]
        public void Problem9()
        {
            int f, s;
            string opt = "";
            while (opt != "n")
            {
                Console.ReadLineQ<int>(out f, "Fyrri heiltala").ReadLineQ<int>(out s, "Seinni heiltala").WriteLine(s + " gengur {1} sinnum upp í {0} \n{2}", f, Math.DivRem(f, s, out f), (f != 0 ? "Afgangur er " + f : "Enginn afgangur"));
                Console.ReadLineQ(out opt, "Viltu hætta(j/n)");
            }
        }

        [FKAction("13", "Problem 13")]
        public void Problem13()
        {
            int n;

            Console.ReadLineQ<int>(out n, "Stærð");
            if (n > 0 && n < 20 && n % 2 != 0)
            {
                int[][] spiral = new int[n][];
                for (int i = 0; i < spiral.Length; i++)
                {
                    spiral[i] = new int[n];
                }
                getSpiral(ref spiral);
                for (int i = 0; i < spiral.Length; i++)
                {
                    for (int j = 0; j < spiral[i].Length; j++)
                    {
                        Console.Write(spiral[i][j].ToString().PadLeft(3) + " ");
                    }
                    Console.WriteLine();
                }
            }
            else
                Console.WriteLine("Ólögleg stærð");
        }

        public static void getSpiral(ref int[][] input)
        {
            int x = input.Length - 1;
            int y = input[0].Length - 1;
            getSpiral(input, x, y, (x + 1) * (y + 1) - 1, 0);
        }

        public static void getSpiral(int[][] input, int x, int y, int n, int a)
        {
            input[x][y] = n--;

            if (a < 1 && y > 0 && input[x][y - 1] < n) // left
                getSpiral(input, x, y - 1, n, 0);
            else if (a < 2 && x > 0 && input[x - 1][y] < n) // top
                getSpiral(input, x - 1, y, n, 1);
            else if (a < 3 && (y + 1) < input[0].Length && input[x][y + 1] < n) // right
                getSpiral(input, x, y + 1, n, 2);
            else if (a < 4 && (x + 1) < input.Length && input[x + 1][y] < n) // down
                getSpiral(input, x + 1, y, n, 3);
            else if (y > 0 && input[x][y - 1] < n)// left
                getSpiral(input, x, y - 1, n, 0);

            return;
        }

        [FKAction("16", "Problem 16")]
        public void Problem16()
        {
            string[] Null = new string[] { "@@@ ", "@ @ ", "@ @ ", "@ @ ", "@@@ " };
            string[] einn = new string[] { "  @ ", "  @ ", "  @ ", "  @ ", "  @ " };
            string[] tveir = new string[] { "@@@ ", "  @ ", "@@@ ", "@   ", "@@@ " };
            string[] thrir = new string[] { "@@@ ", "  @ ", "@@@ ", "  @ ", "@@@ " };
            string[] fjorir = new string[] { "@ @ ", "@ @ ", "@@@ ", "  @ ", "  @ " };
            string[] fimm = new string[] { "@@@ ", "@   ", "@@@ ", "@   ", "@@@ " };
            string[] sex = new string[] { "@@@ ", "@ @ ", "@ @ ", "@ @ ", "@@@ " };
            string[] sjo = new string[] { "@@@ ", "  @ ", "  @ ", "  @ ", "  @ " };
            string[] atta = new string[] { "@@@ ", "@ @ ", "@@@ ", "@ @ ", "@@@ " };
            string[] niu = new string[] { "@@@ ", "@ @ ", "@@@ ", "  @ ", "  @ " };
            string[][] s = new[] { Null, einn, tveir, thrir, fjorir, fimm, sex, sjo, atta, niu };
            int n;
            Console.ReadLineQ<int>(out n, "Numer");
            for (int i = 0; i < 5; i++)
            {
                foreach (int k in n.Digits())
                {
                    Console.Write(s[k][i]);
                }
                Console.WriteLine();
            }
        }
    }
}
