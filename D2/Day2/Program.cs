using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex expression = new Regex(@"(?<min>\d{1,30})-(?<max>\d{1,30}) (?<chr>\w): (?<pw>.*)");
            int validpws = 0;

            foreach (string ln in System.IO.File.ReadAllLines(@"..\..\..\input.txt"))
            {
                Match match = expression.Match(ln);
                if (match.Success)
                {
                    // validity check
                    int min = int.Parse(match.Groups["min"].Value);
                    int max = int.Parse(match.Groups["max"].Value);
                    char chr = char.Parse(match.Groups["chr"].Value);
                    string pw = match.Groups["pw"].Value;
                    int pwcnt = pw.Count(x => x == chr);

                    //--- PART 1 -----
                    /*if(pwcnt >= min && pwcnt <= max)
                    {
                        Console.WriteLine(ln);
                        validpws++;
                    }
                    */
                    //--- PART 2 -----
                    char[] pwchr = pw.ToCharArray();
                    if(pwchr[min-1] == chr ^ pwchr[max-1] == chr)
                    {
                        Console.WriteLine(ln);
                        validpws++;
                    }
                }
            }
            Console.WriteLine("Valid passwords: {0}", validpws.ToString());
            Console.ReadLine();
        }
    }
}
