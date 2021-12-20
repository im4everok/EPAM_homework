using System;

namespace Condition
{
    public static class Condition
    {       
        public static int Task1(int n)
        {
            if (n != 0)
            {
                return n > 0 ? n * n : Math.Abs(n);
            }
            return 0;
        }
        public static int Task2(int n)
        {
            if (n > 999 || n < 100) throw new ArgumentException("Function argument must fit the 99 < n < 1000 limit !!!");
            string temp;
            string[] newInt = new string[3];
            string result;
            int res;
            for(int i = 2; i >= 0; i--)
            {
                newInt[i] = (n % 10).ToString();
                n /= 10;
            }
            for(int j = 0; j < newInt.Length; j++)
            {
                for(int l = newInt.Length - 1; l >= 0; l--)
                {
                    if(Convert.ToInt32(newInt[l]) > Convert.ToInt32(newInt[j]))
                    {
                        temp = newInt[j];
                        newInt[j] = newInt[l];
                        newInt[l] = temp;
                    }
                    else
                    {
                        temp = newInt[l];
                        newInt[l] = newInt[j];
                        newInt[j] = temp;
                    }
                }
            }
            result = string.Concat(newInt);
            res = Convert.ToInt32(result);
            return res;
        }
    }
}
