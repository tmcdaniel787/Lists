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

            Console.WriteLine("Enter the number of trailing digits:");
            string mstring = Console.ReadLine();
            int m;
            if (string.IsNullOrEmpty(mstring) || !int.TryParse(mstring, out m))
            {
                Console.Error.WriteLine("The number of trailing digits is invalid");
                return;
            }
            //HashSet <long> list;
            IEnumerable<long> list;
            try
            {
                //list = Calc(m);
                list = new Calculation(m);
                foreach (var z in list)
                {
                    Console.WriteLine(z);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.Error.WriteLine("The number of trailing digits is out of range");
                return;
            }
        }
        static HashSet<long> Calc(int m)
        {
            if (m < 1 || m > 17)
            {
                throw new ArgumentOutOfRangeException();
            }
            int x = 1;
            int d = 1;
            var list = new HashSet<long>();//similar to List<int> but is a set class. Ensures all values are unique
            var exists = new Dictionary<int, bool>();
            for (int i = 0; i < m; i++)
            {
                d = d * 10;
            }
            for (int i = 1; ; i++)
            {
                x = x * 2;
                int y = x = x % d;//this is for large numbers since we only care about the last 3 digits. if you do not do this, the m=1000 will fail because there is not enough space for a number that
                //big in int.
                if (list.Contains(y))
                {
                    break;
                }
                list.Add(y);
                if (exists.ContainsKey(y))
                {
                    break;
                }
                exists[y] = true;//this is the same thing as saying exists.Add(y,true) the true does not matter just need a value for the dictionary key.
                list.Add(y);

            }
            return list;
        }
        static IEnumerable<long> Calc2(int m)
        {
            if (m < 1 || m > 17)
            {
                throw new ArgumentOutOfRangeException();
            }
            long x = 1;
            int d = 1;
            var exists = new Dictionary<long, bool>();
            for (int i = 0; i < m; i++)
            {
                d = d * 10;
            }
            for (int i = 1; ; i++)
            {
                x = x * 2;
                long y = x = x % d;//this is for large numbers since we only care about the last 3 digits. if you do not do this, the m=1000 will fail because there is not enough space for a number that
                                   //big in int.
                if (exists.ContainsKey(y))
                {
                    yield break;
                }

                exists[y] = true;//this is the same thing as saying exists.Add(y,true) the true does not matter just need a value for the dictionary key.
                yield return y;


            }



        }
    }
}