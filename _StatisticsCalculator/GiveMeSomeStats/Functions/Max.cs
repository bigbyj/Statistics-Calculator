using System;
using System.Collections.Generic;
using System.Linq;
using GiveMeSomeStats.Interface;

namespace GiveMeSomeStats.Functions
{
    public class Max : ICalculate
    {
        public double Calculate(int x, int y)
        {
            throw new NotImplementedException();
        }

        public double Calculate(List<int> values)
        {
            return values.Max();
        }
    }
}
