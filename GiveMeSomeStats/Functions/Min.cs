using System;
using System.Collections.Generic;
using System.Linq;
using GiveMeSomeStats.Interface;

namespace GiveMeSomeStats.Functions
{
    public class Min : ICalculate
    {
        public double Calculate(List<double> values)
        {
            return values.Min();
        }
    }
}
