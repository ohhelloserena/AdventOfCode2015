using System;
using System.Text;

namespace AdventOfCode2015
{
    public class Day04
    {
        public string input = "bgvyzdsv";
        //public string input = "pqrstuv";

        public void Run()
        {
            FindLowestNumber("00000", "00000".Length);
            FindLowestNumber("000000", "000000".Length);
        }

        private void FindLowestNumber(string zeros, int length)
        {
            int count = 0;
            bool found = false;

            while (!found)
            {
                string newInput = count == 0 ? input : input + count.ToString();

                System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(newInput);
                byte[] hash = md5.ComputeHash(inputBytes);

                // step 2, convert byte array to hex string
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }

                string stringHash = sb.ToString();
                found = stringHash.Substring(0, length).Equals(zeros);

                if (found) break;

                count++;
            }

            Console.WriteLine(zeros + ": " + count);
        }
    }
}
