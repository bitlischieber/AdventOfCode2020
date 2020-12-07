using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] groups = System.IO.File.ReadAllText(@"..\..\..\input.txt").Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("Read {0} entries", groups.Length.ToString());

            List<int[]> allAnsw = new List<int[]>();

            foreach(string g in groups)
            {
                // answers of a group
                string[] groupansw = g.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                int[] answ = new int[26];
                int grpcnt = 0;
                foreach (string ga in groupansw)
                {
                    char[] a = ga.ToCharArray();
                    for (int i = 0; i < a.Length; i++)
                    {
                        answ[a[i] - 'a'] += 1;
                    }
                    grpcnt++;
                }
                for (int i = 0; i < answ.Length; i++)
                {
                    if (answ[i] > 0)
                    {
                        answ[i] -= (grpcnt-1);
                        if (answ[i] < 0) answ[i] = 0;
                    }
                }
                allAnsw.Add(answ);
            }

            int totans = 0;
            foreach(int[] a in allAnsw)
            {
                totans += a.Sum();
            }
            Console.WriteLine("Total answers: {0}", totans);
            Console.ReadLine();

        }
    }
}
