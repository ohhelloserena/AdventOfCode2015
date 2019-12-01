using System;
using System.Collections.Generic;

namespace AdventOfCode2015
{
    public class Day03
    {
        private string[] input = System.IO.File.ReadAllLines(@"/Users/serenachen/RiderProjects/AdventOfCode2015/AdventOfCode2015/day03input");
        //private string[] input = { ">" };

        public void Run()
        {
            char[] splitInput = input[0].ToCharArray();

            PartOne(splitInput);
            PartTwo(splitInput);
        }

        private void PartOne(char[] splitInput)
        {
            int x = 0;
            int y = 0;
            HashSet<string> visited = new HashSet<string>();
            visited.Add(x.ToString() + "," + y.ToString());

            foreach (char i in splitInput)
            {
                string strInput = i.ToString();

                switch(strInput)
                {
                    case "^":
                        y++;
                        break;
                    case "<":
                        x--;
                        break;
                    case ">":
                        x++;
                        break;
                    case "v":
                        y--;
                        break;
                    default:
                        break;
                }

                string coordinates = x.ToString() + "," + y.ToString();
                visited.Add(coordinates);
            }

            Console.WriteLine("Part 1: " + visited.Count);
        }

        private void PartTwo(char[] splitInput)
        {
            int santaX = 0;
            int santaY = 0;

            int roboX = 0;
            int roboY = 0;

            bool isSantaTurn = true;

            HashSet<string> visited = new HashSet<string>();
            visited.Add(santaX.ToString() + "," + santaX.ToString());

            foreach (char i in splitInput)
            {
                string strInput = i.ToString();

                switch (strInput)
                {
                    case "^":
                        if (isSantaTurn)
                        {
                            santaY++;
                        }
                        else
                        {
                            roboY++;
                        }
                        break;
                    case "<":
                        if (isSantaTurn)
                        {
                            santaX--;
                        }
                        else
                        {
                            roboX--;
                        }
                        break;
                    case ">":
                        if (isSantaTurn)
                        {
                            santaX++;
                        }
                        else
                        {
                            roboX++;
                        }
                        break;
                    case "v":
                        if (isSantaTurn)
                        {
                            santaY--;
                        }
                        else
                        {
                            roboY--;
                        }
                        break;
                    default:
                        break;
                }

                string coordinates = isSantaTurn ? santaX + "," + santaY : roboX + "," + roboY;
                visited.Add(coordinates);
                isSantaTurn = isSantaTurn ? false : true;
            }

            Console.WriteLine("Part 2: " + visited.Count);
        }

    }

}
