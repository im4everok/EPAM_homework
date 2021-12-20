using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayObject
{
    public static class ArrayTasks
    {
        public static void ChangeElementsInArray(int[] nums)
        {
            int temp;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i >= nums.Length / 2)
                {
                    if (nums[i] % 2 == 0 && nums[nums.Length - i - 1] % 2 == 0)
                    {
                        temp = nums[i];
                        nums[i] = nums[nums.Length - i - 1];
                        nums[nums.Length - i - 1] = temp;
                    }
                }
            }
        }

        public static int DistanceBetweenFirstAndLastOccurrenceOfMaxValue(int[] nums)
        {
            if (nums != null && nums.Any())
            {
                int maxToCmp = nums.Max();
                var indexList = new List<int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (maxToCmp == nums[i])
                    {
                        indexList.Add(i);
                    }
                }
                int maxInd = indexList.Max();
                int firstInd = indexList.Min();

                return maxInd - firstInd;
            }
            return 0;
        }

        public static void ChangeMatrixDiagonally(int[,] matrix)
        {
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 1; j < matrix.GetLength(1); j++)
                {
                    if(i != j)
                    {
                        matrix[j, i] = 0;
                    }
                }
            }
            for(int l = 0; l < matrix.GetLength(0) - 1; l++)
            {
                for (int k = 1; k < matrix.GetLength(1); k++)
                {
                    if (l != k && l < k)
                    {
                        matrix[l, k] = 1;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            //Method is empty (SONAR DON'T BEAT ME PLS!!!)
        }
    }
    
}
