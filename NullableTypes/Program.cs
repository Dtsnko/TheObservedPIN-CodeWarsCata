using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime;
using System.Collections;

namespace NullableTypes
{
    class Program
    {
        static void Main(string[] args)
        {

            while (1 > 0)
                ToDecimalDigit(Console.ReadLine());
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
                foreach (string s in adjacentNumsList)
                    Console.WriteLine(s);
                return adjacentNumsList;
            }
            //Если пришло много чисел, перебираем варианты
            int rows = observed.Length;
            while (adjacentNumsList[0].Length != observed.Length)
            {
                adjacentNumsList = AddAllCombinations(adjacentNumsList, rows);
                rows /= 2;
            }
            foreach(string s in adjacentNumsList)
                Console.WriteLine(s);
            adjacentNumsList.Remove(" ");
            return adjacentNumsList;
            
            
            
        }
        static List<string> AddAllCombinations(List<string> adjacentNumsList, int rows)
        {
            string[][] adjacentNumsStringArray = new string[rows][]; /*Преобразовываем в массив массивов строк для удобства обработки*/
            for (int i = 0; i < rows; i++)
            {
                int indexOfSplitter = adjacentNumsList.IndexOf(" ");
                Console.WriteLine(indexOfSplitter);
                string[] tempArr = new string[indexOfSplitter];
                for (int j = 0; j < indexOfSplitter; j++)
                    tempArr[j] = adjacentNumsList[j];
                adjacentNumsList.RemoveRange(0, indexOfSplitter + 1);
                adjacentNumsStringArray[i] = tempArr;
            }
            List<string> pairNumsCombinations = new List<string>();
            for (int i = 0; i < adjacentNumsStringArray.Length; i += 2) //разбиваем по парам
            {

                for (int j = 0; j < adjacentNumsStringArray[i].Length; j++) //в кажой паре рядов делаем пары чисел
                {
                    for (int s = 0; s < adjacentNumsStringArray[i + 1].Length; s++)
                    {
                        string result = adjacentNumsStringArray[i][j].ToString() + adjacentNumsStringArray[i + 1][s];
                        if (i + 3 == adjacentNumsStringArray.Length) // если рядов не четное колличество, добавляем в конце все столбцы нечетного ряда
                            for (int g = 0; g < adjacentNumsStringArray[i + 2].Length; g++)
                                pairNumsCombinations.Add(result + adjacentNumsStringArray[i + 2][g]);
                        else
                            pairNumsCombinations.Add(result);
                    }

                }
                pairNumsCombinations.Add(" ");
                if (i + 3 == adjacentNumsStringArray.Length)
                    return pairNumsCombinations;
            }
            return pairNumsCombinations;
            
        }
    }
}
