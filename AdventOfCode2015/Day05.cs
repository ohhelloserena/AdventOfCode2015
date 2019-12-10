using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2015
{
    public class Day05
    {
        private string[] input = System.IO.File.ReadAllLines(@"/Users/serenachen/RiderProjects/AdventOfCode2015/AdventOfCode2015/day05input");

        public void Run()
        {
            //PartOne();
            PartTwo();
        }

        public void PartOne()
        {
            int niceCount = 0;

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

                if (vowelCount > 2 && foundRepeatedLetter && !foundBanned) niceCount++;

                //reset variables
                vowelCount = 0;
                foundRepeatedLetter = false;
                lastLetter = string.Empty;
                foundBanned = false;
            }

            Console.WriteLine("Part 1: " + niceCount);
        }

        private void PartTwo()
        {
            int niceCount = 0;

            foreach (var currentString in input)
            {
                bool containsPair = this.HasRepeatingPair(currentString);
                bool containsRepeating = this.HasOneRepeatingLetter(currentString);

                if (containsPair && containsRepeating)
                {
                    niceCount++;
                }

            }

            Console.WriteLine("Part 2: " + niceCount);
        }

        private bool HasRepeatingPair(string currentString)
        {
            int start = 0;
            string prev = string.Empty;

            while (start + 2 <= currentString.Length)
            {
                prev = currentString.Substring(start, 2);
        
                string[] array = currentString.ToCharArray().Select(c => c.ToString()).ToArray();

                for (int i = start + 2; i < array.Length; i++)
                {
                    if (i + 2 <= array.Length)
                    {
                        string curr = currentString.Substring(i, 2);

                        if (prev.Equals(curr))
                        {
                            return true;
                        }
                    }
                }

                start++;
            }

            return false;
        }

        private bool HasOneRepeatingLetter(string currentString)
        {
            int start = 0;
            string prev = string.Empty;
            string curr = string.Empty;

            while (start + 2 < currentString.Length)
            {
                prev = currentString.Substring(start, 1);

                curr = currentString.Substring(start + 2, 1);

                if (prev.Equals(curr)) return true;

                start++;
            }

            return false;
        }

    }
}
