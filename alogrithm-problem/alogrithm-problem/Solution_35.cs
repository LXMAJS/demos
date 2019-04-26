using System;
using System.Collections.Generic;
using System.Text;

namespace alogrithm_problem
{
    public class Solution_35
    {
        /// <summary>
        /// 给定一个排序数组和一个目标值，在数组中找到目标值，并返回其索引。如果目标值不存在于数组中，返回它将会被按顺序插入的位置。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int SearchInsert(int[] nums, int target)
        {
            // 如果数组中没有元素，或首元素大于目标值，则返回0
            if (nums.Length <= 0 || nums[0] >= target)
                return 0;

            // 如果尾元素大于目标值，则返回 长度- 1
            if (nums[nums.Length - 1] <= target)
                return nums.Length - 1;

            int index = SearchInsert(nums, target, 0, nums.Length - 1);

            return index;
        }

        /// <summary>
        /// 递归本体
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private static int SearchInsert(int[] nums, int target, int left, int right)
        {
            int min = left + (right - left) / 2;

            // 对比值，是在左边还是在右边
            if (target == nums[min])
                return min;
            else if (target > nums[min])
                return SearchInsert(nums, target, min + 1, right);
            else
            {
                if (left >= min - 1)
                {
                    if (nums[left] <= target)
                        return left + 1;
                    else
                        return left;
                }
                else
                    return SearchInsert(nums, target, left, min - 1);
            }
        }
    }
}
