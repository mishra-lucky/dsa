using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayBigIntMultiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num1 = { 4, 5, 6,7,8 };
            int[] num2 = { 8, 9,9,9 };

            int[] result = MultiplyArrays(num1, num2);
            Console.WriteLine(string.Join(",", result));
            Console.ReadLine();
        }

        private static int[] MultiplyArrays(int[] num1, int[] num2)
        {
            if (num1.Length == 0 || num2.Length == 0) return new int[0];

            int[] result = null;
            int zeroes = 0;
            for(int j= num2.Length-1; j >= 0; j--)
            {
                int[] subResult = new int[num1.Length + 1 + zeroes];
                int k = subResult.Length -1 - zeroes;
                int carry = 0;
                for(int i = num1.Length -1; i>=0; i--)
                {
                    int p = (num1[i] * num2[j]) + carry;
                    int r = p % 10;
                    carry = p / 10;
                    subResult[k--] = r;
                }
                subResult[k--] = carry;
                result = AddArrays(result, subResult);
                zeroes++;
            }
            result = removeExtraZeroesFromLeft(result);
            return result;
        }

        private static int[] removeExtraZeroesFromLeft(int[] result)
        {
            int zeroes = 0;
            if (result == null || result.Length == 0) return result;
            for (int i = 0; i < result.Length; i++)
                if (result[i] == 0)
                    zeroes++;
                else
                    break;

            int[] newRes = new int[result.Length - zeroes];
            for (int i = 0; i < newRes.Length; i++)
                newRes[i] = result[i+zeroes];

            return newRes;
        }

        private static int[] AddArrays(int[] arr1, int[] arr2)
        {
            if (arr1 == null || arr1.Length == 0)
                return arr2;
            if (arr2 == null || arr2.Length == 0)
                return arr1;

            int[] larger = arr1.Length > arr2.Length ? arr1 : arr2;
            int[] smaller = arr1.Length > arr2.Length ? arr2 : arr1;
            

            int[] result = new int[larger.Length + 1];

            smaller = padLeftWithZero(ref smaller, larger.Length);
            int carry = 0;
            int k = result.Length - 1;
            for(int i =smaller.Length -1; i >=0; i--)
            {
                int s = smaller[i] + larger[i] + carry;
                result[k--] = s%10;
                carry = s / 10;
            }
            result[k--] = carry;
            return result;
        }

        private static int[] padLeftWithZero(ref int[] smaller, int length)
        {
            int[] newarr = new int[length];
            int smLength = smaller.Length;

            int j = 0;
            while (j < length - smLength)
                newarr[j++] = 0;

            for (int i = 0; i < smaller.Length; i++)
                newarr[j + i] = smaller[i];

            return newarr;
        }
    }
}
