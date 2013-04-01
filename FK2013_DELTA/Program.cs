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
    class FK2013_EH : FKController
    {
        public FK2013_EH(string title = null, string[] args = null) : base(title, args) { }

        [FKAction("4", "Problem 4")]
        public void Problem4()
        {
            string l = Console.ReadLineQ("Lykilorð");
			int level = 0;
			
			if (l.Length > 7) level++;
			if (l.IsLike(@"[A-Z]") && l.IsLike("[a-z]"))level++;
			if (l.IsLike(@"[^\w\d]") || (l.IsLike(@"[A-Za-z]") && l.IsLike(@"[\d]")) )level++;

			switch(level)
			{
				case 0:
					Console.WriteLine("Lykilorð er veikt");
					break;
				case 1:
					Console.WriteLine("Lykilorð er ásættanlegt");
					break;
				case 2:
					Console.WriteLine("Lykilorð er gott");
					break;
                case 3:
                    Console.WriteLine("Lykilorðið er sterkt");
                    break;
				default:
					break;
			}
        }

        [FKAction("6", "Problem 6")]
        public void Problem6()
        {
            string[] stuff = Console.ReadLineQ("Listi").Split(' ');
            string[] reversed = stuff.Reverse().ToArray();
            Random rnd = new Random();
            string[] random = null;
            bool flag = true;
            while (flag)
            {
                int xcount = 0;
                int ycount = 0;
                random = stuff.OrderBy(x => rnd.Next()).ToArray();
                for (int i = 0; i < random.Length; i++)
                {
                    if (random[i] == reversed[i])
                    {
                        xcount++;
                    }
                    else if (random[i] == reversed[i])
                    {
                        ycount++;
                    }
                }
                flag = (ycount == random.Length - 1) || (xcount == random.Length - 1);
            }
            Console.WriteLine(random.ToStringPretty(""," "));
        }

        [FKAction("8", "Problem 8")]
        public void Problem8()
        {
            Console.Suffix = "= ";
            int n = Console.ReadLineQ<int>("n");
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0) Console.WriteLine("FizzBuzz");
                else if (i % 3 == 0) Console.WriteLine("Fizz");
                else if (i % 5 == 0) Console.WriteLine("Buzz");
                else Console.WriteLine(i);
            }
            Console.Suffix = ": ";
        }

        [FKAction("9", "Problem 9")]
        public void Problem9()
        {
            string s = Console.ReadLineQ("Lína");
            s = " " + s + " ";
            if (s.IsLike(@"[\s\-][0-9]*[\s]"))
            {
                Console.WriteLine("Já");
            }
            else Console.WriteLine("Nei");
        }

        [FKAction("11", "Problem 11")]
        public void Problem11()
        {
            string text = Console.ReadLine();
            var list = new []{new {C = text[0], Val = 0}}.ToList();
            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] > text[i - 1])
                {
                    list.Add(new { C = text[i], Val = list[i - 1].Val + 1 });
                }
                else if (text[i] < text[i - 1])
                {
                    list.Add(new { C = text[i], Val = list[i - 1].Val - 1 });
                }
                else list.Add(new { C = text[i], Val = list[i - 1].Val });
            }
            int min = list.Select(x => x.Val).Min();
            int max = list.Select(x => x.Val).Max();
            for (int i = max; i >= min; i--)
            {
                foreach (var item in list)
                {
                    if (item.Val == i) Console.Write(item.C);
                    else Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

        [FKAction("12", "Problem 12")]
        public void Problem12()
        {
            var state = Console.ReadLineQ("Upphafsstaða").Select(x => int.Parse(x.ToString())).ToList();
            var key = Console.ReadLineQ("Lykilorð").Select(x => int.Parse(x.ToString())).ToList();
            int turns = 0;
            for (int i = 0; i < state.Count; i++)
            {
                if (state[i] != key[i])
                {
                    int k = (10 + (state[i] - key[i])) % 10;
                    int m = state[i] + key[i] % 10;

                    if (state[i] == 9 && key[i] == 0) k = 1;
                    turns += Math.Min(k,m);
                }
            }
            Console.WriteLine("Minnsti fjöldi snúninga: {0}", turns);
        }

        [FKAction("13", "Problem 13")]
        public void Problem13()
        {
            var str = Console.ReadLine().ToLower().Where(Char.IsLetter).ToList();
            int total = str.GroupBy(x => x).Select(x => x.Count()).Sum();
            foreach (var i in str.GroupBy(x => x).OrderByDescending(x => x.Count()).ThenBy(x => x.Key))
            {
                Console.WriteLine("{0} {1:0.####}%",i.Key,((double)i.Count() / total) * 100 );
            }
        }

        [FKAction("15", "Problem 15")]
        public void Problem15()
        {
            Dictionary<string, string> vals = new Dictionary<string, string>();
            string line;
            while ((line = Console.ReadLine()) != "text:")
            {
                var s = line.Split('=');
                vals[s[0]] = s[1];
            }
            string text;
            Console.ReadLine(out text).WriteLine(string.Join(" ",text.Split(' ').Select(x=>vals[x])));
        }

        [FKAction("17", "Problem 17")]
        public void Problem17()
        {
            s1 = Console.ReadLine().SkipWhile(x => !Char.IsLetter(x)).ToArray();
            s2 = Console.ReadLine().SkipWhile(x => !Char.IsLetter(x)).ToArray();
            s3 = Console.ReadLine().SkipWhile(x => !Char.IsLetter(x)).ToArray();

            int flag = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 0; j <= topc; j++)
                {
                    if (s1[i] != c[j])
                        flag = 1;
                    else
                    {
                        flag = 0;
                        break;
                    }
                }
                if (flag == 1)
                    c[topc++] = s1[i];
            }

            for (int i = 0; i < s2.Length; i++)
            {
                for (int j = 0; j <= topc; j++)
                {
                    if (s2[i] != c[j])
                        flag = 1;
                    else
                    {
                        flag = 0;
                        break;
                    }
                }
                if (flag == 1)
                    c[topc++] = s2[i];
            }

            for (int i = 0; i < s3.Length; i++)
            {
                for (int j = 0; j <= topc; j++)
                {
                    if (s3[i] != c[j])
                        flag = 1;
                    else
                    {
                        flag = 0;
                        break;
                    }
                }
                if (flag == 1)
                    c[topc++] = s3[i];
            }

            try
            {

                if (solve(0, assinged) == 1)
                {
                    var s = c.ToList();

                    Console.WriteLine(string.Join("", s1.Select(x => val[s.IndexOf(x)])));
                    Console.WriteLine("+ " + string.Join("", s2.Select(x => val[s.IndexOf(x)])));
                    Console.WriteLine("= " + string.Join("", s3.Select(x => val[s.IndexOf(x)])));
                }
                else Console.WriteLine("Engin lausn");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Engin lausn");
            }
        }

        char[] s1 = new char[10];
        char[] s2 = new char[10];
        char[] s3 = new char[10];
        int[] assinged = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        char[] c = new char[11];

        int[] val = new int[11];
        int topc = 0;

        //-------------------end of getdata-----------------

        int solve(int ind, int[] temp1)
        {
            int[] temp2 = new int[10];
            int flag = 0;
            for (int i = 0; i < 10; i++)
            {
                if (temp1[i] == 0)
                {
                    for (int j = 0; j < 10; j++)
                        temp2[j] = temp1[j];
                    temp2[i] = 1;
                    val[ind] = i;
                    if (ind == (topc - 1))
                    {
                        if (verify() == 1)
                        {
                            flag = 1;
                            goto exit;
                        }
                    }
                    else
                    {
                        if (solve(ind + 1, temp2) == 1)
                        {
                            flag = 1;
                            goto exit;
                        }
                    }
                }
            }
        exit:
            if (flag != 0)
                return 1;
            else
                return 0;
        }

        int verify()
        {
            long n1 = 0, n2 = 0, n3 = 0;
            long power = 1;
            char ch;
            int i = s1.Length - 1;
            int in1;
            
            while (i >= 0)
            {
                ch = s1[i];
                in1 = 0;
                while (in1 != topc)
                {
                    if (c[in1] == ch)
                        break;
                    else
                        in1++;
                }
                long pow = power * val[in1];
                if (i == 0 && pow == 0)
                {
                    return 0;
                }
                n1 += pow;
                power *= 10;
                i--;
            }
            power = 1;
            i = s2.Length - 1;
            while (i >= 0)
            {
                ch = s2[i];
                in1 = 0;
                while (in1 != topc)
                {
                    if (c[in1] == ch)
                        break;
                    else
                        in1++;
                }
                long pow = power * val[in1];
                if (i == 0 && pow == 0)
                {
                    return 0;
                }
                n2 += pow;
                power *= 10;
                i--;
            }
            power = 1;
            i = s3.Length - 1;
            while (i >= 0)
            {
                ch = s3[i];
                in1 = 0;
                while (in1 != topc)
                {
                    if (c[in1] == ch)
                        break;
                    else
                        in1++;
                }
                long pow = power * val[in1];
                if (i == 0 && pow == 0)
                {
                    return 0;
                }
                n3 += pow;
                power *= 10;
                i--;
            }
            if (n1 + n2 == n3)
                return 1;
            else
                return 0;
        }

        

        [FKAction("18", "Problem 18")]
        public void Problem18()
        {
            var nums = Console.ReadLineQ("Tölur").Split(' ').Select(int.Parse).OrderByDescending(x => x).ToList();
            int cost = 0;
            int sum = nums.Sum();
            for (int i = nums.Count - 1; i > 0; i--)
            {
                Console.WriteLine("{0}+{1}", nums[i], nums[ i - 1]);
                nums[i - 1] += nums[i];
                cost += nums[i - 1];
            }
            Console.WriteLine("Samtals: {0}", sum).WriteLine("Minnsti kostnaður: {0}", cost);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            (new FK2013_EH("FK2013", args)).Run();
        }
    }
}
