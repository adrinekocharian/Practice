using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Threads
{
    class Counter
    {
        private int count = 0;
        private object lockObject = new object();

        public void Increment()
        {
            bool lockTaken = false;
            try
            {
                Monitor.Enter(lockObject, ref lockTaken);
                count = count + 1;
            }
            finally
            {
                if (lockTaken)
                {
                    Monitor.Exit(lockObject);
                }
            }
            //lock(lockObject)
            //{
            //    count = count + 1;
            //    // temp = count +1; count = temp;
            //}
            //Interlocked.Increment(ref count);
            //count++; //count = count + 1;
        }
        public void Dencrement()
        {
            bool lockTaken = false;
            try
            {
                Monitor.Enter(lockObject, ref lockTaken);
                count = count - 1;
            }
            finally
            {
                if (lockTaken)
                {
                    Monitor.Exit(lockObject);
                }
            }
            //lock (lockObject)
            //{
            //    count = count - 1;
            //}
            //Interlocked.Decrement(ref count);
            //count--;
        }

        public int GetCount()
        {
            return count;
        }
    }
}
