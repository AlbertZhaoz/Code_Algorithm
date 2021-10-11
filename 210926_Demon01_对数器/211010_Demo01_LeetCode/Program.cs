using System;

namespace _211010_Demo01_LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = new int[] { 1, 2 };
            int[] nums2 = new int[] { 3, 4 };
            FindMedianSortedArrays(nums1, nums2);
        }

        /// <summary>
        /// 方法1：申请第三个数组，然后排序
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] tempNum = new int[nums1.Length + nums2.Length];
            for (int i = 0; i < nums1.Length; i++)
            {
                tempNum[i] = nums1[i];
            }

            for (int i = 0; i < nums2.Length; i++)
            {
                tempNum[nums1.Length+i] = nums2[i];
            }
            Array.Sort(tempNum);
            if ((tempNum.Length % 2) != 0)
            {
                return tempNum[tempNum.Length >> 1];
            }
            else
            {
                return (tempNum[(tempNum.Length-1) >> 1] + tempNum[((tempNum.Length - 1) >> 1) + 1])/2.0;
            }
        }

    }
}
