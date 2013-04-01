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
using Pie.IO;
using Pie.FK;
using Pie.CharShapes;
using Console = Pie.PieConsole;
using System.IO;

namespace FK2013_DELTA
{
    class FK2013_FH : FKController
    {
        public FK2013_FH(string title = null, string[] args = null) : base(title, args) { }

        [FKAction("4", "Problem 4")]
        public void Problem4()
        {
            int p;
            Console.ReadLineQ<int>(out p, "Fjöldi við borð").WriteLine("Gjafir: {0}", p * (p - 1));
        }

        [FKAction("6", "Problem 6")]
        public void Problem6()
        {
            string s, ss;
            Console.ReadLineQ(out s, "Orð 1").ReadLineQ(out ss, "Orð 2");
            int j = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ss[i])
                {
                    j++;
                }
            }
            Console.WriteLine(j);
        }

        [FKAction("10", "Problem 10")]
        public void Problem10()
        {
            var s = Console.ReadLineQ("Óþjappað").Split(' ').Select(Int32.Parse).ToList();
            string o = "";
            for (int i = 0; i < s.Count; i++)
            {
                int cur = s[i];
                int j = i;
                while ((j + 1) < s.Count && cur + 1 == s[j + 1])
                {
                    j++;
                    cur = s[j];
                }

                if (cur == s[i])
                {
                    o += cur;
                }
                else
                {
                    o += s[i] + "-" + cur;
                }
                o += " ";
                i = j;
            }
            Console.WriteLine(o);
        }

        [FKAction("11", "Problem 11")]
        public void Problem11()
        {
            string[] s = Console.ReadLineQ("Þjappað").Split(' ');
            string o = "";
            foreach (string k in s)
            {
                if (k.Contains('-'))
                {
                    for (int i = k[0].ToString().As<int>(); i < k[2].ToString().As<int>(); i++)
                    {
                        
                    }
                }
            }
            Console.WriteLine(o);
        }

        [FKAction("12", "Problem 12")]
        public void Problem12()
        {
            int p, q;
            Console.ReadLineQ<int>(out p,"Fjöldi raða").ReadLineQ<int>(out q,"Fjöldi dálka");
            string linex = "#".Repeat(q * 5 + 1);
            string liney = "#    ".Repeat(q + 1).SubstringEnd(3) ;
            string space = "\n".Repeat(4);
            Console.WriteLine(linex);
            for (int j = 0; j < 6; j++)
            {
                Console.WriteLine(liney);
            }
            Console.WriteLine(space);
            if (p > 2)
            {
                for (int i = 2; i < p; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine(liney);
                    }
                    Console.WriteLine(linex);
                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine(liney);
                    }
                    Console.WriteLine(space);
                }
            }
            if (p % 2 == 0)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.WriteLine(liney);
                }
                Console.WriteLine(linex);
            }
        }

        [FKAction("13", "Problem 13")]
        public void Problem13()
        {
            

        }

        [FKAction("14", "Problem 14")]
        public void Problem14()
        {
            Console.Suffix = "= ";
            double x = Console.ReadLineQ<double>("X");
            double epow = 0;
            for (int i = 0; i < 20; i++)
            {
                double t = Math.Pow(x, i) / (double)fact(i);
                Console.WriteLine(t);
                epow += t;
            }
            Console.WriteLine("e ^ {0} = {1:0.####}", x, epow);
            Console.Suffix = ": ";
        }

        Dictionary<long, long> cache = new Dictionary<long, long>();
        long fact(long n)
        {
            if (cache.Count == 0)
            {
                cache.Add(0, 1);
                cache.Add(1, 1);
                cache.Add(2, 2);
            }
            if (cache.ContainsKey(n))
            {
                return cache[n];
            }
            else
            {
                long fac = n * fact(n - 1);
                cache.Add(n, fac);
                return fac;
            }
        }

        [FKAction("15", "Problem 15")]
        public void Problem15()
        {
            int n, nn;
            Console.ReadLineQ<int>(out n, "Tala 1").ReadLineQ<int>(out nn, "Tala 2");

            string s = BaseConverter.ToBase(n.ToString(), 10, 2), ss = BaseConverter.ToBase(nn.ToString(), 10, 2);
            int j = 0;
            if (s.Length > ss.Length)
            {
                ss = new string(' ', s.Length - ss.Length) + ss;
            }
            else if (ss.Length > s.Length)
            {
                s = new string(' ',ss.Length - s.Length) + s;
            }
            for (int i = 0; i < Math.Max(s.Length,ss.Length); i++)
            {
                if (s.Length <= i || ss.Length <= i || s[i] != ss[i])
                {
                    j++;
                }
            }
            Console.WriteLine(j);
        }

        [FKAction("17", "Problem 17")]
        public void Problem17()
        {
            string filename = Console.ReadLineQ("Skrá");
            Dictionary<string, string> vals = new Dictionary<string, string>();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] s = line.Split(' ');
                    vals[s[0]] = s[1];
                }
            }
            string name = Console.ReadLineQ("Mannanafn");
            string[] r = name.Split(' ');
            if (r.Length == 1 && vals.ContainsKey(r[0])) Console.WriteLine("Löglegt");
            else if (r.Length == 2 && vals.ContainsKey(r[0]) && vals.ContainsKey(r[1]) && vals[r[0]] == vals[r[1]]) Console.WriteLine("Löglegt");
            else Console.WriteLine("Ekki löglegt");
        }

        [FKAction("18", "Problem 18")]
        public void Problem18()
        {
            int[][] board = new int[8][];
            int[] movementX = new int[]{-2, -2, -1, -1,  1,  1,  2,  2};
            int[] movementY = new int[]{-1,  1, -2,  2, -2,  2, -1,  1};
            string space = Console.ReadLineQ("Upphafsreitur");
            int row = (int)space[0] - 'A';
            int column = space[1].ToString().As<int>() - 1;

            string space2 = Console.ReadLineQ("Lokareitur");
            int targetRow = (int)(space2[0] - 'A');
            int targetColumn = space2[1].ToString().As<int>() - 1;

            for (int i = 0; i < 8; i++)
            {
                board[i] = new int[8];
                for (int j = 0; j < 8; j++)
                {
                    board[i][j] = -1;
                }
            }
            board[row][column] = 0;
            for (int step = 0; step < 7; step++)
                for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 8; j++)
                        if (board[i][j] == step)
                            for (int k = 0; k < 8; k++) 
                                if (i + movementY[k] >= 0 && i + movementY[k] < 8 && j + movementX[k] >= 0 && j + movementX[k] < 8)
                                    if (board[i + movementY[k]][j + movementX[k]] == -1)
                                    {
                                        Console.WriteLine("ABCDEFGH"[i] + " " + j);
                                        board[i + movementY[k]][j + movementX[k]] = step + 1;
                                    }
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            (new FK2013_FH("FK2013", args)).Run();
        }
    }
}
