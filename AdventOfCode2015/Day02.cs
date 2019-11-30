using System;

namespace AdventOfCode2015
{
    public class Day02
    {
        private string[] input = System.IO.File.ReadAllLines(@"/Users/serenachen/RiderProjects/AdventOfCode2015/AdventOfCode2015/day02input");

        //private string[] input = { "2x3x4" };

        public void Run()
        {
            //PartOne();
            PartTwo();

        }

        private void PartOne()
        {
            int total = 0;

            foreach (string i in input)
            {
                string[] split = i.Split('x');
                int width = this.GetWidth(split);
                int length = this.GetLength(split);
                int height = this.GetHeight(split);

                int lengthWidth = length * width;
                int widthHeight = width * height;
                int heightLength = height * length;
                int min = this.GetMin(lengthWidth, widthHeight, heightLength);

                total += 2 * (lengthWidth + widthHeight + heightLength) + min;
            }

            Console.WriteLine("Part 1: " + total);
        }

        private void PartTwo()
        {
            int total = 0;

            foreach (string i in input)
            {
                string[] split = i.Split('x');
                int width = this.GetWidth(split);
                int length = this.GetLength(split);
                int height = this.GetHeight(split);

                int lengthWidth = length + width;
                int widthHeight = width + height;
                int heightLength = height + length;
                int min = this.GetMin(lengthWidth, widthHeight, heightLength);

                total += (2 * min) + (width * length * height);
            }

            Console.WriteLine("Part 2: " + total);
        }

        private int GetWidth(string[] split)
        {
            return Int32.Parse(split[0]);
        }

        private int GetLength(string[] split)
        {
            return Int32.Parse(split[1]);
        }

        private int GetHeight(string[] split)
        {
            return Int32.Parse(split[2]);
        }

        private int GetMin(int num1, int num2, int num3)
        {
            int low;
            low = num1 < num2 ? num1 : num2;
            low = low < num3 ? low : num3;
            return low;
        }

    }
}