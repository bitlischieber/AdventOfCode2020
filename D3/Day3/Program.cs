using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            int colidx = 0;
            int treecnt = 0;
            
            //--- PART 1 ---
            foreach (string ln in System.IO.File.ReadAllLines(@"..\..\..\input.txt"))
            {
                char[] chrln = ln.ToCharArray();
                if (chrln[colidx % chrln.Length] == '#')
                {
                    // hit a tree
                    treecnt++;
                }
                colidx += 3; // next column
            }
            Console.WriteLine("Hit {0} trees", treecnt);
            Console.ReadLine();

            //--- PART 2 ---
            List<int> hitList = new List<int>();
            hitList.Add(GetArborealHits(1, 1));
            hitList.Add(GetArborealHits(3, 1));
            hitList.Add(GetArborealHits(5, 1));
            hitList.Add(GetArborealHits(7, 1));
            hitList.Add(GetArborealHits(1, 2));
            long hitProduct = hitList[0];
            for(int i = 1; i < hitList.Count; i++) hitProduct *= hitList[i];
            Console.WriteLine("Hit product: {0}", hitProduct);
            Console.ReadLine();
        }

        private static int GetArborealHits(int ColumnInc, int RowInc)
        {
            int rowCnt = 0;
            int colidx = 0;
            int treecnt = 0;
            foreach (string ln in System.IO.File.ReadAllLines(@"..\..\..\input.txt"))
            {
                if (rowCnt % RowInc > 0)
                {
                    rowCnt++;
                    continue;
                }
                char[] chrln = ln.ToCharArray();
                if (chrln[colidx % chrln.Length] == '#')
                {
                    // hit a tree
                    treecnt++;
                }
                colidx += ColumnInc; // next column
                rowCnt++;
            }
            return treecnt;
        }
    }
}
