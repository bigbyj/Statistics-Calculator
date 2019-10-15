using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GiveMeSomeStats.Functions;
using GiveMeSomeStats.Interface;

namespace GiveMeSomeStats
{
    internal class Program
    {
        private static List<int> _numbers;
        private static ICalculate _iCalculateAvg;
        private static ICalculate _iCalculateMax;
        /// <summary>
        /// Initializes a new instance of the Program class.
        /// </summary>
        static Program()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            _iCalculateAvg = new Avg();
            _iCalculateMax = new Max();
        }

        private static int Main(string[] args)
        { // Test if input arguments were supplied.
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide Values Separated by Comma Below.");
                Console.WriteLine("Usage: 11,22,34534,6456");
                Console.ReadLine();
                return 1;

            }



            if (args.Length == 1)
            {

                _numbers = args[0].Split(separator: new char[] {','},
                        options: StringSplitOptions.RemoveEmptyEntries)
                    .Where(val => int.TryParse(val, out _))
                    .Select(val => int.Parse(val))
                    .ToList();
            }


            Console.WriteLine("Sorted data:");
            _numbers.ForEach(n => Console.Write("{0}\t", n));
           
            var result = _iCalculateAvg.Calculate(_numbers);
            var result2 = _iCalculateMax.Calculate(_numbers);

            var success = 0;
            var failed = 0;
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            _numbers.Sort();

            UpdateUI(success, failed,result, result2);
            Console.ReadLine();
            return 0;
        }



        /// <summary>
        /// Draws statistics on the screen.
        /// </summary>
        private static void UpdateUI(int success, int failed, double result, double result2)
        {
            Console.SetCursorPosition(0, 10);
            Console.WriteLine($"Successfully calculated:   {success}");
            Console.WriteLine($"Failed to calculate:        {failed}");
            Console.WriteLine($"Average:        {result}");
            Console.WriteLine($"Maximum number:        {result2}");

        }
    }
}
