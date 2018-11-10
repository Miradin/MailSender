using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using FileHelpers;
using System.Collections.Concurrent; //for Queue

namespace ThreadingCalc
{
    class CSVReaderWriter
    {
        [DelimitedRecord(",")]
        public class Customer
        {
            public int policyID { get; set; }
            public string statecode { get; set; }
            public string county { get; set; }
            public float eq_site_limit { get; set; }
            public float hu_site_limit { get; set; }
            public float fl_site_limit { get; set; }
            public float fr_site_limit { get; set; }
            public float tiv_2011 { get; set; }
            public float tiv_2012 { get; set; }
            public float eq_site_deductible { get; set; }
            public float hu_site_deductible { get; set; }
            public float fl_site_deductible { get; set; }
            public float fr_site_deductible { get; set; }
            public float point_latitude { get; set; }
            public float point_longitude { get; set; }
            public string line { get; set; }
            public string construction { get; set; }
            public int point_granularity { get; set; }
        }

        static ConcurrentQueue<Customer> custStorage = new ConcurrentQueue<Customer>();

        public static void ReadCSVEntryPoint()
        {
            //var engine = new FileHelperEngine<Customer>();
            //var result = engine.ReadFile("sample.scv");

            //Reading record by record in order to be able to sleep the process
            
            var customers = new FileHelperAsyncEngine<Customer>();

            using (customers.BeginReadFile("sample.csv"))
            {
                foreach (Customer cust in customers)
                {
                    //Console.WriteLine("policyID: {0} -- county: {1}", cust.policyID, cust.county);
                    custStorage.Enqueue(cust);
                    Thread.Sleep(200);
                    ThreadPool.QueueUserWorkItem(WriteCSVEntryPoint);
                }
            }

        }

        public static void WriteCSVEntryPoint(object parameter)
        {
            Customer cust = new Customer();
            custStorage.TryDequeue(out cust);
            var newcustomers = new FileHelperAsyncEngine<Customer>();  
            if (cust !=null)
            {
                newcustomers.BeginAppendToFile("TestOut.txt");
                //newcustomers.BeginWriteFile("TestOut.txt");
                Console.WriteLine("policyID: {0} -- county: {1}", cust.policyID, cust.county);
                newcustomers.WriteNext(cust);
            }
            newcustomers.Close();
        }
    }
}
