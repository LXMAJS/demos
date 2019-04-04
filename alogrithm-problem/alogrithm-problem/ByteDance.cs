using System;
using System.Collections.Generic;
using System.Text;

namespace alogrithm_problem
{
    public class ByteDance
    {
        /// <summary>
        /// 重新分配房间的题目
        /// </summary>
        /// <param name="a"></param>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static int[] GetOriginRoomData(int[] a, int n, int m)
        {
            int whileCount = 0;
            int curRoomNo = m;

            while (true)
            {
                curRoomNo--;
                if (curRoomNo < 0)
                    curRoomNo = n - 1;
                // 减少当前房间中的人数，
                a[curRoomNo] = a[curRoomNo] - 1;
                whileCount++;
                if (a[curRoomNo] < 0)
                    break;
            }

            a[curRoomNo] = whileCount - 1;

            return a;
        }

        /// <summary>
        /// 测试主函数
        /// </summary>
        static void main()
        {
            int[] a = new int[] { 6, 5, 1 };
            int n = 3;
            int m = 1;

            int[] b = GetOriginRoomData(a, n, m);
            for (int i = 0; i < b.Length; i++)
            {
                Console.Write(b[i] + " ");
            }
        }
    }
}
