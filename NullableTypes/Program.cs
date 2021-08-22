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

            while (adjacentNumsList.Contains("-1"))
                adjacentNumsList.Remove("-1");
            if(observed.Length == 1)
            {
                adjacentNumsList.Remove(" ");
                return adjacentNumsList;
            }
            //Если пришло много чисел, перебираем варианты
            string[][] adjacentNumsStringArray = new string[observed.Length][]; /*Преобразовываем в массив массивов строк для удобства обработки*/
            for (int i = 0; i < observed.Length; i++)
            {
                int indexOfSplitter = adjacentNumsList.IndexOf(" ");
                string[] tempArr = new string[indexOfSplitter];
                for (int j = 0; j < indexOfSplitter; j ++)
                    tempArr[j] = adjacentNumsList[j];
                adjacentNumsList.RemoveRange(0, indexOfSplitter + 1);
                adjacentNumsStringArray[i] = tempArr;
            }


            AddAllCombinations(adjacentNumsList, observed.Length);
            return adjacentNumsList;
            
            
            
        }
        static List<string> AddAllCombinations(List<string> adjacentNumsList, int rows)
        {
            string[][] adjacentNumsStringArray = new string[rows][]; /*Преобразовываем в массив массивов строк для удобства обработки*/
            for (int i = 0; i < rows; i++)
            {
                int indexOfSplitter = adjacentNumsList.IndexOf(" ");
                string[] tempArr = new string[indexOfSplitter];
                for (int j = 0; j < indexOfSplitter; j++)
                    tempArr[j] = adjacentNumsList[j];
                adjacentNumsList.RemoveRange(0, indexOfSplitter + 1);
                adjacentNumsStringArray[i] = tempArr;
            }
            List<string> pairNumsCombinations = new List<string>();
             for (int i = 0; i < adjacentNumsStringArray.Length; i += 2)
                for (int j = 0; j < adjacentNumsStringArray[i].Length; j++)
                {

                        for (int s = 0; s < adjacentNumsStringArray[i + 1].Length; s++)
                        {
                            string result = adjacentNumsStringArray[i][j].ToString() + adjacentNumsStringArray[i + 1][s];
                            pairNumsCombinations.Add(result);
                        }
                        pairNumsCombinations.Add(" ");
                }
                
            foreach(string s in pairNumsCombinations)
                Console.WriteLine(s);
            return pairNumsCombinations;
            
        }
    }
}
