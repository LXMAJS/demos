using data_structure.Queue;
using System;

namespace data_structure
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCircularQueue q = new MyCircularQueue(5);
            for (int i = 0; i < 8; i++)
            {
                bool en = q.EnQueue(i);

                Console.WriteLine($"EnQueue : {i}, result : {en.ToString()}, Head[{q.Front()}], Tail[{q.Rear()}]");
            }

            Console.WriteLine("Hello World!");
            Console.Read();
        }
    }
}
