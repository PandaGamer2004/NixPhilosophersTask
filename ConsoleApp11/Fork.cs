using System;
using System.Threading;

namespace ConsoleApp11
{
    public class Fork
    {
        private int _forkNumber;
        public Fork(Int32 number)
        {
            _forkNumber = number;
        }

        public int ForkNumber => _forkNumber;
        
    }
}