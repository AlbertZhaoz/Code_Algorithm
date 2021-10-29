using System;
using System.Collections;

namespace _210930_Demon01_异或
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestLogarithmic(1000);

            int test = 7;
            System.Console.WriteLine((~test)+1);
            System.Console.WriteLine("================");
            int[] arrOne = new int[] { 4, 6, 6, 8, 8, 10, 10,10 };
            FindTwoNumberByOrder(arrOne);
            System.Console.WriteLine("================");
            int[] arrTwo = new int[] { 4, 4,4, 6, 6, 10, 10, 10,11,11,11 };
            int kValue = FindOnlyKOtherM(arrTwo, 2, 3);
            Console.WriteLine($"那个出现K次的数为{kValue}");
            Console.WriteLine($"第二种方法，那个出现K次的数为{FindOnlyKOtherMByHashCode(arrTwo, 2, 3)}");
            System.Console.WriteLine("================");

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

        /// <summary>
        /// 有两种数，出现奇数次
        /// </summary>
        /// <param name="arr"></param>
        static void FindTwoNumberByOrder(int[] arr)
        {
            int eor = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                eor = eor ^ arr[i];              
            }
            int rightOne = eor & (~eor + 1);//提取出最右的1
            int eorRight = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if((rightOne&arr[i]) != 0)
                {
                    eorRight = eorRight ^ arr[i];
                }
            }
            Console.WriteLine($"其中的一个数为{eorRight}");
            Console.WriteLine("======================");
            Console.WriteLine($"另一个数为{eor^eorRight}");
        }


       


        /// <summary>
        /// 此方法通过对数器的手段
        /// </summary>
        /// <returns></returns>
        static void TestLogarithmic(int testCount)
        {
            //需要一个随机数组：随机N种数，其中只有一种数出现了K次，其他数出现了M次（K>1,M>K)
            int[] randomArr = RandomArray(10, 2, 4);
            //第一种算法通过Int32位二进制方式，方法生成的数
            int num1 = FindOnlyKOtherM(randomArr, 2, 4);
            //第二种Hash表的方法
            int num2 = FindOnlyKOtherMByHashCode(randomArr, 2, 4);
            Console.WriteLine("Start test：");
            for (int i = 0; i < testCount; i++)
            {
                Console.WriteLine($"The test index is {i}");
                if (num1!= num2)
                {
                    Console.WriteLine("Method error:");
                    Console.WriteLine(randomArr);
                }
            }
            Console.WriteLine("Finish test：");
        }

        /// <summary>
        /// 一个随机数组：随机N种数，其中只有一种数出现了K次，其他数出现了M次（K>1,M>K)
        /// </summary>
        /// <param name="N"></param>
        /// <param name="K"></param>
        /// <param name="M"></param>
        /// <returns></returns>
        static int[] RandomArray(int N,int K,int M)
        {
            //Random.Next(minValue,maxValue) 也是左闭右开区间
            //A 32-bit signed integer that is greater than or equal to 0,
            //and less than maxValue; that is, the range of return values ordinarily includes 0 but not maxValue.
            //However, if maxValue equals 0, maxValue is returned.
            if (K < 1 || K > M)
            {
                Console.WriteLine("请重新输入K，M的值，不合法");
            }
            Random random = new Random();
            int arrKind = N-1;//出现M次的数的种类
            int arrLen = K * 1 + arrKind * M;
            int[] arrResult = new int[arrLen];
            //需要一个哈希表来判定此处后续添加的随机数字
            Hashtable hashtable = new Hashtable();
            int kNumber = random.Next(-200, 200);//随机产生一个-200~200之间的数
            hashtable.Add(kNumber, 1);
            for (int i = 0; i < K; i++)
            {
                arrResult[i] = kNumber;
            }
            //外层循环出现M次的随机数
            int index = K;//数组下标从K开始
            for (int i = 0;i< arrKind; i++)
            {
                int mNumber = random.Next(-200, 200);//随机产生一个-200~200之间的数
                while (hashtable.ContainsKey(mNumber))
                {
                    mNumber = random.Next(-200, 200);//随机产生一个-200~200之间的数
                }
                hashtable.Add(mNumber, 1);
                for (int j = 0; j < M; j++)
                {
                    arrResult[index] = mNumber;
                    index++;
                }
            }
            //将有规律的数组打乱（随机的i和j位置交换）
            for (int i = 0; i < arrLen; i++)
            {
                //产生一个随机索引，索引位置和i交换
                int randomIndex = random.Next(0, arrLen);
                int tmp = arrResult[randomIndex];
                arrResult[randomIndex] = arrResult[i];
                arrResult[i] = tmp;
            }

            return arrResult;           
        }

        /// <summary>
        /// 哈希表的方法
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        static int FindOnlyKOtherMByHashCode(int[] arr, int k, int m)
        {
            Hashtable hashtable = new Hashtable();
            for (int i = 0; i < arr.Length; i++)
            {
                if (hashtable.ContainsKey(arr[i]))
                {
                    hashtable[arr[i]] = (int)hashtable[arr[i]] + 1;
                }
                else
                {
                    hashtable.Add(arr[i], 1);
                }
            }
            foreach (DictionaryEntry item in hashtable)
            {
                if ((int)item.Value == k)
                {
                    return (int)item.Key;
                }
            }
            return -1;
        }

        /// <summary>
        /// 请保证arr中，只有一种数出现了K次，其他数都出现了M次（K<M）
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static int FindOnlyKOtherM(int[] arr, int k, int m)
        {
            int[] arr32T = new int[32];
            int kValue = 0;
            //arr32T[0] 0位置出现了几个
            //arr32T[1] 1位置出现了几个
            //arr32T[2] 2位置出现了几个
            foreach (var item in arr)
            {
                for (int i = 0; i < 32; i++)
                {
                    //通过右移，将每一位出现1的累加到记录数组中
                    if (((item >> i) & 1) != 0)
                    {
                        arr32T[i]++;
                    }
                }
            }
            //遍历数组，如果某一位出现的次数不是M的整数倍，则必定是K那个数存在了1
            for (int i = 0; i < 32; i++)
            {
                if ((arr32T[i] % m) != 0)
                {
                    //kValue += (int)Math.Pow(2, i);
                    //1左移i位，然后或进去
                    kValue |= (1 << i);
                }
            }
            return kValue;
        }
    }
}
