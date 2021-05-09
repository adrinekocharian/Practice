using System;
using System.Collections.Generic;
using System.Text;

namespace DI
{
    public class MongoDBReader : IDataReader
    {
        public void DoSomething()
        {
            Console.WriteLine("Service2");
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
