using System;

namespace _210928_Demon01_二分法
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { -1, 0, 3, 5, 9, 12 };
            Console.WriteLine(Search(arr, 2)); 

            var isExist = BSExist(arr, 10);
            Console.WriteLine(isExist);
        }

        public static int Search(int[] nums, int target)
        {
            int L = 0;
            int R = nums.Length - 1;
            int mid = 0;
            while (L < R)
            {
                mid = L + ((R - L) >> 1);
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] < target)
                {
                    L = mid + 1;
                    
                }
                else
                {
                    R = mid - 1;
                }
            }
            if (nums[L] == target)
            {
                return L;
            }
            else
            {
                return -1;
            }
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
