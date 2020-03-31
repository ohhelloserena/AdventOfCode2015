using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2015
{
    public class Day08
    {
        private string[] input = System.IO.File.ReadAllLines(@"/Users/serenachen/RiderProjects/AdventOfCode2015/AdventOfCode2015/day08input");

        public void Run()
        {
            //PartOne();
            PartTwo();
        }

        public void PartOne()
        {
            int codeRepLength = 0;
            int inMemoryLength = 0;

            foreach (string item in input)
            {
                codeRepLength += item.Length;

                string str = item.ToString();
                string result = str.Replace(@"\\", "J");
                result = result.Replace(@"\""", "H");

                string pattern = @"\\x[\w\d]{2}";
                string replacement = "Y";
                result = Regex.Replace(result, pattern, replacement);

                string resultSubstring = result.Substring(1, result.Length - 2);

                inMemoryLength += resultSubstring.Length;
            }

            Console.WriteLine("Day 8, Part 1: " + (codeRepLength - inMemoryLength));

        }

        public void PartTwo()
        {
            int codeRepLength = 0;
            int inMemoryLength = 0;

            foreach (string item in input)
            {
                Console.WriteLine(item);

                codeRepLength += item.Length;

                string str = item.ToString();
                string result = str.Replace(@"\""", "HHHH");
                result = result.Replace(@"\\", "JJJJ");
                string pattern = @"\\x[\w\d]{2}";
                string replacement = "YYYYY";
                result = Regex.Replace(result, pattern, replacement);

                inMemoryLength = inMemoryLength + result.Length + 4;

            }
            Console.WriteLine("Day 8, Part 2: " + (inMemoryLength - codeRepLength));
        }

        

        

    }
}
