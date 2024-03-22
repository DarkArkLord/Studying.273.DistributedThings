using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReplicationTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            using (var db = new ApplicationContext(DbInstance.Master, true, true))
            {
                Console.WriteLine("Db content on master after creating");
                WriteRecords(db.Records.ToArray());

                var record1 = new TRecord { Id = 1, Text = "123" };
                db.Records.Add(record1);
                var record2 = new TRecord { Id = 2, Text = "456" };
                db.Records.Add(record2);
                var record3 = new TRecord { Id = 3, Text = "789" };
                db.Records.Add(record3);

                db.SaveChanges();

                Console.WriteLine("Db content on master after add records");
                WriteRecords(db.Records.ToArray());
            }

            Task.Delay(1000).Wait();

            using (var db = new ApplicationContext(DbInstance.Slave, false, false))
            {
                Console.WriteLine("Db content on slave");
                WriteRecords(db.Records.ToArray());
            }

            Console.WriteLine("\n----------\nEnd!");
        }

        static void WriteRecords(IEnumerable<TRecord> records)
        {
            foreach (var record in records)
            {
                Console.WriteLine($"{record.Id}) {record.Text}");
            }
        }
    }
}
