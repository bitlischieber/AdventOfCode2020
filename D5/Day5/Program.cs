using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\input.txt");
            int maxSeatId = 0;
            int[] seatList = new int[128*8];
            // get row
            foreach(string l in lines)
            {
                string srow = l.Substring(0, 7).Replace("B", "1").Replace("F", "0");
                int row = Convert.ToInt32(srow, 2);
                string scol = l.Substring(7, 3).Replace("R", "1").Replace("L", "0"); ;
                int col = Convert.ToInt32(scol, 2);
                int seatId = row * 8 + col;
                if (seatId > maxSeatId) maxSeatId = seatId;
                seatList[seatId] = 1;
            }

            Console.WriteLine("Max. seat id: {0}", maxSeatId.ToString());
            Console.ReadLine();

        }
    }
}
