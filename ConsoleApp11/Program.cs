using System;
using System.Threading;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            Table table = new Table(5);

            Thread[] threads = new Thread[5];
            for (var i = 0; i < 5; i++)
            {
                var i1 = i;
                threads[i] = new Thread(() => table.StartEating(i1));
                threads[i].Start();
            }

            for (int i = 0; i < 5; i++)
            {
                threads[i].Join();
            }
        }
    }
}