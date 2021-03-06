﻿using System;

namespace alogrithm_problem
{
    class Program
    {
        /// <summary>
        /// 合并两个有序的数组
        /// </summary>
        /// <param name="nums1">数组1，基础数组，已知他的空间足够大，大于等于 m+n</param>
        /// <param name="m">数组1的实际元素个数</param>
        /// <param name="nums2">数组2，需要被合并的数组</param>
        /// <param name="n">数组2的实际元素的个数</param>
        public static void merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (n <= 0)
                return;

            if (m <= 0 || nums1[m - 1] <= nums2[0])
            {
                // 如果数组1的最后一个元素，比数组2的元素还要小，那么不做任何处理，直接进入最后的合并环节
            }
            else
            {
                // 此处进行比对环节，将所有数组1中，比数组2大的数，依次替换到数组2中
                int index1 = 0, index2 = 0;
                int temp = 0;
                while (index1 < m && index2 < n)
                {
                    if (nums1[index1] > nums2[index2])
                    {
                        temp = nums2[index2];
                        nums2[index2] = nums1[index1];
                        nums1[index1] = temp;
                        // 此处需要对 nums2[index2] 做一次排序，直到找到最合适的位置
                        for (int index = index2 + 1; index < n; index++)
                        {
                            if (nums2[index] < nums2[index2])
                            {
                                temp = nums2[index];
                                nums2[index] = nums2[index2];
                                nums2[index2] = temp;
                            }
                            else
                                break;
                        }
                        index2++;
                    }
                    index1++;
                }
            }
            for (int i = 0; i < n; i++)
            {
                nums1[m + i] = nums2[i];
            }
        }

        static void Main(string[] args)
        {
            /*
            int[] nums1 = new int[] { 4, 5, 6, 0, 0, 0 };
            int m = 3;

            int[] nums2 = new int[] { 1, 2, 3 };
            int n = 3;

            merge(nums1, m, nums2, n);

            for (int i = 0; i < nums1.Length; i++)
            {
                Console.Write(" " + nums1[i]);
            }
            */

            int[] nums = new int[] { 1, 3, 5, 6 };
            int index = Solution_35.SearchInsert(nums, 2);
            Console.Write(index);

            Console.Read();
            Console.WriteLine("Hello World!");
        }
    }
}
