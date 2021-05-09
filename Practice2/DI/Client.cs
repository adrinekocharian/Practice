using System;
using System.Collections.Generic;
using System.Text;

namespace DI
{
    public class Client
    {
        private IDataReader dataReaderService;
        public IDataReader DataReader { get; set; }
        public Client(IDataReader dataReader)
        {
            this.dataReaderService = dataReader;
        }
        public Client()
        {

        }
        //private MongoDBReader service;
        //public Client()
        //{
        //    service = new MongoDBReader();
        //}

        public void Start(IDataReader dataReader)
        {
            dataReaderService.DoSomething();
        }

        public void Stop()
        {
            dataReaderService.DoSomething();
        }
    }
}
