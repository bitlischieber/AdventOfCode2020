using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] entries = System.IO.File.ReadAllText(@"..\..\..\input.txt").Split(new[] {"\n\n"}, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("Read {0} entries", entries.Length.ToString());
            int validcnt = 0;
            foreach(string e in entries)
            {
                Passport p = new Passport(e.Replace("\n", " "));
                if (p.IsValid) validcnt++;

            }
            Console.WriteLine("Valid entries: {0}", validcnt.ToString());
            Console.ReadLine();
        }
    }

    public class Passport
    {
        public Passport(string entry)
        {
            string[] pairs = entry.Split(' ');
            Dictionary<string, string> values = new Dictionary<string, string>();
            foreach (string e in pairs)
            {
                string[] a = e.Split(':');
                if (a.Length == 2)
                {
                    values.Add(a[0], a[1]);
                }
            }
            foreach(string e in values.Keys)
            {
                int tmp = 0;
                Regex rx;
                Match match;
                switch (e)
                {
                    case "byr":
                        if(int.TryParse(values[e], out tmp) && tmp >= 1920 && tmp <= 2002)
                        {
                            byr = values[e];
                        }
                        break;
                    case "iyr":
                        if (int.TryParse(values[e], out tmp) && tmp >= 2010 && tmp <= 2020)
                        {
                            iyr = values[e];
                        }
                        break;
                    case "eyr":
                        if (int.TryParse(values[e], out tmp) && tmp >= 2020 && tmp <= 2030)
                        {
                            eyr = values[e];
                        }
                        break;
                    case "hgt":
                        rx = new Regex(@"^((?<hgtin>\d{1,3})in)|((?<hgtcm>\d{1,3})cm)$");
                        match = rx.Match(values[e]);
                        if (match.Success)
                        {
                            if(match.Groups["hgtin"].Success)
                            {
                                tmp = int.Parse(match.Groups["hgtin"].Value);
                                if (tmp >= 59 && tmp <= 76) hgt = values[e];
                            }
                            else if(match.Groups["hgtcm"].Success)
                            {
                                tmp = int.Parse(match.Groups["hgtcm"].Value);
                                if (tmp >= 150 && tmp <= 193) hgt = values[e];
                            }
                        }
                     
                        break;
                    case "hcl":
                        rx = new Regex(@"^#[0-9,a-f]{6}$");
                        match = rx.Match(values[e]);
                        if (match.Success)
                        {
                            hcl = values[e];
                        }
                        break;
                    case "ecl":
                        rx = new Regex(@"(^amb$)|(^blu$)|(^brn$)|(^gry$)|(^grn$)|(^hzl$)|(^oth$)");
                        match = rx.Match(values[e]);
                        if (match.Success)
                        {
                            ecl = values[e];
                        }
                        break;
                    case "pid":
                        rx = new Regex(@"^\d{9}$");
                        match = rx.Match(values[e]);
                        if (match.Success)
                        {
                            pid = values[e];
                        }
                        break;
                    case "cid":
                        cid = values[e];
                        break;
                    default:
                        break;
                }
            }
        }

        public string byr { get; set; } = "";
        public string iyr { get; set; } = "";
        public string eyr { get; set; } = "";
        public string hgt { get; set; } = "";
        public string hcl { get; set; } = "";
        public string ecl { get; set; } = "";
        public string pid { get; set; } = "";
        public string cid { get; set; } = "";

        public bool IsValid
        {
            get
            {
                bool valid = byr != "" && iyr != "" && eyr != "" && hgt != "" && hcl != "" && ecl != "" && ecl != "" && pid != "";
                return valid;
            }
        }

    }
}
