using System;
using System.Collections.Generic;
using System.Text;

namespace alogrithm_problem
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution_112
    {
        /// <summary>
        /// 检索某棵树的某个路径的节点值的和，是否匹配某个值
        /// 可采用深度优先算法计算，若当前值已经大于sum，则直接返回false
        /// </summary>
        /// <param name="root"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public static bool HasPathSum(TreeNode root, int sum)
        {
            if (root.val > sum)
                return false;

            int curSum = root.val;
            TreeNode curNode = root;
            while(curSum >= sum)
            {
                if (curNode.left != null && curSum+curNode.left.val < sum)
                {
                    // 如果左孩子存在，且左孩子的val加上当前的值，不超过sum，则循环到左孩子

                }
            }
            return false;
        }
    }
}
