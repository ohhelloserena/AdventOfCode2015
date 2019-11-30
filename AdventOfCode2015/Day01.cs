using System;
namespace AdventOfCode2015
{
    public class Day01
    {
        private string[] input = System.IO.File.ReadAllLines(@"/Users/serenachen/RiderProjects/AdventOfCode2015/AdventOfCode2015/day01input");

        public void Run()
        {

            char[] splitInput = input[0].ToCharArray();

            PartOne(splitInput);
            PartTwo(splitInput);

        }

        private void PartOne(char[] splitInput)
        {
            int openBracketCount = 0;
            int closeBracketCount = 0;


            foreach (char i in splitInput)
            {

                openBracketCount = i.ToString() == "(" ? ++openBracketCount : openBracketCount;
                closeBracketCount = i.ToString() == ")" ? ++closeBracketCount : closeBracketCount;
            }

            int floor = openBracketCount - closeBracketCount;

            Console.WriteLine("Part 1: " + floor);
        }

        private void PartTwo(char[] splitInput)
        {
            int currentFloor = 0;
            int index = 0;

            foreach (char i in splitInput)
            {
                index++;
                currentFloor = i.ToString() == "(" ? ++currentFloor : --currentFloor;

                if (currentFloor == -1)
                {
                    Console.WriteLine("Part 2: " + index);
                    break;
                }
            }

        }
    }
}
