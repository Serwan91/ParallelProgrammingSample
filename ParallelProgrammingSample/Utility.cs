using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelProgrammingSample
{
    class Utility
    {
        static Random _random = null;

        public static int Next(int start,int end)
        {
            if (_random == null)
                _random = new Random();
            return _random.Next(start,end);
        }
    }
}
