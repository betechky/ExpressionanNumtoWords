using System;
using System.IO;
using System.Numerics;
using System.Text.Json;
using System.Collections.Generic;

namespace NumbertoWords
{
    class Program
    {
        static void Main(string[] args)
        {
            // 018,456,000,000,000,000,000
            string userInput = "18456000000000000000";
            BigInteger bi = BigInteger.Parse(userInput);
            Console.WriteLine("\n======================================================\n");
            Console.WriteLine("The Words Conversion for " + userInput + " is" + "\n");
            Console.WriteLine("\n======================================================\n");
            Console.WriteLine(ToWords(bi));
            Console.WriteLine("\n======================================================\n");

         }
       
        public static string ToWords(BigInteger number)
        {
            string[] partsByThree = number.ToString("N0").Split(",");
            string res = string.Empty;

            for (int i = 0; i < partsByThree.Length; i++)
            {
                if (partsByThree[i] != "000")
                {
                    res += !string.IsNullOrEmpty(res) ? " " : " ";
                    res += PartToWords(partsByThree[i]);
                    res += " " + LargeNumberToWord(partsByThree.Length - i - 1);
                }
            }

            return res;
        }
        public static string LargeNumberToWord(int value)
        {
            string[] largeMap = ReadFromFile("LargeNumbers.txt");
            
            return largeMap[value];
        }
        public static string[] ReadFromFile(string path)
        {
            string[] names = File.ReadAllLines(path);

            return names;
        }
        public static string PartToWords(string part)
        {
            part = part.PadLeft(3, '0');

            string[] unitsMap = ReadFromFile("unitsMap.txt");

            

            string[] tensMap = ReadFromFile("tensMap.txt");
          

            int index;
            string result = string.Empty;

            // transform hundreds
            if (part[0] != '0')
            {
                index = Convert.ToInt32(part[0].ToString());
                result += unitsMap[index] + " hundred";
            }

            // transform teens
            string tens = string.Empty;
            if (part[1] == '1')
            {
                index = Convert.ToInt32(part[1].ToString() + part[2].ToString());
                tens = unitsMap[index];

                result += string.IsNullOrEmpty(result) ? "" : " and ";
                result += tens;

                return result;
            }
            else if (part[1] != '0')
            {
                index = Convert.ToInt32(part[1].ToString());
                tens = tensMap[index];
            }

            string oneDigit = string.Empty;

            if (part[2] != '0')
            {
                index = Convert.ToInt32(part[2].ToString());
                oneDigit = unitsMap[index];
            }

            // 5 9 0
            result += !string.IsNullOrEmpty(result)
                      && !string.IsNullOrEmpty(tens) ? " and " : "";
            result += tens;

            // 5 0 1   5 and 1 
            result += !string.IsNullOrEmpty(result)
                        && string.IsNullOrEmpty(tens)
                        && !string.IsNullOrEmpty(oneDigit) ? " and " : "";

            result += !string.IsNullOrEmpty(tens)
                       && !string.IsNullOrEmpty(oneDigit) ? "-" : "";
            result += oneDigit;

            return result;
        }


    }
}
