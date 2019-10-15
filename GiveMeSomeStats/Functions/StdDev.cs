using System;
using System.Collections.Generic;
using System.Linq;
using GiveMeSomeStats.Interface;

namespace GiveMeSomeStats.Functions
{
    public class StdDev : ICalculate
    {
        public double Calculate(List<double> values)
        {

            // 1.  Calculate Mean / simple average of the numbers.
            // 2.  Subtract mean from each number and square the result / For each number: subtract the mean. Square the result.
            // 3.  Add all those squared numbers / Add up all of the squared results.
            // 4. Divide added squared numbers by number of numbers

            var mean = values.Average();
            var diffSquaredArray = new double[values.Count];

            for (var i = 0; i < diffSquaredArray.Length; i++)
            {
                diffSquaredArray[i] = Math.Pow(values[i] - mean, 2);
            }

            var diffSquaredMean = diffSquaredArray.Sum();

            return Math.Sqrt(diffSquaredMean / diffSquaredArray.Length);
        }
    }
}
