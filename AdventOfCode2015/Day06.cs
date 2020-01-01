using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2015
{
    public class Day06
    {
        private string[] input = System.IO.File.ReadAllLines(@"/Users/serenachen/RiderProjects/AdventOfCode2015/AdventOfCode2015/day06input");

        public void Run()
        {
            //PartOne();
            PartTwo();
        }

        public void PartTwo()
        {
            int[,] lights = new int[1000, 1000];
            int brightnessCount = 0;

            foreach (var item in input) 
            {
                string instruction = this.ParseInstruction(item);

                List<int> start = new List<int>();
                List<int> end = new List<int>();

                start = this.ParseStart(item);
                end = this.ParseEnd(item);

                int startX = start[0];
                int startY = start[1];

                int endX = end[0];
                int endY = end[1];

                for (int i = startX; i <= endX; i++)
                {
                    for (int j = startY; j <= endY; j++)
                    {
                        if (instruction == "on")
                        {
                            lights[i, j] = lights[i, j] + 1;
                        }
                        else if (instruction == "off")
                        {
                            if (lights[i, j] > 0)
                            {
                                lights[i, j] = lights[i, j] - 1;
                            }
                        }
                        else
                        {
                            //instruction == "toggle"

                            lights[i, j] = lights[i, j] + 2;
                        }
                    }
                }
            }

            for (int i = 0; i < lights.GetLength(0); i++)
            {
                for (int j = 0; j < lights.GetLength(1); j++)
                {
                    brightnessCount = brightnessCount + lights[i, j];
                }
            }

           
            Console.WriteLine("Part 2: " + brightnessCount);
        }

        private void PartOne()
        {
            int[,] lights = new int[1000, 1000];
            int brightnessCount = 0;

            foreach (var item in input)
            {
                string instruction = this.ParseInstruction(item);

                List<int> start = new List<int>();
                List<int> end = new List<int>();

                start = this.ParseStart(item);
                end = this.ParseEnd(item);

                int startX = start[0];
                int startY = start[1];

                int endX = end[0];
                int endY = end[1];

                for (int i = startX; i <= endX; i++)
                {
                    for (int j = startY; j <= endY; j++)
                    {
                        if (instruction == "on")
                        {
                            lights[i, j] = 1;
                        }
                        else if (instruction == "off")
                        {
                            lights[i, j] = 0;
                        }
                        else
                        {
                            //instruction == "toggle"

                            if (lights[i, j] == 1)
                            {
                                lights[i, j] = 0;
                            }
                            else
                            {
                                //light is not set or off
                                lights[i, j] = 1;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < lights.GetLength(0); i++)
            {
                for (int j = 0; j < lights.GetLength(1); j++)
                {
                    if (lights[i, j] == 1) brightnessCount++;
                }
            }

            Console.WriteLine("Part 1: " + brightnessCount);
        }

        private string ParseInstruction(string input)
        {
            string[] array = input.Split(' ');

            if (array[0].ToString() == "turn")
            {
                return array[1].ToString();
            }

            return array[0].ToString();
        }

        private List<int> ParseStart(string input)
        {
            
            string[] array = input.Split(' ');
            string temp = string.Empty;

            if (array[0].ToString() == "turn")
            {
                temp = array[2].ToString();
            }
            else
            {
                temp = array[1].ToString();
            }


            string[] tempArray = temp.Split(',');

            int x = this.ConvertToInteger(tempArray[0]);
            int y = this.ConvertToInteger(tempArray[1]);

            List<int> result = new List<int>();
            result.Add(x);
            result.Add(y);

            return result;

        }

        private List<int> ParseEnd(string input)
        {
            string[] array = input.Split(' ');
            string temp = string.Empty;

            if (array[0].ToString() == "turn")
            {
                temp = array[4].ToString();
            }
            else
            {
                temp = array[3].ToString();
            }

            string[] tempArray = temp.Split(',');

            int x = this.ConvertToInteger(tempArray[0]);
            int y = this.ConvertToInteger(tempArray[1]);

            List<int> result = new List<int>();
            result.Add(x);
            result.Add(y);

            return result;

        }


        private int ConvertToInteger(string str)
        {
            try
            {
                int start = Int32.Parse(str);
                return start;
            }
            catch(FormatException e)
            {
                return -1;
            }
        }

        

    }
}
