using data_structure.Queue;
using System;

namespace data_structure
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCircularQueue q = new MyCircularQueue(6);

            Console.WriteLine(q.EnQueue(6));

            Console.WriteLine(q.Rear());
            Console.WriteLine(q.Rear());

            Console.WriteLine(q.DeQueue());
            Console.WriteLine(q.EnQueue(5));
            
            Console.WriteLine(q.Rear());

            Console.WriteLine(q.DeQueue());
            
            Console.WriteLine(q.Front());
            Console.WriteLine(q.DeQueue());
            Console.WriteLine(q.DeQueue());
            Console.WriteLine(q.DeQueue());

            Console.WriteLine("Hello World!");
            Console.Read();
        }
    }
}
