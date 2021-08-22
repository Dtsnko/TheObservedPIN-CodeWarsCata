using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime;
using System.Collections;

namespace NullableTypes
{
    class Program
    {
        int n = 0;
        int countedArray = 0;
        static void Main(string[] args)
        {

            for (bool status = true; status != false;)
            {
                string s = Console.ReadLine();
                if (s == "false")
                    return;
                else
                    foreach (string str in ToDecimalDigit(s))
                        Console.WriteLine(str);

            }
        }
        public static List<string> ToDecimalDigit(string observed)
        {
            int[] nums = new int[observed.Length];
            List<string> adjacentNumsList = new List<string>();
            int[,] example = {  { 1, 2, 3 },
                                { 4, 5, 6 },
                                { 7, 8, 9 },
                                { -1, 0, -1 }
                             };
            for (int i = 0; i < nums.Length; i++)
                nums[i] = Convert.ToInt32(observed.Substring(i, 1));
            for (int b = 0; b < nums.Length; b++)
            {
                int x = 0, y = 0;
                for (int i = 0; i < example.Length / (example.GetUpperBound(1) + 1); i++)
                    for (int f = 0; f < example.GetUpperBound(1) + 1; f++)
                        if (example[i, f] == nums[b])
                        {
                            x = f;
                            y = i;
                            break;
                        }
                try
                {
                    adjacentNumsList.Add(example[y, x].ToString());
                }
                catch { }
                try
                {
                    adjacentNumsList.Add(example[y, x + 1].ToString());
                }
                catch { }
                try
                {
                    adjacentNumsList.Add(example[y, x - 1].ToString());
                }
                catch { }
                try
                {
                    adjacentNumsList.Add(example[y + 1, x].ToString());
                }
                catch { }
                try
                {
                    adjacentNumsList.Add(example[y - 1, x].ToString());
                }
                catch { }
                adjacentNumsList.Add(" ");
            }
            string result = "";
            while (adjacentNumsList.Contains("-1"))
                adjacentNumsList.Remove("-1");
            foreach (string i in adjacentNumsList)
                result += i;
            result = result.Trim();
            string[] adjacentNumsStringArray = result.Split(" ");
            char[][] adjacentNumsCharArray = new char[adjacentNumsStringArray.Length][];
            adjacentNumsList.Clear();
            for (int i = 0; i < adjacentNumsCharArray.Length; i++)
                adjacentNumsCharArray[i] = adjacentNumsStringArray[i].ToCharArray();
            if (adjacentNumsCharArray.Length == 1)
            {
                for (int i = 0; i < adjacentNumsCharArray.Length; i++)
                    for (int j = 0; j < adjacentNumsCharArray[i].Length; j++)
                        adjacentNumsList.Add(adjacentNumsCharArray[i][j].ToString());
                return adjacentNumsList;
            }
            //Если пришло много чисел, перебираем варианты
           for(int i = 0; i < adjacentNumsCharArray.Length; i++)
                for(int g = 0; g < adjacentNumsCharArray[i].Length; g++)
                    
            return adjacentNumsList;
            
            
            
        }
        static void AddAllCombinations(string[][] nums)
        {
            List<string> pairNumsCombinations = new List<string>();
            int iterator = nums.Length / 2;
            for(int i = 0; i < nums.Length; i += 2)
            {
                for (int j = 0; j < nums[i].Length; j++)
                    for (int s = 0; s < nums[i + 1].Length; s++)
                    {
                        string result = nums[i][j].ToString() + nums[i + 1][s];
                        pairNumsCombinations.Add(result);
                    }
                pairNumsCombinations.Add(" ");

            }
            foreach(string s in pairNumsCombinations)
                Console.WriteLine(s);
            
            
        }
    }
}
