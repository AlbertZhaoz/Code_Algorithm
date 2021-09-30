using System;

namespace _210928_Demon01_二分法
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 5, 5, 6, 7, 9 };
            var isExist = BSExist(arr, 10);
            Console.WriteLine(isExist);
        }

        /// <summary>
        /// 二分查找：每次砍一半，O(log2N)-->O(logN)
        /// </summary>
        static bool BSExist(int[] arr,int value)
        {
            int L = 0;//左边
            int R = arr.Length-1;//右边
            int mid = 0;
            while (L<R)
            {
                mid = L + ((R - L) >> 1);
                if(arr[mid] == value)
                {
                    return true;
                }
                else if(arr[mid] < value)
                {
                    L = mid+1;

                }
                else
                {
                    R = mid - 1;
                }
            }
            //最后一个数，边界条件
            return arr[L] == value;
            
        }
    }
}
