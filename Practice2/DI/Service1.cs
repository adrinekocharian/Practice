using System;
using System.Collections.Generic;
using System.Text;

namespace DI
{
    public class SQLReader : IDataReader
    {
        public void DoSomething()
        {
            Console.WriteLine("Service1");
        }
        public void Read()
        {

        }

        public void Write()
        {
            throw new NotImplementedException();
        }
    }
}
