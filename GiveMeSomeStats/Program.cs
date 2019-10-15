using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GiveMeSomeStats.Functions;
using GiveMeSomeStats.Interface;

namespace GiveMeSomeStats
{
    internal class Program
    {
        private static List<double> _numbers;
        private static readonly ICalculate CalculateAvg;
        private static readonly ICalculate CalculateMax;
        private static readonly ICalculate CalculateMin;
        private static readonly ICalculate CalculateStdDev;
        /// <summary>
        /// Initializes a new instance of the Program class.
        /// </summary>
        static Program()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            CalculateAvg = new Avg();
            CalculateMax = new Max();
            CalculateMin = new Min();
            CalculateStdDev = new StdDev();
        }

        private static int Main(string[] args)
        {
            // Test if input arguments were supplied.
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide Values Separated by Comma Below.");
                Console.WriteLine("Usage: 11,22,34534,6456 or 11, 22, 34534, 6456");
                Console.ReadLine();
                return 1;
            }



            //11, 22, 34534, 6456
            //-1.1, -4, -5, -6
            if (args.Length > 1)
            {
                var list = new List<string>();
                //Remove non-digits from the args
                var arr = new string[args.Length];
                for (var i = 0; i <= args.Length - 1; i++)
                {
                    var arg = args[i].Split(separator: new[] {','},
                        options: StringSplitOptions.RemoveEmptyEntries);

                    foreach (var a in arg)
                    {
                        if (Regex.IsMatch(a, @"[^\d|\.\-]", RegexOptions.Compiled))
                        {
                            Console.WriteLine("Please provide numbers only");
                            Console.WriteLine("Usage: 11,22,34534,6456 or 11, 22, 34534, 6456");
                            Console.ReadLine();
                            return 1;
                        }
                        list.Add(a);
                        
                    }

                    //var s = Regex.Replace(args[i], @"[^\d|\.\-]", "", RegexOptions.Compiled);
                    //if (int.TryParse(s, out _))
                    //{
                    //    arr[i] = s;

                    //}

                    //if (decimal.TryParse(s, out _))
                    //{
                    //    arr[i] = s;
                    //}

                    //if (long.TryParse(s, out _))
                    //{
                    //    arr[i] = s;
                    //}

                }

                //convert the input arguments to numbers
                _numbers = list.Where(val => double.TryParse(val, out _)).Select(double.Parse).ToList();

            }

            //11,22,34534,6456
            if (args.Length == 1)
            {
                //convert the input arguments to numbers
                _numbers = args[0].Split(separator: new[] {','},
                        options: StringSplitOptions.RemoveEmptyEntries)
                    .Where(val => double.TryParse(val, out _))
                    .Select(double.Parse)
                    .ToList();

            }

            if (!_numbers.Any())
            {
                Console.WriteLine("Please provide numbers only");
                Console.WriteLine("Usage: 11,22,34534,6456 or 11, 22, 34534, 6456");
                Console.ReadLine();
                return 1;
            }


            Console.WriteLine("Sorted data:");
            _numbers.ForEach(n => Console.Write("{0}\t", n));

            var max = CalculateMax.Calculate(_numbers);
            var min = CalculateMin.Calculate(_numbers);
            var avg = CalculateAvg.Calculate(_numbers);
            var stdDev = CalculateStdDev.Calculate(_numbers);

            _numbers.Sort();

            UpdateUi(max, min, avg, stdDev);
            Console.ReadLine();
            return 0;
        }



        /// <summary>
        /// Draws results on the screen.
        /// </summary>
        private static void UpdateUi(double max, double min, double avg, double stdDev)
        {
            Console.SetCursorPosition(0, 10);
            Console.WriteLine($"Maximum number is:        {max}");
            Console.WriteLine($"Minimum number is:        {min}");
            Console.WriteLine($"Average is:        {avg}");
            Console.WriteLine($"Std Deviation is:        {stdDev}");


        }
    }
}
