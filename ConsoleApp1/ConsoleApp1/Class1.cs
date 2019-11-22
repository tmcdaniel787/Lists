using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Calculation : IEnumerable<long>
    {
        private int m;
        public Calculation(int m)
        {
            this.m = m;
        }
        public IEnumerator<long> GetEnumerator()
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

        IEnumerator IEnumerable.GetEnumerator()
        {

            return GetEnumerator();
        }
    }
}
