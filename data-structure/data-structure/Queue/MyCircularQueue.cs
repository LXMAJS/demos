using System;
using System.Collections.Generic;
using System.Text;

namespace data_structure.Queue
{
    /// <summary>
    /// 自定义的循环队列
    /// </summary>
    public class MyCircularQueue
    {
        private int[] val;
        private int size;
        private int tail;
        private int head;

        /// <summary>
        /// Initialize your data structure here. Set the size of the queue to be k.
        /// </summary>
        /// <param name="k"></param>
        public MyCircularQueue(int k)
        {
            if (k > 1000)
                throw new OverflowException("Overflow error, k is bigger than the largest size of MyCircularQueue's range.");

            this.val = new int[k];
            for (int i = 0; i < k; i++)
            {
                this.val[i] = -1; // initialize
            }
            this.size = k;
            this.tail = -1;
            this.head = -1;
        }

        /// <summary>
        /// Insert an element into the circular queue. Return true if the operation is successful.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool EnQueue(int value)
        {
            if (this.IsFull())
                return false;
            
            // 自增游标
            this.tail++;
            if(this.tail >= this.size)
            {
                // 超过数组的最大范围，则将队列头
                this.tail = 0;
            }
            // 添加数据
            val[this.tail] = value;

            // 首次加入值时，需要将head向前移一位
            if (this.head == -1)
                this.head = this.tail;

            return true;
        }

        /// <summary>
        /// Delete an element from the circular queue. Return true if the operation is successful.
        /// </summary>
        /// <returns></returns>
        public bool DeQueue()
        {
            if (this.IsEmpty())
                return false;

            // head自增（向后移一位），如果超过了size，就循环至0
            this.head++;
            if(this.head > this.size)
            {
                this.head = 0;
            }

            if(this.IsEmpty())
            {
                this.head = -1;
                this.tail = -1;
            }

            return true;
        }

        /// <summary>
        /// Get the front item from the queue.
        /// </summary>
        /// <returns></returns>
        public int Front()
        {
            return this.head == -1 ? -1 : val[this.head];
        }

        /// <summary>
        /// Get the last item from the queue. 
        /// </summary>
        /// <returns></returns>
        public int Rear()
        {
            return this.tail == -1 ? -1 : val[this.tail];
        }

        /// <summary>
        /// Checks whether the circular queue is empty or not.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.head == this.tail;
        }

        /// <summary>
        /// Checks whether the circular queue is full or not.
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            int next = this.tail + 1;
            if (next >= this.size)
                next = 0;
            return next == this.head;
        }
    }
}
