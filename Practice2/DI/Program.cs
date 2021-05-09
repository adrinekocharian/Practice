using System;
using Unity;

namespace DI
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataReader = new SQLReader();
            var dataReader2 = new MongoDBReader();
            Client client = new Client(dataReader2);
            client.Stop();

            Client client2 = new Client();
            client2.DataReader = new SQLReader();
            client2.Stop();

            Client client3 = new Client();
            client3.Start(new MongoDBReader());
        }
    }
}