using System;

namespace _210930_Demon01_异或
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            Swap(arr[1], arr[2]);
            Console.WriteLine(arr[1]);
            int[] arr2 = new int[] { 1, 1, 4, 4, 3, 6, 6 };
            Console.WriteLine(FindOddNumber(arr2));
            Console.WriteLine("TestWorld");
            Console.WriteLine("TestWorld2");
            Console.WriteLine("TestWorld3");
        }

        /// <summary>
        /// 交换两个内存空间不一样的数
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        static void Swap(int a,int b)
        {
            a = a ^ b;
            b = a ^ b;
            a = a ^ b;
        }

        /// <summary>
        /// 一个数组中有一种数出现了奇数次，其他数都出现了偶数次，怎么找到并打印这个数
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static int FindOddNumber(int[] arr)
        {
            int eor = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                eor = eor ^ arr[i];
            }
            return eor;
        }
    }
}
