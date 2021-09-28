using System;

namespace _210926_Demon01_对数器
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        /// <summary>
        /// 选择排序
        /// </summary>
        /// <param name="arr"></param>
        /// <remarks>
        /// 0-(n-1)找到最小值
        /// 1-(n-1)找到最小值
        /// 2-(n-1)找到最小值
        /// </remarks>
        static void SelectionSort(int[] arr)
        {
            if(arr.Length<2||arr == null)
            {
                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                int minIndex = i;
                for (int j = i+1; j < arr.Length; j++)
                {
                    minIndex = arr[j]<arr[minIndex]?j:minIndex;
                }
                Swap(arr, i, minIndex);
            }
        }

        static void Swap(int[] arr, int i, int j)
        {
            int tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }

        // for test
        static void Comparator(int[] arr)
        {
            Array.Sort(arr);
        }

        // for test
        static int[] CopyArray(int[] arr)
        {
            if (arr == null)
            {
                return null;
            }

            int[] res = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                res[i] = arr[i];
            }
            return res;
        }

        //对数器
        static int[] GenerateRandomArray(int maxSize, int maxValue)
        {
            // Math.random()   [0,1)  
            // Math.random() * N  [0,N)
            // (int)(Math.random() * N)  [0, N-1]
            var random = new Random();
            int[] arr = new int[(int)((maxSize + 1) * random.Next())];
            for (int i = 0; i < arr.Length; i++)
            {
                // [-? , +?]
                arr[i] = (int)((maxValue + 1) * random.Next()) - (int)(maxValue * random.Next());
            }
            return arr;
        }
    }
}
