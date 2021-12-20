using System;
using System.Collections.Generic;

namespace LoopTasks
{
    public static class LoopTasks
    {
        public static int SumOfOddDigits(int n)
        {
            int result = 0;
            List<int> oddNumsList = new List<int>();
            while (n > 0)
            {
                oddNumsList.Add(n % 10);
                n /= 10;
            }
            oddNumsList.Reverse();
            foreach (var number in oddNumsList)
            {
                if(number % 2 != 0)
                {
                    result += number;
                }
            }
            return result;
        }

        public static int NumberOfUnitsInBinaryRecord(int n)
        {
            int result = 0;
            List<int> nList = new List<int>();
            while (n > 0)
            {
                nList.Add(n % 2);
                n /= 2;
            }
            nList.Reverse();
            foreach(var number in nList)
            {
                if(number == 1)
                {
                    result++;
                }
            }
            return result;
        }

        public static int SumOfFirstNFibonacciNumbers(int n)
        {
            int result = 0;
            List<int> fibNumList = new List<int>();
            for(int i = 0; i < n; i++)
            {
                if(i == 0) fibNumList.Add(0);
                if (i == 1 || i == 2) fibNumList.Add(1);
                if(i > 2)
                {
                    fibNumList.Add(fibNumList[i - 1] + fibNumList[i - 2]);
                }            
            }
            foreach(var number in fibNumList)
            {
                result += number;
            }
            return result;
        }
        static void Main(string[] args)
        {

        }
    }
}
