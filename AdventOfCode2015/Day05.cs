using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2015
{
    public class Day05
    {
        private string[] input = System.IO.File.ReadAllLines(@"/Users/serenachen/RiderProjects/AdventOfCode2015/AdventOfCode2015/day05input");
        //private string[] input = { "ugknbfddgicrmopn" };
        public void Run()
        {
            PartOne();
        }

        public void PartOne()
        {
            int naughtyCount = 0;

            int vowelCount = 0;
            string lastLetter = string.Empty;
            bool foundRepeatedLetter = false;
            bool foundBanned = false;

            HashSet<string> vowels = new HashSet<string>();
            vowels.Add("a");
            vowels.Add("e");
            vowels.Add("i");
            vowels.Add("o");
            vowels.Add("u");

            HashSet<string> banned = new HashSet<string>();
            banned.Add("ab");
            banned.Add("cd");
            banned.Add("pq");
            banned.Add("xy");

            foreach (string i in input)
            {
                string[] array = i.ToCharArray().Select(c => c.ToString()).ToArray();

                foreach (string currLetter in array)
                {
                    //check for vowels
                    if (vowels.Contains(currLetter)) vowelCount++;

                    //check for repeating letters
                    if (!string.IsNullOrEmpty(lastLetter) && lastLetter.Equals(currLetter))
                    {
                        foundRepeatedLetter = true;
                    }

                    //check for banned strings
                    if (!string.IsNullOrEmpty(lastLetter) && banned.Contains(lastLetter + currLetter))
                    {
                        foundBanned = true;
                        break;
                    }

                    lastLetter = currLetter;
                }

                if (vowelCount > 2 && foundRepeatedLetter && !foundBanned) naughtyCount++;

                //reset variables
                vowelCount = 0;
                foundRepeatedLetter = false;
                lastLetter = string.Empty;
                foundBanned = false;
            }

            Console.WriteLine("Part 1: " + naughtyCount);
        }

    }
}
